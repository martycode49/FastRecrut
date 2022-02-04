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
        public List<OperationClaim> GetClaims(Agent agent)
        {
            return _agentDal.GetClaims(agent);
        }

        public void ADD(Agent agent)
        {
            _agentDal.Add(agent);
        }
        
        public Agent GetByMail(string email)
        {
            return _agentDal.Get(u => u.Email == email);
        }

        public IDataResult<Agent> GetById(int id)
        {
            return new SuccessDataResult<Agent>(_agentDal.Get(user => user.Id == id));
        }

        public IResult Add(Agent agent)
        {
            _agentDal.Add(agent);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Update(Agent agent)
        {
            _agentDal.Update(agent);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(Agent agent)
        {
            _agentDal.Delete(agent);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<Agent> GetLastUser()
        {
            var lastUser = _agentDal.GetAll().LastOrDefault();
            return new SuccessDataResult<Agent>(lastUser);
        }

        IDataResult<List<Agent>> IAgentService.GetAll()
        {
            var getAll = _agentDal.GetAll();
            return new SuccessDataResult<List<Agent>>(getAll);
        }


        // Used for Dtos


        public AgentDetailDto GetByEmailDto(string email)
        {
            throw new NotImplementedException();
        }

        List<AgentDetailDto> IAgentService.GetAgentDetails()
        {
            throw new NotImplementedException();
        }

        List<AgentDetailDto> IAgentService.GetAgentDetailById(int agentId)
        {
            throw new NotImplementedException();
        }
    }
}
