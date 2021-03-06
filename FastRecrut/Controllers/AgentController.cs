using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FastRecrut.Api.Resources;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyMusic.API.Validation;

namespace FastRecrut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AgentController(IAgentService agentService, IRoleService roleService, IMapper mapper, IConfiguration config)
        {
            _agentService = agentService;
            _roleService = roleService;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AgentResource userResource)
        {
            var user = await _agentService.Authenticate(userResource.Email, userResource.Password);
            //var role = await _roleService.GetRoleByIdUser(user.AgentId); // ajout Martial
            var roles = await _roleService.GetAllRole();
            IEnumerable<string> resultQuery = roles.Where(x => x.AgentsAgentId == user.AgentId).Select(x => x.RoleName);// ajout Martial

            if (user == null) return BadRequest(new { message = "Email or password is incorrect" });
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.AgentId.ToString()),
                    //new Claim(ClaimTypes.Role, role.RoleName.ToString())
                    new Claim(ClaimTypes.Role, String.Join(", ", resultQuery))
                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.AgentId,
                Email = user.Email,
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Token = tokenString
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AgentResource userResource)
        {
            // validation
            var validation = new SaveUserResourceValidation();
            var validationResult = await validation.ValidateAsync(userResource);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var user = _mapper.Map<AgentResource, Agent>(userResource);
            // mappage
            var userSave = await _agentService.Create(user, userResource.Password);
            //send tocken 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.AgentId.ToString()),
                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.AgentId,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Token = tokenString
            });
        }

        //[Authorize(Roles ="Admin")]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AgentResource>>> GetAllAgent()
        {
            var agents = await _agentService.GetAll();
            var agentResources = _mapper.Map<IEnumerable<Agent>, IEnumerable<AgentResource>>(agents);
            return Ok(agentResources);
        }

        // Update Agent
        /*[HttpPut("")]
        public async Task<ActionResult<AgentResource>> UpdateAgent(int id, SaveAgentResource saveAgentResource)
        {
            // validation
            var validation = new SaveUserResourceValidation();
            var validationResult = await validation.ValidateAsync(saveAgentResource);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            // Get agent by ID
            var agentUpdate = await _agentService.GetByIdAgent(id);
            if (agentUpdate == null) return NotFound();
            //mappage
            var agent = _mapper.Map<SaveAgentResource, Agent>(saveAgentResource);
            // update Agent
            await _agentService.Update(agentUpdate, agent);
            //get agent By id
            var agentNew = await _agentService.GetByIdAgent(id);
            /// mappage
            var artisrNewResource = _mapper.Map<Agent, AgentResource>(agentNew);

            return Ok(artisrNewResource);
        }*/
        // Create Agent

        // Delete Agent

        // Get by id Agent



    }
}
