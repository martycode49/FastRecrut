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
        private EfAgentDal _efAgentDal;
        private EfRoleDal _efRoleDal;
        //private IAgentParticipantDal _AgentParticipantDal;
        private EfParticipantDataDal _ParticipantDataDal;
        private EfQuizDal _efQuizDal;

        public UnitOfWork(FastRecrutDbContext context)
        {
            this._context = context;
        }

        public IAgentDal AgentDal =>  _efAgentDal = _efAgentDal ?? new EfAgentDal(_context);

        public IRoleDal RoleDal => _efRoleDal = _efRoleDal ?? new EfRoleDal(_context);

        //public IAgentParticipantDal AgentParticipantDal => _AgentParticipantDal = _AgentParticipantDal ?? new EfAgentParticipantDal(_context);

        public IParticipantDataDal ParticipantDataDal => _ParticipantDataDal = _ParticipantDataDal ?? new EfParticipantDataDal(_context);

        public IQuizDal QuizDal => _efQuizDal = _efQuizDal ?? new EfQuizDal(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
