using System.Collections.Generic;
using System.Threading.Tasks;
using FastRecrut.Core.Services.Abstract;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IQuizService : IService<Quiz>
    {   
        // Specific contract for this entity 
        Task<List<Quiz>> GetAllQuizWithFilters(string subject, int level);
        Task<List<Quiz>> GetAllQuizWithSubject(string subject);
    }
}
