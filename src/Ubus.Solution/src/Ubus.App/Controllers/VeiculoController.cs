using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Interfaces.Repositories;

namespace Ubus.App.Controllers
{
    [Route("veiculos")]
    public class VeiculoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IAdicionalRepository _adicionalRepository;

        public VeiculoController(IMapper mapper, 
                                 IVeiculoRepository veiculoRepository, 
                                 IAdicionalRepository adicionalRepository)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;
            _adicionalRepository = adicionalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoViewModel>>> Index()
        {
            var veiculosViewModel = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos());
            return View(veiculosViewModel);
        }

        [HttpGet("{idVeiculo:guid}")]
        public async Task<ActionResult<VeiculoItensViewModel>> AlteracaoItensVeiculo(Guid idVeiculo)
        {
            ViewData["VeiculoId"] = idVeiculo;

            var veiculoItens = _mapper.Map<VeiculoItensViewModel>(_veiculoRepository.ObterItensVeiculo(idVeiculo));

            return View(veiculoItens);
        }

        [Route("excluir-itens/{IdVeiculoItem:guid}/{idVeiculo:guid}")]
        public async Task<ActionResult<VeiculoItensViewModel>> ExcluirItem(Guid IdVeiculoItem, Guid idVeiculo)
        {
            await _adicionalRepository.ExcluirItemVeiculo(IdVeiculoItem);

            ViewData["VeiculoId"] = idVeiculo;
            var veiculoItens = _mapper.Map<VeiculoItensViewModel>(_veiculoRepository.ObterItensVeiculo(idVeiculo));

            return View("AlteracaoItensVeiculo", veiculoItens);
        }
    }
}
