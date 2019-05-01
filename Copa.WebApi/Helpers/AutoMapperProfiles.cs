using AutoMapper;
using Copa.Domain;
using Copa.WebApi.Dtos;

namespace Copa.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Selecao,SelecaoDto>().ReverseMap();
            CreateMap<Chave,ChaveDto>().ReverseMap();
        }
    }
}