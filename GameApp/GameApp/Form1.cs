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
            listBoxRounds.Items.AddRange(Rounds);
            listBoxRounds.SelectionMode = SelectionMode.One;

            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddEllipse(0, 0, buttonLifelineAudience.Width, buttonLifelineAudience.Height);
            buttonLifelineAudience.Region = new Region(buttonPath);

            System.Drawing.Drawing2D.GraphicsPath buttonPath5050 = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath5050.AddEllipse(0, 0, buttonLifeline5050.Width, buttonLifeline5050.Height);
            buttonLifeline5050.Region = new Region(buttonPath5050);

            System.Drawing.Drawing2D.GraphicsPath buttonPathCall = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPathCall.AddEllipse(0, 0, buttonLifelineCall.Width, buttonLifelineCall.Height);
            buttonLifelineCall.Region = new Region(buttonPathCall);

            buttonLifelineAudience.MouseEnter += OnButtonMouseEnter;
            buttonLifelineAudience.MouseLeave += OnButtonMouseLeave;

            buttonLifelineCall.MouseEnter += OnButtonMouseEnter;
            buttonLifelineCall.MouseLeave += OnButtonMouseLeave;

            buttonLifeline5050.MouseEnter += OnButtonMouseEnter;
            buttonLifeline5050.MouseLeave += OnButtonMouseLeave;

            buttonCashOut.MouseEnter += OnButtonMouseEnter;
            buttonCashOut.MouseLeave += OnButtonMouseLeave;

            buttonFinal.MouseEnter += OnButtonGreenEnter;
            buttonFinal.MouseLeave += OnButtonGreenLeave;

            startButton.MouseEnter += OnButtonGreenEnter;
            startButton.MouseLeave += OnButtonGreenLeave;

            //buttonFinal
            //startButton

            int topMargin = (richTextBox1.Height - richTextBox1.Font.Height) / 2;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.SelectionStart = 0; // Set the selection start to 0 to apply margin to the entire text
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionCharOffset = topMargin;
            richTextBox1.SelectionLength = 0;
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
            textBoxAudiance.Visible = false;
            panelAudiance.Visible = false;

            if (this.currentQuestionIndex != 1)
            {
                listBoxRounds.SelectedIndex--;
            }
            this.question = this.gameHelperService.GetNextQuestion(currentQuestionIndex);

            richTextBox1.Text = this.question.Description.Replace("\t", "").Replace("\n", "");
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
            GameOverScree("100 000");
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
            //MessageBox.Show("50/50 lifeline selected!");
        }

        private void ButtonLifelineAudience_Click(object sender, EventArgs e)
        {
            buttonLifelineAudience.Visible = false;

            textBoxAudiance.Visible = true;
            panelAudiance.Visible = true;

            if (!isFiftyFiftyTriggered)
            {
                textBoxAudiance.Text = "A: " + this.question.Answers[0].VotePercentage + "% B: " + this.question.Answers[1].VotePercentage + "%\n";
                textBoxAudiance.Text += "C: " + this.question.Answers[2].VotePercentage + "% D: " + this.question.Answers[3].VotePercentage + "%";
            }
            else
            {
                int i = 0;
                double total = 0;
                foreach (var answer in this.question.Answers)
                {
                    if (answer.IsShownInFiftyFifty)
                    {
                        total += answer.VotePercentage;
                    }
                    i++;
                }

                i = 0;
                textBoxAudiance.Text = "";
                double value = 0;
                foreach (var answer in this.question.Answers)
                {
                    if (answer.IsShownInFiftyFifty)
                    {
                        char a = 'A';
                        if (i == 0)
                        {
                            value = 100 / (total / answer.VotePercentage);
                            value = (int)value;
                        }
                        else
                        {
                            value = 100 - value;
                        }
                        textBoxAudiance.Text += (char)(a + i) + ": " + value + "% ";
                    }
                    i++;
                }
            }
            //MessageBox.Show("Audience lifeline selected!");
        }

        private void buttonLifelineCall_Click(object sender, EventArgs e)
        {
            buttonLifelineCall.Visible = false;
            textBoxCallAFriend.Text = this.question.CallAFriendText;

            panelCallAFriend.Visible = true;
            textBoxCallAFriend.Visible = true;

            //MessageBox.Show("Call lifeline selected!");
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
                GameOverScree(" ");
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
                GameOverScree(" ");
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
                GameOverScree(" ");
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
                GameOverScree(" ");
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
            GameOverScree(Rounds[15 - this.currentQuestionIndex].Split(" ")[2]);
        }

        private void GameOverScree(string currentSum)
        {
            if (currentSum == " ")
            {
                textBoxFinal.Text = "You have won " + Rounds[15 - this.currentQuestionIndex].Split(" ")[2] + " лева.";

                if (1 <= currentQuestionIndex && currentQuestionIndex <= 5)
                {
                    currentSum = "0";
                }
                else if (6 <= currentQuestionIndex && currentQuestionIndex <= 9)
                {
                    currentSum = "250";

                }
                else if (10 <= currentQuestionIndex && currentQuestionIndex <= 12)
                {
                    currentSum = "2 500";

                }
                else 
                {
                    textBoxFinal.Text = "Congratulations you have won and the game\n" + textBoxFinal.Text;
                }

            }
            textBoxFinal.Text = "You have won the game and the big price of " + currentSum + " лева.";


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