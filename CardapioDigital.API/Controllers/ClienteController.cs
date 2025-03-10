using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Infra.Ioc.Models.Base;
using CardapioDigital.Infra.Ioc.Models.Response.Cliente;
using CardapioDigital.Util.Extensions;
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
        public async Task<ActionResult<IEnumerable<ClienteResponse>>> ListarTodos()
        {
            var clientesDTO = await _service.ListarTodos();
            foreach (var cliente in clientesDTO)
            {
                cliente.Cpf = cliente.Cpf.FormatarCpf();
                cliente.Contato = cliente.Contato.InserirMascaraTelefone();
            }

            return Ok(_mapper.Map<IEnumerable<ClienteResponse>>(clientesDTO));
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<ClienteResponse>> BuscarPorCpf(string cpf)
        {
            cpf = cpf.RemoverCaracteresNaoNumericos();
            if (!cpf.ValidarCpf())
                return BadRequest("CPF inválido.");

            var clienteDTO = await _service.BuscarClientePorCpf(cpf);
            if (clienteDTO == null)
                return NotFound("Cliente não encontrado.");

            clienteDTO.Cpf = clienteDTO.Cpf.FormatarCpf();
            clienteDTO.Contato = clienteDTO.Contato.InserirMascaraTelefone();

            return Ok(_mapper.Map<ClienteResponse>(clienteDTO));
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(ClienteBase cliente)
        {
            cliente.Cpf = cliente.Cpf.RemoverCaracteresNaoNumericos();
            if (!cliente.Cpf.ValidarCpf())
                return BadRequest("CPF inválido.");

            cliente.Contato = cliente.Contato.RemoverCaracteresNaoNumericos();
            if (!cliente.Contato.ValidarTelefone())
                return BadRequest("Contato inválido.");

            if (cliente.DataNascimento > DateOnly.FromDateTime(DateTime.Now))
                return BadRequest("Data de Nascimento não pode ser maior que a data atual.");

            await _service.Inserir(_mapper.Map<ClienteDTO>(cliente));
            return Ok("Cliente salvo com sucesso!");
        }

        [HttpPut("{clienteId}")]
        public async Task<ActionResult> Editar(int clienteId, ClienteBase cliente)
        {
            cliente.Cpf = cliente.Cpf.RemoverCaracteresNaoNumericos();
            if (!cliente.Cpf.ValidarCpf())
                return BadRequest("CPF inválido.");

            cliente.Contato = cliente.Contato.RemoverCaracteresNaoNumericos();
            if (!cliente.Contato.ValidarTelefone())
                return BadRequest("Contato inválido.");

            if (cliente.DataNascimento > DateOnly.FromDateTime(DateTime.Now))
                return BadRequest("Data de Nascimento não pode ser maior que a data atual.");

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
            clienteDTO.Id = clienteId;

            await _service.Alterar(clienteDTO);
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
