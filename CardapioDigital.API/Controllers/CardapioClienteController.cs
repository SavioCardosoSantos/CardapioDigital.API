using AutoMapper;
using CardapioDigital.Application.DTOs.CardapioCliente;
using CardapioDigital.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardapioClienteController : Controller
    {
        private readonly ICardapioClienteService _service;
        private readonly IMapper _mapper;

        public CardapioClienteController(ICardapioClienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{restauranteId}/{clienteId}")]
        public async Task<ActionResult<CardapioResponse>> BuscarCardapio(int restauranteId, int clienteId)
        {
            var cardapioResponse = await _service.BuscarCardapio(restauranteId, clienteId);
            return Ok(cardapioResponse);
        }
    }
}
