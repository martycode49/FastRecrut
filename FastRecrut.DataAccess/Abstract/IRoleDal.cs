using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.DataAccess.Abstract
{
    public interface IRoleDal
    {
        // contrats spécifiques pour Role

        void Create(Role role);
        void Update(Role role);
        Task<Role> GetRoleByIdAsync(int id);
        void Delete(int id);
    }
}
