using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRecrut.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IAgentDal AgentDal { get; }
        IRoleDal RoleDal { get; }
        IAgentParticipantDal AgentParticipantDal { get; }
        IParticipantDataDal ParticipantDataDal { get; }
        IQuizDal QuizDal { get; }

        Task<int> CommitAsync();

        void Commit();
    }
}
