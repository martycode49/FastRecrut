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
    public class ParticipantDataController : ControllerBase
    {
        private readonly IParticipantDataService _pdataService;
        //private readonly IMapper _mapper; // for Dto using

        public ParticipantDataController(IParticipantDataService pdataService)
        {
            _pdataService = pdataService;
        }

        // GET: api/ParticipantData
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pdatas = await _pdataService.GetAllAsync();
            return Ok(pdatas);
        }

        // GET: api/ParticipantData/filter with filters => Agent(int) , Participant(int)
        [HttpGet("filter/{agentId}/{participantId}")]
        public async Task<IActionResult> GetByAgentParticipant(int agentId, int participantId)
        {
            var pdatas = await _pdataService.GetAllParticipantDataWithAgentIDParticipantID(agentId,participantId);
            return Ok(pdatas);
        }

        // GET: api/ParticipantData/filter with filters => participant (int)
        [HttpGet("filter/{participantId}")]
        public async Task<IActionResult> GetByParticipant(int participantId)
        {
            var pdatas = await _pdataService.GetAllParticipantDataWithParticipantId(participantId);
            return Ok(pdatas);
        }

        // GET: api/ParticipantData/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pdatas = await _pdataService.GetByIdAsync(id);
                if (pdatas == null) return NotFound("Data not available !");
                return Ok(pdatas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ParticipantData/Create
        [HttpPost]
        public async Task<IActionResult> Create(ParticipantData pdata)
        {
            var newquiz = await _pdataService.AddAsync(pdata);
            return Ok(pdata);
        }

        // Update: api/ParticipantData
        [HttpPut()]
        public IActionResult Update(ParticipantData pdata)
        {
            var updatePdata = _pdataService.Update(pdata);
            return Ok();
        }

        // Delete: ParticipantData/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedPdata = _pdataService.GetByIdAsync(id).Result;
            _pdataService.Remove(deletedPdata);
            return Ok();
        }
    }
}
