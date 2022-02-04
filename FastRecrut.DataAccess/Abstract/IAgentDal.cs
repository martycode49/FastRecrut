using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Entities.Concrete;
using FastRecrut.Entities.Concrete;
using FastRecrut.Core.DataAccess.Abstract;

namespace FastRecrut.DataAccess.Abstract
{
    public interface IAgentDal: IEntityRepository<Agent>
    {
        // contrats spécifiques pour Agent
        List<OperationClaim> GetClaims(Agent agent); // login Management
    }
}
