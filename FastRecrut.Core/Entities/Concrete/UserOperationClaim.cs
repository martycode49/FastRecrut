using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
