using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;

namespace Ubus.App.Controllers
{
    [Route("rotas")]
    public class RotaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRotaRepository _rotaRepository;

        public RotaController(IMapper mapper, IRotaRepository rotaRepository)
        {
            _mapper = mapper;
            _rotaRepository = rotaRepository;
        }

        public async Task<ActionResult<IEnumerable<RotaViewModel>>> Index()
        {
            var rotas = _mapper.Map<IEnumerable<RotaViewModel>>(await _rotaRepository.ObterTodos());

            return View(rotas);
        }

        [HttpGet("adicionar-rotas")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost("adicionar-rotas")]
        public async Task<IActionResult> Adicionar(RotaViewModel rotaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _rotaRepository.Adicionar(_mapper.Map<Rota>(rotaViewModel));
           
            var rotas = _mapper.Map<IEnumerable<RotaViewModel>>(await _rotaRepository.ObterTodos());

            return View("Index", rotas);
        }
    }
}
