using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Entities.Concrete
{
    public class AgentParticipant : IEntity
    {

        public AgentParticipant()
        {
            this.ParticipantDatas = new HashSet<ParticipantData>();
        }
        public int AgtPartId { get; set; }
        [ForeignKey("AgentId")]
        public int AgentId { get; set; }
        public Nullable<System.DateTime> datecreate { get; set; }
        public int QuestionQty { get; set; }
        public string Status { get; set; }

        public virtual Agent Agents { get; set; }
        public virtual ICollection<ParticipantData> ParticipantDatas { get; set; }
        //public virtual ParticipantData ParticipantDatas { get; set; }
    }
}
