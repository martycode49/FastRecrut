using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Core.Entities.Concrete;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Concrete
{
    public class AgentManager : IAgentService
    {
        IAgentDal _agentDal;

        public AgentManager(IAgentDal agentDal)
        {
            _agentDal = agentDal;
        }

        //[CacheAspect]
        public Task<List<OperationClaim>> GetClaims(Agent agent)
        {
            return _agentDal.GetClaims(agent);
        }

        public IResult Add(Agent agent)
        {
            _agentDal.AddAsync(agent);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(Agent agent)
        {
            _agentDal.Remove(agent);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<AgentDetailDto>> GetAgentDetailById(int agentId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AgentDetailDto>> GetAgentDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Task<List<Agent>>> GetAll()
        {
            var getAll = _agentDal.GetAll();
            return new SuccessDataResult<List<Agent>>(getAll);
        }

        public IDataResult<AgentDetailDto> GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<Agent> GetById(int id)
        {
            return new SuccessDataResult<Agent>(_agentDal.Where(user => user.Id == id));
        }

        public IDataResult<Agent> GetLastUser()
        {
            var lastUser = _agentDal.GetAllAsync().LastOrDefault();
            return new SuccessDataResult<Agent>(lastUser);
        }

        public IResult Update(Agent agent)
        {
            _agentDal.Update(agent);
            return new SuccessResult(Messages.UserUpdated);
        }

        public void ADD(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
