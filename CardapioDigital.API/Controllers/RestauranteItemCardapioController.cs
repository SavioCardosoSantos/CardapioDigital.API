using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Infra.Ioc.Models.Base;
using CardapioDigital.Infra.Ioc.Models.Response.ItemCardapio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RestauranteItemCardapioController : Controller
    {
        private readonly IRestauranteItemCardapioService _service;
        private readonly IMapper _mapper;

        public RestauranteItemCardapioController(IRestauranteItemCardapioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Inserir(ItemCardapioBase item)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode criar novos itens.");

            var itemDTO = _mapper.Map<ItemCardapioDTO>(item);
            itemDTO.RestauranteId = restauranteId;
            await _service.Inserir(itemDTO);
            return Ok("Item registrado com sucesso!");
        }

        [HttpGet("aba/{abaCardapioId}")]
        public async Task<ActionResult<IEnumerable<ItemCardapioResponse>>> ListarPorAbaCardapio(int abaCardapioId)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não possui itens de cardápio.");

            var itensDTO = await _service.BuscarPorAbaCardapioId(abaCardapioId, restauranteId);
            return Ok(_mapper.Map<IEnumerable<ItemCardapioResponse>>(itensDTO));
        }

        [HttpPut("{itemCardapioId}")]
        public async Task<ActionResult> Editar(int itemCardapioId, ItemCardapioBase itemCardapio)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode editar itens.");

            var itemCardapioDTO = _mapper.Map<ItemCardapioDTO>(itemCardapio);
            itemCardapioDTO.RestauranteId = restauranteId;
            itemCardapioDTO.Id = itemCardapioId;

            await _service.Alterar(itemCardapioDTO);
            return Ok("Item editado com sucesso!");
        }

        [HttpPut("aba/{abaCardapioId}/ordenacao")]
        public async Task<ActionResult> SalvarOrdenacao(int[] itemIds, int abaCardapioId)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode editar a ordenação dos itens.");

            await _service.SalvarOrdenacao(itemIds, abaCardapioId, restauranteId);
            return Ok("Ordenação salva com sucesso!");
        }

        [HttpPut("inativar/{itemCardapioId}")]
        public async Task<ActionResult> Inativar(int itemCardapioId)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode inativar itens de cardápio.");

            await _service.Inativar(itemCardapioId, restauranteId);
            return Ok("Item inativado com sucesso!");
        }

        [HttpPut("ativar/{itemCardapioId}")]
        public async Task<ActionResult> Ativar(int itemCardapioId)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode ativar itens de cardápio.");

            await _service.Ativar(itemCardapioId, restauranteId);
            return Ok("Item ativado com sucesso!");
        }

        [HttpDelete("{itemCardapioId}")]
        public async Task<ActionResult> Excluir(int itemCardapioId)
        {
            var restauranteId = int.Parse(User.FindFirst("id").Value);
            if (restauranteId == 1)
                return Unauthorized("O usuário administrador não pode excluir itens de cardápio.");

            await _service.Excluir(itemCardapioId, restauranteId);
            return Ok("Item excluido com sucesso!");
        }
    }
}
