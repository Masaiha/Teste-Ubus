using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public ViagemController(IViagemRepository viagemRepository, IMapper mapper)
        {
            _viagemRepository = viagemRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var viagensViewModel = _mapper.Map<IEnumerable<ViagemViewModel>>(await _viagemRepository.ObterTodos());

            return View(viagensViewModel);
        }
    }
}
