using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Services.Abstract;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IParticipantDataService : IService<ParticipantData>
    {
        // Specific contract for this entity 
        Task<List<ParticipantData>> GetAllParticipantDataWithAgentIDParticipantID(int agent, int participant);
        Task<List<ParticipantData>> GetAllParticipantDataWithParticipantId(int participant);
    }
}
