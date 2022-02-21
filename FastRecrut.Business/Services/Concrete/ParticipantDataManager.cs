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
    public class ParticipantDataManager : ManagerBase<ParticipantData>, IParticipantDataService
    {
        public ParticipantDataManager(IUnitOfWork unitOfWork, IEntityRepository<ParticipantData> repository) : base(unitOfWork, repository)
        { }

        public async Task<List<ParticipantData>> GetAllParticipantDataWithAgentIDParticipantID(int agentId, int participantId)
        {
            var pdatas = await GetAllAsync();
            return pdatas.Where(q => q.Agents.Id == agentId && q.QuizParticipId == participantId).ToList();
        }

        public async Task<List<ParticipantData>> GetAllParticipantDataWithParticipantId(int participantId)
        {
            var pdatas = await GetAllAsync();
            return pdatas.Where(q => q.QuizParticipId == participantId).ToList();
        }
    }
}
