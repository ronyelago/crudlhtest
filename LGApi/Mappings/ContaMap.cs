using AutoMapper;
using LGApi.Entities;
using LGApi.Models;

namespace LGApi.Mappings;

public class ContaMap : Profile
{
    public ContaMap()
    {
        CreateMap<ContaModel, Conta>().ReverseMap();
    }
}