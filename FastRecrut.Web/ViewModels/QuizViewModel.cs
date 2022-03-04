using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

        // Extra property
        public bool IsSelected { get; set; }
        public RatioViewModel ratioView { get; set; }
    }
    public class MyDocument
    {
        public string ConfigLevel { get; set; }
        public Subject Subject { get; set; }

        [XmlArray]
        [XmlArrayItem(ElementName = "MyListItem")]
        public List<int> MyList { get; set; }
    }
    public class Subject
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }


}
