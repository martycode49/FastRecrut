using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.DataAccess.Concrete.EntityFramework
{
    public class EfQuizDal : EfEntityRepositoryBase<EfQuizDal, FastRecrutDbContext>, IQuizDal
    {
        private FastRecrutDbContext _FastRecrutDbContext
        {
            get => _context as FastRecrutDbContext;
        }
        public EfQuizDal(FastRecrutDbContext dbContext) : base(dbContext)
        {

        }

        public void Create(Quiz quiz)
        {
            var addedEntity =  _FastRecrutDbContext.Entry(quiz);
            addedEntity.State = EntityState.Added;
        }

        public void Delete(int id)
        {
            var quiz = _FastRecrutDbContext.Quizzes.Find(id);
            if (quiz != null)
            {
                _FastRecrutDbContext.Quizzes.Remove(quiz);
            }
        }

        public async Task<List<Quiz>> GetAllQuiz()
        {
            return await _FastRecrutDbContext.Quizzes
             .ToListAsync();
        }

        public async Task<List<Quiz>> GetAllQuizWithFilters(string subject, int level)
        {
            return await _FastRecrutDbContext.Quizzes
                   .Where(q => q.Level == level && q.SubSubject == subject).ToListAsync();
        }

        public async Task<Quiz> GetQuizById(int id)
        {
            return await _FastRecrutDbContext.Quizzes
                    .Where(q => q.Id == id)
                    .FirstOrDefaultAsync();
        }

        public void Update(Quiz quiz)
        {
            _FastRecrutDbContext.Quizzes.Update(quiz).State = EntityState.Modified;
        }
    }
}
