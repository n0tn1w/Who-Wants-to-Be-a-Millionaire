using GameApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameApp.Pages
{
    public class FinalScreenModel : PageModel
    {

        private readonly IGameHelperService _gameHelperService;

        public FinalScreenModel(IGameHelperService gameHelperService)
        {
            this._gameHelperService = gameHelperService;
        }
        public void OnGet()
        {
            this._gameHelperService.EmptyUsedQuestionsList();
            this._gameHelperService.SetCurrentQuestionNumber(0);
        }
    }
}
