using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Core.DataAccess.Abstract;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.Business.Services.Concrete
{
    public class QuizManager : ManagerBase<Quiz>, IQuizService
    {
        public QuizManager(IUnitOfWork unitOfWork, IEntityRepository<Quiz> repository) : base(unitOfWork, repository)
        { }


        public async Task<List<Quiz>> GetAllQuizWithFilters(string subject, int level)
        {
            var quizzes = await GetAllAsync();
            return quizzes.Where(q => q.Level == level && q.Subject == subject).ToList();
        }

        public async Task<List<Quiz>> GetAllQuizWithSubject(string subject)
        {
            var quizzes = await GetAllAsync();
            return quizzes.Where(q => q.Subject == subject).ToList();
        }
    }
}
