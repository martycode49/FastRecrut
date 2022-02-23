using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.DataAccess.Concrete.EntityFramework
{
    public class EfAgentParticipantDal : EfEntityRepositoryBase<EfAgentParticipantDal, FastRecrutDbContext>, IAgentParticipantDal
    {
        private FastRecrutDbContext _FastRecrutDbContext
        {
            get => _context as FastRecrutDbContext;
        }
        public EfAgentParticipantDal(FastRecrutDbContext dbContext) : base(dbContext)
        {

        }

        public void Create(AgentParticipant agpart)
        {
            var addedEntity = _FastRecrutDbContext.Entry(agpart);
            addedEntity.State = EntityState.Added;
        }

        public void Delete(int id)
        {
            var agpart = _FastRecrutDbContext.AgentParticipants.Find(id);
            if (agpart != null)
            {
                _FastRecrutDbContext.AgentParticipants.Remove(agpart);
            }
        }

        public async Task<List<AgentParticipant>> GetAllAgentPart()
        {
            return await _FastRecrutDbContext.AgentParticipants
             .ToListAsync();
        }


        public async Task<AgentParticipant> GetAgentPartById(int id)
        {
            return await _FastRecrutDbContext.AgentParticipants
                    .Where(q => q.Id == id)
                    .FirstOrDefaultAsync();
        }

        public void Update(AgentParticipant agpart)
        {
            _FastRecrutDbContext.AgentParticipants.Update(agpart).State = EntityState.Modified;
        }

    }
}
