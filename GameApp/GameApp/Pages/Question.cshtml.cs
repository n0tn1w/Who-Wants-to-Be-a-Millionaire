using GameApp.Models;
using GameApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameApp.Pages
{
    public class QuestionModel : PageModel
    {
        private readonly IGameHelperService _gameHelperService;

        public QuestionModel(IGameHelperService gameHelperService)
        {
            this._gameHelperService = gameHelperService;
            this.LifelineContainer = this._gameHelperService.lifelineContainer;
        }

        public LifelineContainerDTO LifelineContainer { get; set; }
        public QuestionDTO CurrentQuestion { get; set; }

        public IActionResult OnGet()
        {
            this.LifelineContainer = this._gameHelperService.lifelineContainer;
            int currQuestionNumber = this._gameHelperService.GetCurrentQuestionNumber();
            if (currQuestionNumber + 1 == 13)
            {
                return RedirectToPage("/FinalScreen");
            }

            this.CurrentQuestion = this._gameHelperService.GetNextQuestion(currQuestionNumber);
            this._gameHelperService.SetCurrentQuestionNumber(currQuestionNumber + 1);

            return Page();
        }

        public IActionResult FiftyFiftyHandler() 
        {
            this._gameHelperService.lifelineContainer.isFiftyFiftyUsed = true;
            return Page();
        }
    }
}
