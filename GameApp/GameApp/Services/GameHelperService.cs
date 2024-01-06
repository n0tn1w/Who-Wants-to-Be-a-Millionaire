using GameApp.Models;
using System.Xml.Linq;

namespace GameApp.Services
{
    public class GameHelperService : IGameHelperService
    {
        public const string filePath = "D:\\C Sharp\\Who-Wants-to-Be-a-Millionaire\\GameApp\\GameApp\\wwwroot\\qna.xml";

        private int currentQuestion = 0;
        private List<QuestionDTO> questionList = new List<QuestionDTO>();
        private List<int> alreadyDoneQuestion = new List<int>();

        public LifelineContainerDTO lifelineContainer { get; set; }

        public GameHelperService() 
        {
            ExtractDataFromXMLFile();
            this.lifelineContainer = new LifelineContainerDTO();
        }

        private void ExtractDataFromXMLFile() 
        {
            XDocument doc = XDocument.Load(filePath);

            this.questionList = doc.Root.Elements("question")
                .Select(q => new QuestionDTO
                {
                    Id = int.Parse(q.Attribute("id").Value),
                    Difficulty = q.Attribute("difficulty").Value,
                    Description = q.Element("text").Value,
                    Options = q.Element("options").Elements("option")
                        .Select(o => new AnswersOptionsDTO
                        {
                            Correct = bool.Parse(o.Attribute("correct").Value),
                            Description = o.Value
                        })
                        .ToList()
                })
                .ToList();
        }

        public void EmptyUsedQuestionsList()
        {
            alreadyDoneQuestion = new List<int>();
        }

        public int GetCurrentQuestionNumber()
        {
            return currentQuestion;
        }
        public void SetCurrentQuestionNumber(int questionId)
        {
            this.currentQuestion = questionId;
        }

        public QuestionDTO GetNextQuestion(int index)
        {
            int numOfQuestions = this.questionList.Count();

            // From 1-4 easy questions, from 5-8 mediam, from 9-12 hard (inclusive boundaries)
            Random random = new Random();
            int chosenQuestion = 0;
            bool questionIsPicked = false;

            while (!questionIsPicked)
            {
                if (index <= 4)
                {
                    chosenQuestion = random.Next(0, 9);
                }
                else if (index <= 8)
                {
                    chosenQuestion = random.Next(10, 19);
                }
                else
                {
                    chosenQuestion = random.Next(20, 29);
                }

                if (this.alreadyDoneQuestion.Contains(chosenQuestion))
                {
                    // This question have already been done
                }
                else 
                {
                    questionIsPicked = true;
                    this.alreadyDoneQuestion.Add(chosenQuestion);
                }
            }

            return this.questionList[chosenQuestion];
        }

    }
}
