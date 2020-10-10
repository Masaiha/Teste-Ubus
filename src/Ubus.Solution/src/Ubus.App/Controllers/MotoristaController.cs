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
        public async Task<ActionResult<IEnumerable<MotoristaViewModel>>> Index()
        {
            var motoristaViewModel = _mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaRepository.ObterTodos());

            return View(motoristaViewModel);
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
        public ActionResult<IEnumerable<MotoristaViewModel>> ObterMotoristaPorRota(Guid idRota)
        {
            var motoristas = _mapper.Map<IEnumerable<MotoristaViewModel>>(_motoristaRepository.ObterMotoristasPorRota(idRota));

            return View(motoristas);
        }

        [HttpGet("adicionar-motoristas")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost("adicionar-motoristas")]
        public async Task<IActionResult> Adicionar(MotoristaViewModel motoristaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _motoristaRepository.Adicionar(_mapper.Map<Motorista>(motoristaViewModel));

            var _motoristaViewModel = _mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaRepository.ObterTodos());

            return View("Index", _motoristaViewModel);
        }
    }
}
