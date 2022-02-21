using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.DataAccess.Concrete.EntityFramework
{
    public class EfParticipantDataDal : EfEntityRepositoryBase<EfParticipantDataDal, FastRecrutDbContext>, IParticipantDataDal
    {
        private FastRecrutDbContext _FastRecrutDbContext
        {
            get => _context as FastRecrutDbContext;
        }
        public EfParticipantDataDal(FastRecrutDbContext dbContext) : base(dbContext)
        {}

        public void Create(ParticipantData pData)
        {
            var addedEntity = _FastRecrutDbContext.Entry(pData);
            addedEntity.State = EntityState.Added;
        }

        public void Delete(int id)
        {
            var pData = _FastRecrutDbContext.ParticipantDatas.Find(id);
            if (pData != null)
            {
                _FastRecrutDbContext.ParticipantDatas.Remove(pData);
            }
        }

        public async Task<List<ParticipantData>> GetAllParticipantData()
        {
            return await _FastRecrutDbContext.ParticipantDatas
             .ToListAsync();
        }


        public async Task<ParticipantData> GetParticipantDataById(int id)
        {
            return await _FastRecrutDbContext.ParticipantDatas
                    .Where(q => q.Id == id)
                    .FirstOrDefaultAsync();
        }

        public void Update(ParticipantData pData)
        {
            _FastRecrutDbContext.ParticipantDatas.Update(pData).State = EntityState.Modified;
        }
    }
}
