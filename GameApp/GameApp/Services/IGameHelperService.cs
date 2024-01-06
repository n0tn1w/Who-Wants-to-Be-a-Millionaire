using GameApp.Models;

namespace GameApp.Services
{
    public interface IGameHelperService
    {
        int GetCurrentQuestionNumber();
        void SetCurrentQuestionNumber(int questionId);
        QuestionDTO GetNextQuestion(int index);
        void EmptyUsedQuestionsList();

        LifelineContainerDTO lifelineContainer { get; set; }
    }
}
