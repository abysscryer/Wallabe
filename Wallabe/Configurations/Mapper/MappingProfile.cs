using AutoMapper;
using Wallabe.Domains;
using Wallabe.Models;

namespace Wallabe.Configurations.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Play, PlayViewModel>();
        }
    }
}
