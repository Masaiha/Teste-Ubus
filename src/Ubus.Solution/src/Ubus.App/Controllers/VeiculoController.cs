using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;

namespace Ubus.App.Controllers
{
    [Route("veiculos")]
    public class VeiculoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IAdicionalRepository _adicionalRepository;
        private readonly IItemRepository _itemRepository;

        public VeiculoController(IMapper mapper,
                                 IVeiculoRepository veiculoRepository,
                                 IAdicionalRepository adicionalRepository, 
                                 IItemRepository itemRepository)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;
            _adicionalRepository = adicionalRepository;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoViewModel>>> Index()
        {
            var veiculosViewModel = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos());
            return View(veiculosViewModel);
        }

        [HttpGet("adicionar-veiculo")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost("adicionar-veiculo")]
        public async Task<IActionResult> Adicionar(VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _veiculoRepository.Adicionar(_mapper.Map<Veiculo>(veiculoViewModel));

            return View("Index");
        }

        [HttpGet("{idVeiculo:guid}")]
        public ActionResult<VeiculoItensViewModel> AlteracaoItensVeiculo(Guid idVeiculo)
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

        [HttpGet("vincular-itens/{idVeiculo:guid}")]
        public async Task<ActionResult<IEnumerable<ItemViewModel>>> VincularItem(Guid idVeiculo)
        {
            ViewData["IdVeiculo"] = idVeiculo;

            var itensVeiculo = _mapper.Map<List<ItemViewModel>>(await _itemRepository.ObterSomenteVinculadosAoVeiculo(idVeiculo));
            var itens = _mapper.Map<List<ItemViewModel>>(await _itemRepository.ObterTodos());
            var listItens = new List<ItemViewModel>();

            foreach (var item in itens)
            {                
                if (!itensVeiculo.Contains(item, new ComparerDados()))
                    listItens.Add(item);
            }

            return View(listItens);
        }

        [AllowAnonymous]
        [HttpPost("vincular-itens/{idVeiculo:guid}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<IEnumerable<ItemViewModel>>> VincularItem(Guid idVeiculo, ItemViewModel itemViewModel)
        {
            //var teste = HttpContext;
            ViewData["IdVeiculo"] = idVeiculo;

            await _adicionalRepository
                .Adicionar(_mapper.Map<AdicionalItem>(new AdicionalItemViewModel()
                {
                    ItemId = itemViewModel.Id,
                    VeiculoId = idVeiculo
                }));

            var itensVeiculo = _mapper.Map<List<AdicionalItemViewModel>>(await _adicionalRepository.ObterPorIdVeiculo(idVeiculo));
            var itens = _mapper.Map<IEnumerable<ItemViewModel>>(await _itemRepository.ObterTodos()).ToList();

            for (int i = 0; i < itens.ToList().Count(); i++)
            {
                if (itensVeiculo.Select(x => x.ItemId == itens[i].Id).Count() > 0)
                    itens.Remove(itens[i]);
            }

            return View(itens.ToList());
        }

        public class ComparerDados : IEqualityComparer<ItemViewModel>
        {
            public bool Equals(ItemViewModel x, ItemViewModel y)
            {
                return (x.Nome.Equals(y.Nome));
            }

            public int GetHashCode(ItemViewModel obj)
            {
                return 0;
            }
        }
    }
}
