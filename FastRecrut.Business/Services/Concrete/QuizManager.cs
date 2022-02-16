using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async void Create(Quiz quiz)
        {
            //await _UnitOfWork.QuizDal.
            await _UnitOfWork.CommitAsync();
        }

        public void Delete(int id)
        {
            //var quiz = _UnitOfWork.QuizDal.Find(id);
            //if (quiz != null)
            //{
            //    _UnitOfWork.QuizDal.Remove(quiz);
            //}
        }

        public Task<List<Quiz>> GetAllQuiz()
        {
            throw new NotImplementedException();
        }

        public Task<List<Quiz>> GetAllQuizWithFilters(string subject, int level)
        {
            throw new NotImplementedException();
        }

        public Task<Quiz> GetQuizById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Quiz quiz)
        {
            throw new NotImplementedException();
        }
    }
}
