using System;
using System.Collections.Generic;
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


        public Task<List<Quiz>> GetAllQuizWithFilters(string subject, int level)
        {
            throw new NotImplementedException();
        }
    }
}
