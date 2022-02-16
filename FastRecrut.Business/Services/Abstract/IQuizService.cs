using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IQuizService
    {
        Task<Quiz> GetQuizById(int id);
        void Create(Quiz quiz);
        void Update(Quiz quiz);
        void Delete(int id);
        Task<List<Quiz>> GetAllQuiz();
        Task<List<Quiz>> GetAllQuizWithFilters(string subject, int level);
    }
}
