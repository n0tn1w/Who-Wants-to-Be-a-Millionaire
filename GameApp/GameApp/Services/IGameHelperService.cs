using GameApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp.Services
{
    public interface IGameHelperService
    {
        Question GetNextQuestion(int currentQuestionIndex);
        void ResetGame();
    }
}
