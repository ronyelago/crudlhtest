using AutoMapper;
using LGApi.Entities;
using LGApi.Models;

namespace LGApi.Mappings;

public class ContaMap : Profile
{
    public ContaMap()
    {
        CreateMap<ContaModel, Conta>()
            .ForMember(dest => dest.DataExpiracao, opt => opt.MapFrom(src => src.DataExpiracao.ToUniversalTime()))
            .ForMember(dest => dest.DataVencimento, opt => opt.MapFrom(src => src.DataVencimento.ToUniversalTime()))
            .ReverseMap();
    }
}