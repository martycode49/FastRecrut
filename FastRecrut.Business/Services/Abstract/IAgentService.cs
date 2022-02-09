using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IAgentService
    {
        //void ADD(Agent agent);
        //Agent GetByMail(string email);
        //IResult Add(Agent agent);

        // Login Management
        Task<Agent> Authenticate(string username, string password);
        Task<IEnumerable<Agent>> GetAll();
        Task<Agent> GetByIdAgent(int id);
        Task<Agent> Create(Agent agent, string password);
        void Update(Agent agent, string password = null);
        void Delete(int id);

        // Used with Dto
        AgentDetailDto GetByEmailDto(string email);
        List<AgentDetailDto> GetAgentDetails();
        List<AgentDetailDto> GetAgentDetailById(int agentId);
        
        
        
    }
}
