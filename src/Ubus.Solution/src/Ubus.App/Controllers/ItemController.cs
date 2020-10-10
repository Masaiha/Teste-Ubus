using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;

namespace Ubus.App.Controllers
{
    [Route("itens")]
    public class ItemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ItemViewModel>>> Index()
        {
            var itens = _mapper.Map<IEnumerable<ItemViewModel>>(await _itemRepository.ObterTodos());
           
            return View(itens);
        }

        [HttpGet("adicionar-item")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost("adicionar-item")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(ItemViewModel itemViewModel)
        {
            await _itemRepository.Adicionar(_mapper.Map<Item>(itemViewModel));

            return View("Index");
        }
    }
}
