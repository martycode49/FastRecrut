using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRecrut.Api.Resources
{
    public class AgentResource
    {
        //public int Id { get; set; }
        public string Civility { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Status { get; set; }


    }
}
