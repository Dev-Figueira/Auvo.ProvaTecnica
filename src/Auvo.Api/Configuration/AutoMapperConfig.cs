using AutoMapper;
using Auvo.Api.Dto;
using Auvo.Busness.Models;

namespace Auvo.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Ponto, PontoDto>().ReverseMap();
            CreateMap<Registro, RegistroDto>().ReverseMap();
        }
    }
}
