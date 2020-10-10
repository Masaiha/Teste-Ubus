using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubus.App.Command;
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
        private readonly IMotoristaViagemRepository _motoristaViagemRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IRotaRepository _rotaRepository;

        public ViagemController(IViagemRepository viagemRepository,
                                IMotoristaRepository motoristaRepository,
                                IMotoristaViagemRepository motoristaViagemRepository,
                                IVeiculoRepository veiculoRepository, 
                                IRotaRepository rotaRepository,
                                IMapper mapper)
        {
            _mapper = mapper;
            _viagemRepository = viagemRepository;
            _motoristaRepository = motoristaRepository;
            _motoristaViagemRepository = motoristaViagemRepository;
            _veiculoRepository = veiculoRepository;
            _rotaRepository = rotaRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ViagemMotoristaViewModel>> Index()
        {
            var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.ObterTodosViagemMotoristas());

            return View(viagemMotoristaViewModel);
        }

        [HttpGet("adicionar-viagens")]
        public IActionResult Adicionar()
        {
            ViewData["Veiculos"] = new SelectList(_veiculoRepository.ObterTodos().Result.ToList(), "Id", "Id");
            ViewData["Rotas"] = new SelectList(_rotaRepository.ObterTodos().Result.ToList(), "Id", "Itinerario");
            ViewData["Motoristas"] = new SelectList(_motoristaRepository.ObterTodos().Result.ToList(), "Id", "Nome");

            return View();
        }

        [HttpPost("adicionar-viagens")]
        public async Task<IActionResult> Adicionar(CreateViagemCommand createViagemCommand)
        {
            if (!ModelState.IsValid) return BadRequest();

            var viagem = _mapper.Map<Viagem>(createViagemCommand);
            await _viagemRepository.Adicionar(viagem);

            await _motoristaViagemRepository
                .Adicionar(_mapper.Map<MotoristaViagem>(new MotoristaViagemViewModel()
                {
                    ViagemId = viagem.Id,
                    MotoristaId = createViagemCommand.MotoristaId
                }));

            var viagens = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(await _viagemRepository.ObterTodos());

            return View("Index", viagens);
        }

        [HttpGet("detalhes-viagem/{id:guid}")]
        public async Task<ActionResult<ViagemViewModel>> Detalhes(Guid id)
        {
            var viagensViewModel = _mapper.Map<ViagemViewModel>(await _viagemRepository.ObterPorId(id));
            
            return View(viagensViewModel);
        }

        [HttpGet("editar-viagem/{id:guid}")]
        public async Task<ActionResult<CreateViagemCommand>> Editar(Guid id)
        {
            var viagem = _mapper.Map<CreateViagemCommand>(await _viagemRepository.ObterPorId(id));
            ViewData["Veiculos"] = new SelectList(_veiculoRepository.ObterTodos().Result.ToList(), "Id", "Id");
            ViewData["Rotas"] = new SelectList(_rotaRepository.ObterTodos().Result.ToList(), "Id", "Itinerario");
            ViewData["Motoristas"] = new SelectList(_motoristaRepository.ObterTodos().Result.ToList(), "Id", "Nome");

            return View(viagem);
        }

        [HttpPost("editar-viagem/{id:guid}")]
        public async Task<IActionResult> Editar(Guid id, CreateViagemCommand createViagemCommand)
        {
            if (id != createViagemCommand.Id) return BadRequest(new { Message = "Ops! Os Ids são diferentes." });

            if (!ModelState.IsValid) return BadRequest();

            var viagem = _mapper.Map<Viagem>(createViagemCommand);
            await _viagemRepository.Atualizar(viagem);

            var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.ObterTodosViagemMotoristas());

            return View("Index", viagemMotoristaViewModel);
        }

        [HttpGet("filtrado-dia-atual")]
        public ActionResult<IEnumerable<ViagemMotoristaViewModel>> FiltrarViagemsPorDia()
        {
            var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.FiltrarViagemsPorDia());

            return View(nameof(Index), viagemMotoristaViewModel);
        }

        [HttpGet("atualizar-status-viagens-finalizadas")]
        public ActionResult AtualizarViagensFinalizadas()
        {
             _viagemRepository.AtualizarViagensFinalizadas();

            var viagemMotoristaViewModel = _mapper.Map<IEnumerable<ViagemMotoristaViewModel>>(_viagemRepository.ObterTodosViagemMotoristas());

            return View("Index", viagemMotoristaViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            var viagem = _viagemRepository.ObterPorId(id);
            var mv = _motoristaViagemRepository.ObterMotoristaViagemPorIdViagem(id);

            if (viagem == null) return BadRequest();
            if (mv != null) return BadRequest(new { Message = "Há um motorista vinculado" });

            await _viagemRepository.Remover(id);

            return Ok();
        }

    }
}
