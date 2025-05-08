using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Infra.Ioc.Models.Base;
using CardapioDigital.Infra.Ioc.Models.Response.AbaCardapio;
using CardapioDigital.Infra.Ioc.Models.Response.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RestauranteAbaCardapioController : Controller
    {
        private readonly IRestauranteAbaCardapioService _service;
        private readonly IMapper _mapper;

        public RestauranteAbaCardapioController(IRestauranteAbaCardapioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ApiToken>> Inserir(AbaCardapioBase abaCardapio)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode criar novas abas.");

            var abaCardapioDTO = _mapper.Map<AbaCardapioDTO>(abaCardapio);
            abaCardapioDTO.RestauranteId = restauranteId;
            await _service.Inserir(abaCardapioDTO);
            return Ok("Aba registrada com sucesso!");
        }

        [HttpPut("{abaCardapioId}")]
        public async Task<ActionResult> Editar(int abaCardapioId, AbaCardapioBase abaCardapio)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode editar abas.");

            var abaCardapioDTO = _mapper.Map<AbaCardapioDTO>(abaCardapio);
            abaCardapioDTO.RestauranteId = restauranteId;
            abaCardapioDTO.Id = abaCardapioId;

            await _service.Alterar(abaCardapioDTO);
            return Ok("Aba editada com sucesso!");
        }

        [HttpPut("ordenacao")]
        public async Task<ActionResult> SalvarOrdenacao(int[] abaCardapioIds)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode editar a ordenação das abas.");

            await _service.SalvarOrdenacao(abaCardapioIds, restauranteId);
            return Ok("Ordenação salva com sucesso!");
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<AbaCardapioResponse>>> ListarTodos()
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            var abasDTO = await _service.BuscarPorRestauranteId(restauranteId);
            return Ok(_mapper.Map<IEnumerable<AbaCardapioResponse>>(abasDTO));
        }

        [HttpDelete("{abaCardapioId}")]
        public async Task<ActionResult> Excluir(int abaCardapioId)
        {
            await _service.Excluir(abaCardapioId);
            return Ok("Aba excluida com sucesso!");
        }
    }
}
