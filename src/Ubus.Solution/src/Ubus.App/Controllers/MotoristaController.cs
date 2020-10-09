using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Repositories;

namespace Ubus.App.Controllers
{
    [Route("motorista")]
    public class MotoristaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMotoristaViagemRepository _motoristaViagemRepository;

        public MotoristaController(IMapper mapper, IMotoristaRepository motoristaRepository, IMotoristaViagemRepository motoristaViagemRepository)
        {
            _mapper = mapper;
            _motoristaRepository = motoristaRepository;
            _motoristaViagemRepository = motoristaViagemRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MotoristaViewModel>> Index()
        {
            //var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.ObterTodosViagemMotoristas());

            return View();
        }

        [HttpGet("selecao-motorista/{idViagem:guid}")]
        public async Task<ActionResult<MotoristaViewModel>> AlteracaoMotoristaViagem(Guid idViagem)
        {
            var motoristas = _mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaRepository.ObterTodos());

            ViewData["ViagemId"] = idViagem;

            return View(motoristas);
        }

        [HttpPost("alteracao-motorista-viagem")]
        public ActionResult EditarMotoristaViagem(MotoristaViewModel motoristaViewModel)
        {
            var mv = new MotoristaViagemViewModel()
            {
                MotoristaId = motoristaViewModel.Id,
                ViagemId = motoristaViewModel.ViagemId
            };

            _motoristaViagemRepository.AdicionaMotoristaViagem(_mapper.Map<MotoristaViagem>(mv));

            return View("index");
        }

        [HttpGet("motoristas-por-rota/{idRota:guid}")]
        public async Task<ActionResult<IEnumerable<MotoristaViewModel>>> ObterMotoristaPorRota(Guid idRota)
        {
            var motoristas = _mapper.Map<IEnumerable<MotoristaViewModel>>(_motoristaRepository.ObterMotoristasPorRota(idRota));

            return View(motoristas);
        }
    }
}
