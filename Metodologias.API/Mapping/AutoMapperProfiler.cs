using AutoMapper;
using Metodologias.Infrastracture.Entities;
using Metodologias.Infrastracture.Models.Sinals;

namespace Metodologias.API.Mapping
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Sinal, SinalListDTO>();
        }
    }
}
