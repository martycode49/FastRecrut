using System.Collections.Generic;
using System.Threading.Tasks;
using FastRecrut.Core.Services.Abstract;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IAgentParticipantService : IService<AgentParticipant>
    {
        // Specific contract for this entity 

        Task<List<AgentParticipant>> GetAllAgentParticipantWithAgentId(int id);
    }
}
