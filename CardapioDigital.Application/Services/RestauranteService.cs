using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CardapioDigital.Application.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly IRestauranteRepository _repository;
        private readonly IMapper _mapper;

        public RestauranteService(IRestauranteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Alterar(RestauranteDTO restauranteDTO)
        {
            var restauranteExistente = await _repository.BuscarPorId(restauranteDTO.Id);
            if (restauranteExistente == null)
                throw new Exception("Restaurante não encontrado.");

            var restauranteSameEmail = await _repository.BuscarPorEmail(restauranteDTO.Email);
            if (restauranteSameEmail != null)
            {
                if (restauranteExistente.Id != restauranteSameEmail.Id)
                    throw new Exception("O E-mail informado já existe, tente outro E-mail.");
            }

            restauranteExistente.Nome = restauranteDTO.Nome;
            restauranteExistente.Email = restauranteDTO.Email;

            await _repository.Alterar(restauranteExistente);
        }

        public async Task AlterarSenha(RestauranteDTO restauranteDTO)
        {
            var restauranteExistente = await _repository.BuscarPorId(restauranteDTO.Id);

            if (restauranteExistente == null)
                throw new Exception("Restaurante não encontrado.");

            using var hmac = new HMACSHA512();
            restauranteExistente.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(restauranteDTO.Senha));
            restauranteExistente.PasswordSalt = hmac.Key;

            await _repository.Alterar(restauranteExistente);
        }

        public async Task<RestauranteDTO?> BuscarPorEmail(string email)
        {
            var restaurante = await _repository.BuscarPorEmail(email);
            return _mapper.Map<RestauranteDTO>(restaurante);
        }

        public async Task<RestauranteDTO?> BuscarPorId(int restauranteId)
        {
            var restaurante = await _repository.BuscarPorId(restauranteId);
            return _mapper.Map<RestauranteDTO>(restaurante);
        }

        public async Task Inativar(int restauranteId)
        {
            var restaurante = await _repository.BuscarPorIdWithExcluidos(restauranteId) ?? throw new Exception("Restaurante não encontrado.");
            restaurante.Excluido = 1;
            await _repository.Alterar(restaurante);
        }

        public async Task Ativar(int restauranteId)
        {
            var restaurante = await _repository.BuscarPorIdWithExcluidos(restauranteId) ?? throw new Exception("Restaurante não encontrado.");
            restaurante.Excluido = 0;
            await _repository.Alterar(restaurante);
        }

        public async Task Inserir(RestauranteDTO restauranteDTO)
        {
            var restaurante = _mapper.Map<Restaurante>(restauranteDTO);

            var restauranteExistente = await _repository.BuscarPorEmail(restauranteDTO.Email);
            if (restauranteExistente != null)
                throw new Exception("O E-mail informado já existe, tente outro E-mail.");

            using var hmac = new HMACSHA512();
            restaurante.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(restauranteDTO.Senha));
            restaurante.PasswordSalt = hmac.Key;

            await _repository.Inserir(restaurante);
        }

        public async Task<IEnumerable<RestauranteDTO>> ListarTodos()
        {
            var restaurante = await _repository.ListarTodos();
            return _mapper.Map<IEnumerable<RestauranteDTO>>(restaurante);
        }
    }
}
