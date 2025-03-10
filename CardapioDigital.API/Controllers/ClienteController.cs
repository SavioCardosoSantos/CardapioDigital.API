using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> ListarTodos()
        {
            return Ok(await _service.ListarTodos());
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<ClienteDTO>> BuscarPorCpf(string cpf)
        {
            var cliente = await _service.BuscarClientePorCpf(cpf);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(ClienteDTO cliente)
        {
            await _service.Inserir(cliente);
            return Ok("Cliente salvo com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult> Editar(ClienteDTO cliente)
        {
            await _service.Alterar(cliente);
            return Ok("Cliente editado com sucesso!");
        }

        [HttpDelete("{clienteId}")]
        public async Task<ActionResult> Excluir(int clienteId)
        {
            await _service.Excluir(clienteId);
            return Ok("Cliente excluido com sucesso!");
        }
    }
}
