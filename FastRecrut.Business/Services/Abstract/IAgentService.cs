using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IAgentService
    {
        IResult Add(Agent agent);
        IResult Delete(Agent agent);
        IResult Update(Agent agent);
        IDataResult<Agent> GetById(int id);
        IDataResult<List<Agent>> GetAll();
        IDataResult<List<AgentDetailDto>> GetAgentDetails();
        IDataResult<List<AgentDetailDto>> GetAgentDetailById(int agentId);
        IDataResult<AgentDetailDto> GetByEmail(string email);
        IDataResult<Agent> GetLastUser();
        void ADD(Agent agent);
    }
}
