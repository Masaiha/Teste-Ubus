using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Interfaces.Repositories;

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

    }
}
