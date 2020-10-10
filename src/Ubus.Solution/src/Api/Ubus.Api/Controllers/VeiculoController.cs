using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;

namespace Ubus.Api.Controllers
{
    [ApiController]
    [Route("api/veiculos")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IAdicionalRepository _adicionalRepository;
        private readonly IMapper _mapper;

        public VeiculoController(IVeiculoRepository veiculoRepository, IMapper mapper, IAdicionalRepository adicionalRepository)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _adicionalRepository = adicionalRepository;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterVeiculosItensPorRotaId(Guid id)
        {
            var veiculositens = _adicionalRepository.ObterVeiculosItensPorRotaId(id);

            return Ok(veiculositens);
        }

    }
}
