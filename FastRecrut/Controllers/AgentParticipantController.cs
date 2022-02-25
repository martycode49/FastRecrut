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
    public class AgentParticipantController : ControllerBase
    {
        private readonly IAgentParticipantService _apService;
        //private readonly IMapper _mapper; // for Dto using

        public AgentParticipantController(IAgentParticipantService apService)
        {
            _apService = apService;
        }

        // GET: api/AgentParticipant
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ap = await _apService.GetAllAsync();
            return Ok(ap);
        }

        // GET: api/AgentParticipant/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ap = await _apService.GetByIdAsync(id);
                if (ap == null) return NotFound("Data not available !");
                return Ok(ap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/AgentParticipant/Agent/5 * with filter
        [HttpGet("agent/{agentid}")]
        public async Task<IActionResult> GetAllAgentParticipantWithAgentId(int agentid)
        {
            try
            {
                var ap = await _apService.GetAllAgentParticipantWithAgentId(agentid);
                if (ap == null) return NotFound("Data not available !");
                return Ok(ap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/AgentParticipant/Create
        [HttpPost]
        public async Task<IActionResult> Create(AgentParticipant ap)
        {
            var newap = await _apService.AddAsync(ap);
            return Ok(ap);
        }

        // Update: api/AgentPArticipant
        [HttpPut()]
        public IActionResult Update(AgentParticipant ap)
        {
            var updateap = _apService.Update(ap);
            return Ok();
        }

        // Delete: AgentParticipant/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedap = _apService.GetByIdAsync(id).Result;
            _apService.Remove(deletedap);
            return Ok();
        }
    }
}
