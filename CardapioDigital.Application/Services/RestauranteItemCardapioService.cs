using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Util.Extensions;

namespace CardapioDigital.Application.Services
{
    public class RestauranteItemCardapioService : IRestauranteItemCardapioService
    {
        private readonly IRestauranteItemCardapioRepository _repository;
        private readonly IRestauranteAbaCardapioService _abaCardapioService;
        private readonly ITagItemCardapioService _tagItemCardapioService;
        private readonly IMapper _mapper;

        public RestauranteItemCardapioService(IRestauranteItemCardapioRepository repository,
            IRestauranteAbaCardapioService abaCardapioService,
            ITagItemCardapioService tagItemCardapioService,
            IMapper mapper)
        {
            _repository = repository;
            _abaCardapioService = abaCardapioService;
            _tagItemCardapioService = tagItemCardapioService;
            _mapper = mapper;
        }

        public async Task Inserir(ItemCardapioDTO itemDTO)
        {
            var item = _mapper.Map<RestauranteItemCardapio>(itemDTO);
            var abaCardapioExistente = await _abaCardapioService.BuscarPorId(item.AbaCardapioId);

            if (abaCardapioExistente == null)
                throw new Exception("A aba informada não existe.");
            else if (abaCardapioExistente.RestauranteId != itemDTO.RestauranteId)
                throw new Exception("A aba informada não existe.");

            item.Disponivel = 1;
            item.Imagem = itemDTO.ImagemBase64.ConvertBase64ToByteArray();
            item.Ordenacao = await _repository.BuscarProximaOrdenacao(item.AbaCardapioId);
            await _repository.Inserir(item);

            await _tagItemCardapioService.CadastrarTagsItem(_mapper.Map<ItemCardapioDTO>(item));
        }

        public async Task Alterar(ItemCardapioDTO itemDTO)
        {
            var itemEntity = await _repository.BuscarPorId(itemDTO.Id);
            var abaCardapioExistente = await _abaCardapioService.BuscarPorId(itemDTO.AbaCardapioId);

            if (abaCardapioExistente == null)
                throw new Exception("A aba informada não existe.");
            else if (abaCardapioExistente.RestauranteId != itemDTO.RestauranteId)
                throw new Exception("A aba informada não existe.");
            else if (itemEntity == null)
                throw new Exception("O item informado não existe.");
            else if (abaCardapioExistente.RestauranteId != itemDTO.RestauranteId)
                throw new Exception("O item informado não existe.");

            var item = _mapper.Map<RestauranteItemCardapio>(itemDTO);
            item.Disponivel = itemEntity.Disponivel;
            item.Imagem = itemDTO.ImagemBase64.ConvertBase64ToByteArray();
            item.Ordenacao = itemEntity.Ordenacao;
            item.Id = 0;

            await Excluir(itemDTO.Id, itemDTO.RestauranteId);
            await _repository.Inserir(item);

            await _tagItemCardapioService.CadastrarTagsItem(_mapper.Map<ItemCardapioDTO>(item));
        }

        public async Task<IEnumerable<ItemCardapioDTO>> BuscarPorAbaCardapioId(int abaCardapioId, int restauranteId)
        {
            var abaCardapioExistente = await _abaCardapioService.BuscarPorId(abaCardapioId);
            if (abaCardapioExistente == null)
                throw new Exception("A aba informada não existe.");
            else if (abaCardapioExistente.RestauranteId != restauranteId)
                throw new Exception("A aba informada não existe.");

            var itens = await _repository.ListarPorAbaId(abaCardapioId);

            var itensDTO = new List<ItemCardapioDTO>();
            foreach (var item in itens)
            {
                var itemDTO = _mapper.Map<ItemCardapioDTO>(item);
                if (item.Imagem.Length > 0)
                    itemDTO.ImagemBase64 = item.Imagem.ConvertToBase64WithMimeType();

                foreach (var tagItem in item.TagItemCardapios)
                    itemDTO.Tags.Add(tagItem.Tag.Texto);

                itensDTO.Add(itemDTO);
            }

            return itensDTO;
        }

        public async Task Inativar(int itemCardapioId, int restauranteId)
        {
            var itemCardapioExistente = await _repository.BuscarPorId(itemCardapioId);
            if (itemCardapioExistente == null)
                throw new Exception("O item informado não existe.");
            else if (itemCardapioExistente.RestauranteId != restauranteId)
                throw new Exception("O item informado não existe.");

            itemCardapioExistente.Disponivel = 0;
            await _repository.Alterar(itemCardapioExistente);
        }

        public async Task Ativar(int itemCardapioId, int restauranteId)
        {
            var itemCardapioExistente = await _repository.BuscarPorId(itemCardapioId);
            if (itemCardapioExistente == null)
                throw new Exception("O item informado não existe.");
            else if (itemCardapioExistente.RestauranteId != restauranteId)
                throw new Exception("O item informado não existe.");

            itemCardapioExistente.Disponivel = 1;
            await _repository.Alterar(itemCardapioExistente);
        }

        public async Task Excluir(int itemCardapioId, int restauranteId)
        {
            var itemCardapioExistente = await _repository.BuscarPorId(itemCardapioId);
            if (itemCardapioExistente == null)
                throw new Exception("O item informado não existe.");
            else if (itemCardapioExistente.RestauranteId != restauranteId)
                throw new Exception("O item informado não existe.");

            itemCardapioExistente.Excluido = 1;
            await _repository.Alterar(itemCardapioExistente);
        }

        public async Task SalvarOrdenacao(int[] itemIds, int abaCardapioId, int restauranteId)
        {
            var itens = await _repository.ListarPorAbaId(abaCardapioId);
            for (int i = 0; i < itemIds.Length; i++)
            {
                var item = itens.First(x => x.Id == itemIds[i]);
                item.Ordenacao = i + 1;
            }

            await _repository.AlterarRange(itens);
        }
    }
}
