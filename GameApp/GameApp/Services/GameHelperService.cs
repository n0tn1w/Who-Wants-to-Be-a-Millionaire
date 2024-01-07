using GameApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameApp.Services
{
    public class GameHelperService : IGameHelperService
    {
        private const string path = "C:\\Users\\daniel.manchevski\\source\\TestC#\\Who-Wants-to-Be-a-Millionaire\\questions.xml";
        public GameHelperService()
        {
            // Load data from XML File
            this.easyQuestions = new List<Question>();
            this.mediumQuestions = new List<Question>();
            this.hardQuestions = new List<Question>();

            LoadDataFromXMLFile();
        }

        private List<Question> easyQuestions;
        private List<Question> mediumQuestions;
        private List<Question> hardQuestions;

        private List<int> usedIndexes = new List<int>();

        public Question GetNextQuestion(int currentQuestionIndex)
        {
            Question question = null;

            if (1 <= currentQuestionIndex && currentQuestionIndex <= 4)
            {
                question = GetQuestionFromList(easyQuestions);
            }
            else if (5 <= currentQuestionIndex && currentQuestionIndex <= 8)
            {
                question = GetQuestionFromList(mediumQuestions);

            }
            else if (9 <= currentQuestionIndex && currentQuestionIndex <= 12) 
            {
                question = GetQuestionFromList(hardQuestions);

            }

            return question;
        }

        private Question GetQuestionFromList(List<Question> list)
        {
            if (list == null || list.Count == 0)
            {
                // Handle the case where the list is empty or null
                return null;
            }

            bool foundQuestion = false;
            int iter = 0;

            while (!foundQuestion && iter < 100)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, list.Count);
                Question question = list[randomIndex];

                if (!this.usedIndexes.Contains(question.QuestionId)) 
                {
                    foundQuestion = true;
                    this.usedIndexes.Add(question.QuestionId);
                    return question;
                }

                iter++;

            }

            return null;
        }

        public void ResetGame() 
        {
            this.usedIndexes = new List<int>();
        }

        private void LoadDataFromXMLFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Questions));

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                Questions questions = (Questions)serializer.Deserialize(fileStream);

                if (questions != null && questions.QuestionList != null)
                {
                    foreach (var question in questions.QuestionList)
                    {
                        switch (question.Difficulty)
                        {
                            case Difficulty.Easy:
                                easyQuestions.Add(question);
                                break;
                            case Difficulty.Medium:
                                mediumQuestions.Add(question);
                                break;
                            case Difficulty.Hard:
                                hardQuestions.Add(question);
                                break;
                        }
                    }
                }
            }
        }
    }
}
