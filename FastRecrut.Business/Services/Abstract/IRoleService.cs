using System.Collections.Generic;
using System.Threading.Tasks;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IRoleService
    {
        Task<Role> GetRoleByIdUser(int id);
        void Create(Role role);
        void Update(Role role);
        void Delete(int id);
        Task<List<Role>> GetAllRole();
    }
}
