using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Core.DataAccess.Abstract;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.Entities.Concrete;

namespace FastRecrut.Business.Services.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal, IUnitOfWork unitOfWork)
        {
            _roleDal = roleDal;
            _unitOfWork = unitOfWork;
        }
        public void Create(Role role)
        {
            _unitOfWork.RoleDal.Create(role);

            _unitOfWork.CommitAsync();
        }

        public void Delete(int id)
        {
            _unitOfWork.RoleDal.Delete(id);
            _unitOfWork.CommitAsync();
        }

        public async Task<Role> GetRoleByIdUser(int id)
        {
            return await _unitOfWork.RoleDal.GetRoleByIdAsync(id);
        }

        public void Update(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetAllRole()
        {
            return await _unitOfWork.RoleDal.GetAllRoleAsync();
        }
    }
}
