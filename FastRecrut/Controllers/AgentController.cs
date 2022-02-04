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

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _agentService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _agentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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

        [HttpPost("delete")]

        public IActionResult Delete(Agent agent)
        {
            var result = _agentService.Delete(agent);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(Agent agent)
        {
            var result = _agentService.Update(agent);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
