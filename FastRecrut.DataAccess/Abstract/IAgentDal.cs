using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Entities.Concrete;
using FastRecrut.Core.DataAccess.Abstract;

namespace FastRecrut.DataAccess.Abstract
{
    public interface IAgentDal
    {
        // contrats spécifiques pour Agent
        
        // login Management
        Task<Agent> Authenticate(string username, string password);
        Task<Agent> Create(Agent agent, string password);
        void Update(Agent agent, string password = null);
        Task<IEnumerable<Agent>> GetAllAgentAsync();
        Task<Agent> GetWithAgentsByIdAsync(int id);
        void Delete(int id);
    }
}
