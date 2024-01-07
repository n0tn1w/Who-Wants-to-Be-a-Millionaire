using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameApp.Models
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    [XmlRoot("Questions")]
    public class Questions
    {
        [XmlElement("Question")]
        public List<Question> QuestionList { get; set; }
    }

    public class Question
    {
        [XmlAttribute("QuestionId")]
        public int QuestionId { get; set; }

        [XmlAttribute("Difficulty")]
        public Difficulty Difficulty { get; set; }

        [XmlAttribute("CallAFriendText")]
        public string CallAFriendText { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Answer")]
        public List<Answer> Answers { get; set; }
    }

    public class Answer
    {
        [XmlAttribute("IsCorrect")]
        public bool IsCorrect { get; set; }

        [XmlAttribute("VotePercentage")]
        public double VotePercentage { get; set; }

        [XmlAttribute("IsShownInFiftyFifty")]
        public bool IsShownInFiftyFifty { get; set; }

        [XmlText]
        public string Option { get; set; }
    }
}
