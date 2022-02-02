using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Entities.Concrete
{
    public class Participant : IEntity
    {
        public Participant()
        {
            this.ParticipantDatas = new HashSet<ParticipantData>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public System.DateTime TimeStart { get; set; }
        public Nullable<System.DateTime> TimeLastQuiz { get; set; }

        public virtual ICollection<ParticipantData> ParticipantDatas { get; set; }
    }
}
