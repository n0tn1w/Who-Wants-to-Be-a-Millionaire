using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Models
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public class Question
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public List<Anaswer> Answers { get; set; }
        public string CallAFriendText { get; set; }
        public Difficulty Difficulty { get; set; }
    }

    public class Answer 
    {
        public int ID { get; set; }

        public string Option { get; set; }
        public bool IsCorrect { get; set; }
        public double VotePercentage { get; set; }
        public bool IsShownInFiftyFifty { get; set; }
    }
}
