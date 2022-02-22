using System;
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
            this.Roles = new HashSet<Role>();
            this.ParticipantDatas = new HashSet<ParticipantData>();
        }

        public int Id { get; set; }
        public string Civility { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Status { get; set; }


        public virtual ICollection<AgentParticipant> AgentParticipants { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<ParticipantData> ParticipantDatas { get; set; }
    }
}
