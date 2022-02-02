using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.DataAccess.Abstract;

namespace FastRecrut.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAgentDal AgentDal => throw new NotImplementedException();

        public IParticipantDal ParticipantDal => throw new NotImplementedException();

        public IAgentParticipantDal AgentParticipantDal => throw new NotImplementedException();

        public IParticipantDataDal ParticipantDataDal => throw new NotImplementedException();

        public IQuizDal QuizDal => throw new NotImplementedException();

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
