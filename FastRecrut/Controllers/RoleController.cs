using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastRecrut.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FastRecrut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public RoleController(IRoleService roleService, IMapper mapper, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _roleService = roleService;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetRoleByIdUser(id);
            return Ok(role);
        }
    }
}
