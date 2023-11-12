using AutoMapper;
using Challenge_2.Models;

namespace Challenge_2.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Despesas, DespesasDTO>().ReverseMap();
            CreateMap<Receitas, ReceitasDTO>().ReverseMap();
        }
    }
}