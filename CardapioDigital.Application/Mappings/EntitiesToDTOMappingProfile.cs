using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Domain.Entities;

namespace CardapioDigital.Application.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile() 
        { 
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Restaurante, RestauranteDTO>().ReverseMap();
            CreateMap<RestauranteItemCardapio, ItemCardapioDTO>().ReverseMap();
        }
    }
}
