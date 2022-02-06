using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;

namespace FastRecrut.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FastRecrutDbContext _context;
        private IAgentDal _agentDal;
        //private IAgentParticipantDal _AgentParticipantDal;
        //private IParticipantDataDal _ParticipantDataDal;
        //private IQuizDal _QuizDal;

        public UnitOfWork(FastRecrutDbContext context)
        {
            this._context = context;
        }

        public IAgentDal AgentDal =>  _agentDal = _agentDal ?? new EfAgentDal(_context);


        //public IAgentParticipantDal AgentParticipantDal => _AgentParticipantDal = _AgentParticipantDal ?? new EfAgentParticipantDal(_context);

        //public IParticipantDataDal ParticipantDataDal => throw new NotImplementedException();

        //public IQuizDal QuizDal => throw new NotImplementedException();


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
