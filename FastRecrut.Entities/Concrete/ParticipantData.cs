using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRecrut.Core.Entities.Abstract;

namespace FastRecrut.Entities.Concrete
{
    public class ParticipantData : IEntity
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public int QuizQuestionId { get; set; }
        public int QuizParticipId { get; set; }
        public int QuizValidAnswer { get; set; }
        public Nullable<System.DateTime> QuizQstart { get; set; }
        public Nullable<System.DateTime> QuizQend { get; set; }
        public string QuizCommentPart { get; set; }
        public string QuizFreeAnswer { get; set; }
        public Nullable<bool> QuizValidFreeAnswer { get; set; }

        public virtual AgentParticipant AgentParticipants { get; set; }
        public virtual Agent Agents { get; set; }
        public virtual Quiz Quizzes { get; set; }
    }
}
