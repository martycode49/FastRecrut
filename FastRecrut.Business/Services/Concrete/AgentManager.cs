using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Concrete
{
    public class AgentManager : IAgentService
    {
        IAgentDal _agentDal;
        private readonly IUnitOfWork _unitOfWork;

        public AgentManager(IAgentDal agentDal, IUnitOfWork unitOfWork)
        {
            _agentDal = agentDal;
            _unitOfWork = unitOfWork;
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

        // Used for By MyMusic project
        public async Task<Agent> Authenticate(string username, string password)
        {
            return await _unitOfWork.AgentDal.Authenticate(username, password);
        }

        public async Task<IEnumerable<Agent>> GetAll()
        {
            return await _unitOfWork.AgentDal.GetAllAgentAsync();
        }

        public async Task<Agent> Create(Agent agent, string password)
        {
            await _unitOfWork.AgentDal.Create(agent, password);

            await _unitOfWork.CommitAsync();
            return agent;
        }

        public void Delete(int id)
        {
            _unitOfWork.AgentDal.Delete(id);
            _unitOfWork.CommitAsync();
        }

        public void Update(Agent agent, string password = null)
        {
            _unitOfWork.AgentDal.Update(agent, password);
            _unitOfWork.CommitAsync();
        }

        async Task<Agent> IAgentService.GetByIdAgent(int id)
        {
            return await _unitOfWork.AgentDal.GetWithAgentsByIdAsync(id);
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
