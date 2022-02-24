using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Web.Models;

namespace FastRecrut.Web.ViewModels
{
    public class ParticipantDataViewModel
    {
        public int Id { get; set; }
        [DisplayName("Id du agent/part")]
        public int AgtPartId { get; set; }
        [DisplayName("Id du Quiz")]
        public int QuizId { get; set; }
        [DisplayName("Id du participant")]
        public int AgentId { get; set; }
        public int QuizValidAnswer { get; set; }
        public Nullable<System.DateTime> QuizQstart { get; set; }
        public Nullable<System.DateTime> QuizQend { get; set; }
        public string QuizCommentPart { get; set; }
        public string QuizFreeAnswer { get; set; }
        public Nullable<bool> QuizValidFreeAnswer { get; set; }
    }
}
