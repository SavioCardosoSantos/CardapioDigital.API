using AutoMapper;
using CardapioDigital.Infra.Ioc.Models.Base;
using CardapioDigital.Infra.Ioc.Models.Request.Restaurante;
using CardapioDigital.Infra.Ioc.Models.Response.Auth;
using CardapioDigital.API.Models.Response.Restaurante;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteService _service;
        private readonly IMapper _mapper;

        public RestauranteController(IRestauranteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ApiToken>> Registrar(RestauranteCadastrar restauranteCadastrar)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            if (userId != 1)
                return Unauthorized("Somente o usuário administrador pode criar novos restaurantes.");

            var restauranteDTO = _mapper.Map<RestauranteDTO>(restauranteCadastrar);
            await _service.Inserir(restauranteDTO);
            return Ok("Restaurante registrado com sucesso!");
        }

        [HttpGet("listar-todos")]
        public async Task<ActionResult<IEnumerable<RestauranteResponse>>> ListarTodos()
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            if (userId != 1)
                return Unauthorized("Somente o usuário administrador pode visualizar todos os restaurantes.");

            var restaurantesDTO = await _service.ListarTodos();
            return Ok(_mapper.Map<IEnumerable<RestauranteResponse>>(restaurantesDTO));
        }

        [HttpPut("{restauranteId}/inativar")]
        public async Task<ActionResult> Inativar(int restauranteId)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            if (userId != 1)
                return Unauthorized("Somente o usuário administrador pode inativar restaurantes.");

            await _service.Inativar(restauranteId);
            return Ok("Restaurante inativado com sucesso!");
        }

        [HttpPut("{restauranteId}/ativar")]
        public async Task<ActionResult> Ativar(int restauranteId)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            if (userId != 1)
                return Unauthorized("Somente o usuário administrador pode ativar restaurantes.");

            await _service.Ativar(restauranteId);
            return Ok("Restaurante ativado com sucesso!");
        }

        [HttpGet("meus-dados")]
        public async Task<ActionResult<RestauranteResponse>> BuscarMeusDados()
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            var restauranteDTO = await _service.BuscarPorId(userId);
            return Ok(_mapper.Map<RestauranteResponse>(restauranteDTO));
        }

        [HttpPut("{restauranteId}")]
        public async Task<ActionResult> Editar(int restauranteId, RestauranteBase restauranteBase)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            if (userId != 1 && userId != restauranteId)
                return Unauthorized("Somente o usuário administrador pode editar outros restaurantes.");

            var restauranteDTO = _mapper.Map<RestauranteDTO>(restauranteBase);
            restauranteDTO.Id = restauranteId;

            await _service.Alterar(restauranteDTO);
            return Ok("Restaurante editado com sucesso!");
        }

        [HttpPut("{restauranteId}/alterar-senha")]
        public async Task<ActionResult> AlterarSenha(int restauranteId, RestauranteAlterarSenha restauranteAlterarSenha)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            if (userId != 1 && userId != restauranteId)
                return Unauthorized("Somente o usuário administrador pode alterar a senha de outros restaurantes.");

            var restauranteDTO = _mapper.Map<RestauranteDTO>(restauranteAlterarSenha);
            restauranteDTO.Id = restauranteId;

            await _service.AlterarSenha(restauranteDTO);
            return Ok("Senha alterada com sucesso!");
        }
    }
}
