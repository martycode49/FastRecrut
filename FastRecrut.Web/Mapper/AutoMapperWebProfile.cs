using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Web.Models;
using FastRecrut.Web.ViewModels;

namespace FastRecrut.Web.Mapper
{
    public class AutoMapperWebProfile : AutoMapper.Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<User, AgentViewModel>();
            CreateMap<AgentViewModel, User>();//Reverse mapping

            CreateMap<Quiz, QuizViewModel>();
            CreateMap<QuizViewModel, Quiz>();
        }
    }
}
