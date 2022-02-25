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
    public class AgentParticipantManager : ManagerBase<AgentParticipant>, IAgentParticipantService
    {
        public AgentParticipantManager(IUnitOfWork unitOfWork, IEntityRepository<AgentParticipant> repository) : base(unitOfWork, repository)
        { }

        public async Task<List<AgentParticipant>> GetAllAgentParticipantWithAgentId(int id)
        {
            var ap = await GetAllAsync();
            return ap.Where(ap => ap.AgentId == id).ToList();
        }
    }
}
