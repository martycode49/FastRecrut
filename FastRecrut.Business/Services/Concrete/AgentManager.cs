using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Core.DataAccess.Abstract;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Concrete
{
    public class AgentManager : ManagerBase<Agent>, IAgentService
    {

        public AgentManager(IUnitOfWork unitOfWork, IEntityRepository<Agent> repository) : base(unitOfWork, repository)
        {
        }
        //public void ADD(Agent agent)
        //{
        //    _UnitOfWork.AgentDal.Add(agent);
        //}
        
        //public Agent GetByMail(string email)
        //{
        //    return _UnitOfWork.AgentDal(u => u.Email == email);
        //}


        //public IResult Add(Agent agent)
        //{
        //    _UnitOfWork.AgentDal.Add(agent);
        //    return new SuccessResult(Messages.UserAdded);
        //}



        // Used for By MyMusic project
        public async Task<Agent> Authenticate(string username, string password)
        {
            return await _UnitOfWork.AgentDal.Authenticate(username, password);
        }

        public async Task<IEnumerable<Agent>> GetAll()
        {
            return await _UnitOfWork.AgentDal.GetAllAgentAsync();
        }

        public async Task<Agent> Create(Agent agent, string password)
        {
            await _UnitOfWork.AgentDal.Create(agent, password);

            await _UnitOfWork.CommitAsync();
            return agent;
        }

        public void Delete(int id)
        {
            _UnitOfWork.AgentDal.Delete(id);
            _UnitOfWork.CommitAsync();
        }

        public void Update(Agent agent, string password = null)
        {
            _UnitOfWork.AgentDal.Update(agent, password);
            _UnitOfWork.CommitAsync();
        }

        async Task<Agent> IAgentService.GetByIdAgent(int id)
        {
            return await _UnitOfWork.AgentDal.GetWithAgentsByIdAsync(id);
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
