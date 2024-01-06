namespace GameApp.Models
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Difficulty { get; set; }
        public string Description{ get; set; }
        public List<AnswersOptionsDTO> Options { get; set; }
    }

    public class AnswersOptionsDTO
    { 
        public bool Correct { get; set; }
        public string Description { get; set; }
    }
}
