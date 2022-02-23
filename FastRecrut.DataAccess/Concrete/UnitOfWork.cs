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
        private EfAgentParticipantDal _efAgentParticipantDal;
        private EfParticipantDataDal _efParticipantDataDal;
        private EfQuizDal _efQuizDal;

        public UnitOfWork(FastRecrutDbContext context)
        {
            this._context = context;
        }

        public IAgentDal AgentDal =>  _efAgentDal = _efAgentDal ?? new EfAgentDal(_context);

        public IRoleDal RoleDal => _efRoleDal = _efRoleDal ?? new EfRoleDal(_context);

        public IParticipantDataDal ParticipantDataDal => _efParticipantDataDal = _efParticipantDataDal ?? new EfParticipantDataDal(_context);

        public IQuizDal QuizDal => _efQuizDal = _efQuizDal ?? new EfQuizDal(_context);

        public IAgentParticipantDal AgentParticipantDal => _efAgentParticipantDal = _efAgentParticipantDal ?? new EfAgentParticipantDal(_context);


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
