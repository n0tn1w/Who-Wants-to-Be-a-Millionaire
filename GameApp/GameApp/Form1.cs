using GameApp.Models;
using GameApp.Services;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameApp
{
    public partial class MainForm : Form
    {
        public static readonly string[] Rounds =
        {
            "15  100,000 лева",
            "14  50,000 лева",
            "13  25,000 лева",
            "12  10,000 лева",
            "11  5,000 лева",
            "10  2,500 лева",
            "9  2,000 лева",
            "8  1,500 лева",
            "7  1,000 лева",
            "6  500 лева",
            "5  250 лева",
            "4  200 лева",
            "3  150 лева",
            "2  100 лева",
            "1  50 лева"
        };

        private readonly IGameHelperService gameHelperService;
        public MainForm(IGameHelperService gameHelperService)
        {
            InitializeComponent();
            this.gameHelperService = gameHelperService;
        }

        private int currentQuestionIndex = 1;
        private bool isFiftyFiftyTriggered = false;
        private Question question;

        private void getCurrentQuestion()
        {
            if (this.currentQuestionIndex == 13)
            {
                GameIsWonScreen();
            }
            if (isFiftyFiftyTriggered)
            {
                buttonAnswer1.Visible = true;
                labelAtext.Visible = true;
                buttonAnswer2.Visible = true;
                labelBtext.Visible = true;
                buttonAnswer3.Visible = true;
                labelCtext.Visible = true;
                buttonAnswer4.Visible = true;
                labelDtext.Visible = true;
            }
            panelCallAFriend.Visible = false;
            textBoxCallAFriend.Visible = false;

            if (this.currentQuestionIndex != 1)
            {
                listBoxRounds.SelectedIndex--;
            }
            this.question = this.gameHelperService.GetNextQuestion(currentQuestionIndex);

            richTextBox1.Text = this.question.Description;
            buttonAnswer1.Text = this.question.Answers[0].Option;
            buttonAnswer2.Text = this.question.Answers[1].Option;
            buttonAnswer3.Text = this.question.Answers[2].Option;
            buttonAnswer4.Text = this.question.Answers[3].Option;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            startPanel.Visible = false;
            ResetGame();
        }

        private void GameIsWonScreen()
        {
            textBoxFinal.Text = "You have won the game and the big price of 100 000 лева.";

            pannelFinal.Visible = true;
            textBoxFinal.Visible = true;
            buttonFinal.Visible = true;
        }

        private void buttonLifeline5050_Click(object sender, EventArgs e)
        {
            isFiftyFiftyTriggered = true;
            buttonLifeline5050.Visible = false;
            buttonAnswer1.Visible = this.question.Answers[0].IsShownInFiftyFifty;
            labelAtext.Visible = this.question.Answers[0].IsShownInFiftyFifty;
            buttonAnswer2.Visible = this.question.Answers[1].IsShownInFiftyFifty;
            labelBtext.Visible = this.question.Answers[1].IsShownInFiftyFifty;
            buttonAnswer3.Visible = this.question.Answers[2].IsShownInFiftyFifty;
            labelCtext.Visible = this.question.Answers[2].IsShownInFiftyFifty;
            buttonAnswer4.Visible = this.question.Answers[3].IsShownInFiftyFifty;
            labelDtext.Visible = this.question.Answers[3].IsShownInFiftyFifty;
            MessageBox.Show("50/50 lifeline selected!");
        }

        private void ButtonLifelineAudience_Click(object sender, EventArgs e)
        {
            buttonLifelineAudience.Visible = false;
            MessageBox.Show("Audience lifeline selected!");
        }

        private void buttonLifelineCall_Click(object sender, EventArgs e)
        {
            buttonLifelineCall.Visible = false;
            textBoxCallAFriend.Text = this.question.CallAFriendText;

            panelCallAFriend.Visible = true;
            textBoxCallAFriend.Visible = true;

            MessageBox.Show("Call lifeline selected!");
        }

        private void buttonAnswer1_Click(object sender, EventArgs e)
        {
            if (this.question.Answers[0].IsCorrect == true)
            {
                this.currentQuestionIndex++;
                getCurrentQuestion();
            }
            else
            {
                ResetGame();
            }
        }

        private void buttonAnswer2_Click(object sender, EventArgs e)
        {
            if (this.question.Answers[1].IsCorrect == true)
            {
                this.currentQuestionIndex++;
                getCurrentQuestion();
            }
            else
            {
                ResetGame();
            }
        }

        private void buttonAnswer3_Click(object sender, EventArgs e)
        {
            if (this.question.Answers[2].IsCorrect == true)
            {
                this.currentQuestionIndex++;
                getCurrentQuestion();
            }
            else
            {
                ResetGame();
            }
        }

        private void buttonAnswer4_Click(object sender, EventArgs e)
        {
            if (this.question.Answers[3].IsCorrect == true)
            {
                this.currentQuestionIndex++;
                getCurrentQuestion();
            }
            else
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            this.gameHelperService.ResetGame();

            buttonLifeline5050.Visible = true;
            buttonLifelineAudience.Visible = true;
            buttonLifelineCall.Visible = true;

            this.currentQuestionIndex = 1;
            listBoxRounds.SelectedIndex = 14;
            getCurrentQuestion();
        }

        private void buttonCashOut_Click(object sender, EventArgs e)
        {
            textBoxFinal.Text = "You have won the game and the big price of " + Rounds[15 - this.currentQuestionIndex].Split(" ")[2] + " лева.";

            pannelFinal.Visible = true;
            textBoxFinal.Visible = true;
            buttonFinal.Visible = true;
        }

        private void butonFinal_Click(object sender, EventArgs e)
        {
            pannelFinal.Visible = false;
            textBoxFinal.Visible = false;
            buttonFinal.Visible = false;
            ResetGame();
        }

    }
}