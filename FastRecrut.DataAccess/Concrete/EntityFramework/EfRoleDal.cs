using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.DataAccess.Abstract;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FastRecrut.DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<EfRoleDal, FastRecrutDbContext>, IRoleDal
    {
        private FastRecrutDbContext _FastRecrutDbContext
        {
            get => _context as FastRecrutDbContext;
        }
        public EfRoleDal(FastRecrutDbContext dbContext) : base(dbContext)
        {
        }

        public void Create(Role role)
        {
            var addedEntity = _FastRecrutDbContext.Entry(role);
            addedEntity.State = EntityState.Added;
        }

        public void Update(Role role)
        {
            var updatedEntity = _FastRecrutDbContext.Entry(role);
            updatedEntity.State = EntityState.Modified;
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _FastRecrutDbContext.Roles
                    .Where(role => role.UserId == id)
                    .FirstOrDefaultAsync();
        }

        public void Delete(int id)
        {
            var role = _FastRecrutDbContext.Roles.Find(id);
            if (role != null)
            {
                _FastRecrutDbContext.Roles.Remove(role);
            }
        }
    }
}
