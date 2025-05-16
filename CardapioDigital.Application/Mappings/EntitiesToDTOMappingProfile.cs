using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Util.Enums;

namespace CardapioDigital.Application.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile() 
        { 
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteCompletoDTO>().ReverseMap();
            CreateMap<RestauranteItemCardapio, ItemCardapioDTO>().ReverseMap();
            CreateMap<RestauranteAbaCardapio, AbaCardapioDTO>().ReverseMap();
            CreateMap<AtendimentoPedidoCliente, PedidoClienteDTO>().ReverseMap();
            CreateMap<RestricaoAlimentar, RestricaoAlimentarDTO>().ReverseMap();
            CreateMap<RestricaoAlimentarCliente, RestricaoAlimentarClienteDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<TagCliente, TagClienteDTO>().ReverseMap();

            CreateMap<Restaurante, RestauranteDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (eStatusRestaurante)src.Excluido));
        }
    }
}
