using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using FastRecrut.Core.Entities.Concrete;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IAgentService
    {
        List<OperationClaim> GetClaims(Agent agent);
        void ADD(Agent agent);
        Agent GetByMail(string email);
        IDataResult<Agent> GetLastUser();
        IDataResult<List<Agent>> GetAll();
        IDataResult<Agent> GetById(int id);
        IResult Add(Agent agent);
        IResult Update(Agent agent);
        IResult Delete(Agent agent);

        // Used with Dto
        AgentDetailDto GetByEmailDto(string email);
        List<AgentDetailDto> GetAgentDetails();
        List<AgentDetailDto> GetAgentDetailById(int agentId);
        
        
        
    }
}
