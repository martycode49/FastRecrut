using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRecrut.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IAgentDal AgentDal { get; }
        IParticipantDal ParticipantDal { get; }

        IAgentParticipantDal AgentParticipantDal { get; }
        
        IParticipantDataDal ParticipantDataDal { get; }

        IQuizDal QuizDal { get; }
        Task CommitAsync();
        void Commit();
    }
}
