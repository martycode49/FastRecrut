using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Web.ViewModels;

namespace FastRecrut.Web.Services.Abstract
{
    public interface IQuizEditorService
    {
        //CRUD operations

        //Basic repository example used in Repo Controller
        Task<List<QuizViewModel>> GetAllQuizAsync();

    }
}
