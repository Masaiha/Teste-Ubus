using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;

namespace Ubus.App.Controllers
{
    [Route("viagem")]
    public class ViagemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IViagemRepository _viagemRepository;
        private readonly IMotoristaRepository _motoristaRepository;

        public ViagemController(IViagemRepository viagemRepository, IMapper mapper, IMotoristaRepository motoristaRepository)
        {
            _viagemRepository = viagemRepository;
            _mapper = mapper;
            _motoristaRepository = motoristaRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ViagemMotoristaViewModel>> Index()
        {
            var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.ObterTodosViagemMotoristas());

            return View(viagemMotoristaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(ViagemViewModel viagemViewModel)
        {
            await _viagemRepository.Adicionar(_mapper.Map<Viagem>(viagemViewModel));

            return View(viagemViewModel);
        }

        [HttpGet("filtrado-dia-atual")]
        public ActionResult<IEnumerable<ViagemMotoristaViewModel>> FiltrarViagemsPorDia()
        {
            var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.FiltrarViagemsPorDia());

            return View(nameof(Index), viagemMotoristaViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ViagemViewModel>> Details(Guid id)
        {
            var viagensViewModel = _mapper.Map<ViagemViewModel>(await _viagemRepository.ObterPorId(id));
            
            return View(viagensViewModel);
        }

        [HttpGet("atualizar-status-viagens-finalizadas")]
        public ActionResult AtualizarViagensFinalizadas()
        {
             _viagemRepository.AtualizarViagensFinalizadas();

            var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.ObterTodosViagemMotoristas());

            return View("Index", viagemMotoristaViewModel);
        }

    }
}
