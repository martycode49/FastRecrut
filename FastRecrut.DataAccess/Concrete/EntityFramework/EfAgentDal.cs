using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
