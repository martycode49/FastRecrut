﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using FastRecrut.Entities.Concrete;
using FastRecrut.Entities.Dtos;

namespace FastRecrut.Business.Services.Abstract
{
    public interface IAgentService
    {
        void ADD(Agent agent);
        Agent GetByMail(string email);
        IDataResult<Agent> GetLastUser();
        IResult Add(Agent agent);
        //IResult Update(Agent agent);
        //IResult Delete(Agent agent);

        // Login Management
        Task<Agent> Authenticate(string username, string password);
        Task<IEnumerable<Agent>> GetAll();
        Task<Agent> GetById(int id);
        Task<Agent> Create(Agent agent, string password);
        void Update(Agent agent, string password = null);
        void Delete(int id);

        // Used with Dto
        AgentDetailDto GetByEmailDto(string email);
        List<AgentDetailDto> GetAgentDetails();
        List<AgentDetailDto> GetAgentDetailById(int agentId);
        
        
        
    }
}
