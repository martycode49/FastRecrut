using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FastRecrut.Web.Models
{
    public class ParticipantData
    {
        public int Id { get; set; }
        [DisplayName("Id du quiz")]
        public int QuizId { get; set; }
        [DisplayName("Id du Questionnaire agent>Participant")]
        public int QuizQuestionId { get; set; }
        [DisplayName("Id du participant")]
        public int QuizParticipId { get; set; }
        public int QuizValidAnswer { get; set; }
        public Nullable<System.DateTime> QuizQstart { get; set; }
        public Nullable<System.DateTime> QuizQend { get; set; }
        public string QuizCommentPart { get; set; }
        public string QuizFreeAnswer { get; set; }
        public Nullable<bool> QuizValidFreeAnswer { get; set; }
    }
}
