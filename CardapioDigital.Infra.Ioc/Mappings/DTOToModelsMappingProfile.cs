using AutoMapper;
using CardapioDigital.Infra.Ioc.Models.Base;
using CardapioDigital.Infra.Ioc.Models.Request.Restaurante;
using CardapioDigital.API.Models.Response.Restaurante;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Infra.Ioc.Models.Response.Cliente;
using CardapioDigital.Domain.Entities;
using CardapioDigital.Util.Enums;

namespace CardapioDigital.Infra.Ioc.Mappings
{
    public class DTOToModelsMappingProfile : Profile
    {
        public DTOToModelsMappingProfile()
        {
            CreateMap<RestauranteBase, RestauranteDTO>();
            CreateMap<RestauranteCadastrar, RestauranteDTO>();
            CreateMap<RestauranteDTO, RestauranteResponse>();
            CreateMap<RestauranteAlterarSenha, RestauranteDTO>()
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.NovaSenha));
            CreateMap<Restaurante, RestauranteDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (eStatusRestaurante)src.Excluido));

            CreateMap<ClienteBase, ClienteDTO>();
            CreateMap<ClienteDTO, ClienteResponse>();
        }
    }
}
