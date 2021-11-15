using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using API2.ModelDTOs;
using API2.Persistence.Entities;

namespace Storage.Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MatchEntity, MatchDTO>().ReverseMap();
            CreateMap<PlayerEntity, PlayerDTO>().ReverseMap();
            CreateMap<TeamEntity, TeamDTO>().ReverseMap();
            CreateMap<TeamEntity, TeamDTO>().ForMember(e => e.PlayerList, t => t.MapFrom(d => d.PlayerList)).ReverseMap();

           // CreateMap<TeamEntity, TeamDTO>().IncludeMembers(t => t.PlayerList, d => d.PlayerList).ReverseMap();
            //CreateMap<List<PlayerEntity>, List<PlayerDTO>>().ReverseMap();
        }
    }
}
