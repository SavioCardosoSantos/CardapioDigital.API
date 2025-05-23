﻿using AutoMapper;
using CardapioDigital.API.Models.Response.Restaurante;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.DTOs.CardapioCliente;
using CardapioDigital.Infra.Ioc.Models.Base;
using CardapioDigital.Infra.Ioc.Models.Request.Restaurante;
using CardapioDigital.Infra.Ioc.Models.Response.AbaCardapio;
using CardapioDigital.Infra.Ioc.Models.Response.Cliente;
using CardapioDigital.Infra.Ioc.Models.Response.ItemCardapio;

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

            CreateMap<ClienteBase, ClienteDTO>();
            CreateMap<ClienteDTO, ClienteResponse>();

            CreateMap<AbaCardapioBase, AbaCardapioDTO>();
            CreateMap<AbaCardapioDTO, AbaCardapioResponse>();
            CreateMap<AbaCardapioDTO, AbaCardapioClienteResponse>();

            CreateMap<ItemCardapioBase, ItemCardapioDTO>();
            CreateMap<ItemCardapioDTO, ItemCardapioResponse>();
            CreateMap<ItemCardapioDTO, ItemCardapioRanqueado>();
        }
    }
}
