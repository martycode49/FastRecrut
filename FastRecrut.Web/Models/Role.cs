using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRecrut.Web.Models
{
    public class Role
    {
        public int Id { get; set; }

        public int Agent_Id { get; set; }
        public string RoleName { get; set; }
        public int AgentsAgentId { get; set; }

    }
}
