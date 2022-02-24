using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastRecrut.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FastRecrut.Web.ViewModels
{
    public enum LevelList { Junior=1,Confirmé=2,Expert=3}
    public class QuizViewModel
    {
        public int QuizId { get; set; }
        public string Subject { get; set; }
        public string SubSubject { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public string Rep1 { get; set; }
        public string Rep2 { get; set; }
        public string Rep3 { get; set; }
        public string Rep4 { get; set; }
        public LevelList Level { get; set; }
        public int ValidQuestion { get; set; }
        public string CommentFalse { get; set; }

    }
}
