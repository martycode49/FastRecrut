using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Entities.Concrete
{
    public class Quiz : IEntity
    {
        public Quiz()
        {
            this.ParticipantDatas = new HashSet<ParticipantData>();
        }

        public int QuizId { get; set; }
        public string Subject { get; set; }
        public string SubSubject { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public string Rep1 { get; set; }
        public string Rep2 { get; set; }
        public string Rep3 { get; set; }
        public string Rep4 { get; set; }
        public int Level { get; set; }
        public int ValidQuestion { get; set; }
        public string CommentFalse { get; set; }

        public virtual ICollection<ParticipantData> ParticipantDatas { get; set; }
    }
}
