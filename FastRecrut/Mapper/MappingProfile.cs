using AutoMapper;
using FastRecrut.Api.Resources;
using FastRecrut.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain(base de donnée )  vers Resource
            //CreateMap<Music, MusicResource>();
            //CreateMap<Artist, ArtistResource>();
            //CreateMap<Music, SaveMusicResource>();
            //CreateMap<Artist, SaveArtistResource>();
            CreateMap<Agent, AgentResource>();


            // Resources vers Domain ou la base de données

            //CreateMap<MusicResource,Music >();
            //CreateMap<ArtistResource,Artist>();
            //CreateMap<SaveMusicResource,Music>();
            //CreateMap<SaveArtistResource,Artist >();
            //CreateMap<ComposerResourse,Composer >();
            //CreateMap<SaveComposerResource,Composer >();
            CreateMap<AgentResource,Agent >();





        }

    }
}
