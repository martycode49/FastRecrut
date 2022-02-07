using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRecrut.Api.Resources
{
    public class AgentResource
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
