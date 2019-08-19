using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wallabe.Domains;
using Wallabe.Models;

namespace Wallabe.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Crane, CraneViewModel>();
            CreateMap<Doll, DollViewModel>();

            // hit/try * 100
            CreateMap<Rank, RankViewModel>()
                .ForMember(des => des.Rate,
                    opt => opt.MapFrom(src => (src.Hit / src.Try) * 100));
        }
            
    }
}
