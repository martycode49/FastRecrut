﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Entities.Concrete
{
    public class Agent : IEntity
    {
        public Agent()
        {
            this.AgentParticipants = new HashSet<AgentParticipant>();
        }

        public int Id { get; set; }
        public string Civility { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }

        public virtual ICollection<AgentParticipant> AgentParticipants { get; set; }
    }
}