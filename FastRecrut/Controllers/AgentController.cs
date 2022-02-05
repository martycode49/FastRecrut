using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FastRecrut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }



        [HttpPost("add")]

        public IActionResult Add(Agent agent)
        {
            var result = _agentService.Add(agent);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
