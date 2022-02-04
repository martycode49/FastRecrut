using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.Core.Entities.Concrete;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.DataAccess.Concrete.EntityFramework
{
    public class EfAgentDal : EfEntityRepositoryBase<EfAgentDal,FastRecrutDbContext>, IAgentDal
    {
        private FastRecrutDbContext _FastRecrutDbContext
        {
            get => _context as FastRecrutDbContext;
        }
        public EfAgentDal(FastRecrutDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<OperationClaim>> GetClaims(Agent agent)
        {
            var result = from operationClaim in _FastRecrutDbContext.OperationClaims
                         join userOpeartionClaim in _FastRecrutDbContext.UserOperationClaims
                         on operationClaim.Id equals userOpeartionClaim.OperationClaimId
                         where userOpeartionClaim.AgentId == agent.Id
                         select new OperationClaim
                         {
                             Id = operationClaim.Id,
                             Name = operationClaim.Name
                         };
            return await result.ToListAsync();
        }

        List<OperationClaim> IAgentDal.GetClaims(Agent agent)
        {
            throw new NotImplementedException();
        }

        public Agent Get(Expression<Func<Agent, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Agent> GetAll(Expression<Func<Agent, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Agent entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Agent entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Agent entity)
        {
            throw new NotImplementedException();
        }
    }
}
