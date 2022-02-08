using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastRecrut.Api.Resources
{
    public class SaveAgentResource
    {
        public string Civility { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Status { get; set; }
    }
}
