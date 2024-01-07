using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GameApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //private void ApplyButtonStyle(Button button)
        //{
        //    button.FlatStyle = FlatStyle.Flat;
        //    button.BackColor = Color.FromArgb(255, 191, 0); // Millionaire yellow color
        //    button.ForeColor = Color.Black;
        //    button.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
        //    button.FlatAppearance.BorderSize = 0;
        //    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 215, 0); // Lighter yellow on hover
        //    button.Cursor = Cursors.Hand;
        //    button.Margin = new Padding(3, 10, 3, 10);
        //    button.Padding = new Padding(10);
        //    button.TextAlign = ContentAlignment.MiddleLeft;
        //}

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonAnswer1 = new Button();
            buttonAnswer3 = new Button();
            buttonAnswer2 = new Button();
            buttonAnswer4 = new Button();
            labelAtext = new Label();
            labelBtext = new Label();
            labelCtext = new Label();
            labelDtext = new Label();
            richTextBox1 = new RichTextBox();
            buttonLifelineCall = new Button();
            buttonLifeline5050 = new Button();
            buttonLifelineAudience = new Button();
            buttonCashOut = new Button();
            listBoxRounds = new ListBox();
            startPanel = new Panel();
            startButton = new Button();
            pannelFinal = new Panel();
            textBoxFinal = new RichTextBox();
            buttonFinal = new Button();
            panelCallAFriend = new Panel();
            textBoxCallAFriend = new RichTextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panelCallAFriend.SuspendLayout();
            //SuspendLayout();
            // 
            // buttonAnswer1
            // 
            buttonAnswer1.Location = new Point(44, 461);
            buttonAnswer1.Margin = new Padding(3, 2, 3, 2);
            buttonAnswer1.Name = "buttonAnswer1";
            buttonAnswer1.Size = new Size(367, 49);
            buttonAnswer1.TabIndex = 0;
            buttonAnswer1.Text = "<answer_slot>";
            buttonAnswer1.UseVisualStyleBackColor = true;
            buttonAnswer1.Click += buttonAnswer1_Click;
            // 
            // buttonAnswer3
            // 
            buttonAnswer3.Location = new Point(44, 530);
            buttonAnswer3.Margin = new Padding(3, 2, 3, 2);
            buttonAnswer3.Name = "buttonAnswer3";
            buttonAnswer3.Size = new Size(367, 49);
            buttonAnswer3.TabIndex = 1;
            buttonAnswer3.Text = "<answer_slot>";
            buttonAnswer3.UseVisualStyleBackColor = true;
            buttonAnswer3.Click += buttonAnswer3_Click;
            // 
            // buttonAnswer2
            // 
            buttonAnswer2.Location = new Point(467, 461);
            buttonAnswer2.Margin = new Padding(3, 2, 3, 2);
            buttonAnswer2.Name = "buttonAnswer2";
            buttonAnswer2.Size = new Size(367, 49);
            buttonAnswer2.TabIndex = 2;
            buttonAnswer2.Text = "<answer_slot>";
            buttonAnswer2.UseVisualStyleBackColor = true;
            buttonAnswer2.Click += buttonAnswer2_Click;
            // 
            // buttonAnswer4
            // 
            buttonAnswer4.Location = new Point(467, 530);
            buttonAnswer4.Margin = new Padding(3, 2, 3, 2);
            buttonAnswer4.Name = "buttonAnswer4";
            buttonAnswer4.Size = new Size(367, 49);
            buttonAnswer4.TabIndex = 3;
            buttonAnswer4.Text = "<answer_slot>";
            buttonAnswer4.UseVisualStyleBackColor = true;
            buttonAnswer4.Click += buttonAnswer4_Click;
            // 
            // labelAtext
            // 
            labelAtext.AutoSize = true;
            labelAtext.Location = new Point(60, 478);
            labelAtext.Name = "labelAtext";
            labelAtext.Size = new Size(15, 15);
            labelAtext.TabIndex = 5;
            labelAtext.Text = "A";
            // 
            // labelBtext
            // 
            labelBtext.AutoSize = true;
            labelBtext.Location = new Point(490, 478);
            labelBtext.Name = "labelBtext";
            labelBtext.Size = new Size(14, 15);
            labelBtext.TabIndex = 6;
            labelBtext.Text = "B";
            // 
            // labelCtext
            // 
            labelCtext.AutoSize = true;
            labelCtext.Location = new Point(60, 547);
            labelCtext.Name = "labelCtext";
            labelCtext.Size = new Size(15, 15);
            labelCtext.TabIndex = 7;
            labelCtext.Text = "C";
            // 
            // labelDtext
            // 
            labelDtext.AutoSize = true;
            labelDtext.Location = new Point(490, 547);
            labelDtext.Name = "labelDtext";
            labelDtext.Size = new Size(15, 15);
            labelDtext.TabIndex = 8;
            labelDtext.Text = "D";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(44, 350);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(791, 96);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // buttonLifelineCall
            // 
            buttonLifelineCall.Location = new Point(854, 9);
            buttonLifelineCall.Margin = new Padding(3, 2, 3, 2);
            buttonLifelineCall.Name = "buttonLifelineCall";
            buttonLifelineCall.Size = new Size(84, 50);
            buttonLifelineCall.TabIndex = 10;
            buttonLifelineCall.Text = "Call";
            buttonLifelineCall.UseVisualStyleBackColor = true;
            buttonLifelineCall.Click += buttonLifelineCall_Click;
            // 
            // buttonLifeline5050
            // 
            buttonLifeline5050.Location = new Point(954, 9);
            buttonLifeline5050.Margin = new Padding(3, 2, 3, 2);
            buttonLifeline5050.Name = "buttonLifeline5050";
            buttonLifeline5050.Size = new Size(84, 50);
            buttonLifeline5050.TabIndex = 11;
            buttonLifeline5050.Text = "50/50";
            buttonLifeline5050.UseVisualStyleBackColor = true;
            buttonLifeline5050.Click += buttonLifeline5050_Click;
            // 
            // buttonLifelineAudience
            // 
            buttonLifelineAudience.Location = new Point(1055, 9);
            buttonLifelineAudience.Margin = new Padding(3, 2, 3, 2);
            buttonLifelineAudience.Name = "buttonLifelineAudience";
            buttonLifelineAudience.Size = new Size(84, 50);
            buttonLifelineAudience.TabIndex = 12;
            buttonLifelineAudience.Text = "Audience";
            buttonLifelineAudience.UseVisualStyleBackColor = true;
            buttonLifelineAudience.Click += ButtonLifelineAudience_Click;
            // 
            // buttonCashOut
            // 
            buttonCashOut.Location = new Point(854, 414);
            buttonCashOut.Margin = new Padding(3, 2, 3, 2);
            buttonCashOut.Name = "buttonCashOut";
            buttonCashOut.Size = new Size(285, 44);
            buttonCashOut.TabIndex = 13;
            buttonCashOut.Text = "Cash out";
            buttonCashOut.UseVisualStyleBackColor = true;
            buttonCashOut.Click += buttonCashOut_Click;
            // 
            // listBoxRounds
            // 
            listBoxRounds.Font = new Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxRounds.FormattingEnabled = true;
            listBoxRounds.ItemHeight = 21;
            listBoxRounds.Location = new Point(854, 74);
            listBoxRounds.Margin = new Padding(3, 2, 3, 2);
            listBoxRounds.Name = "listBoxRounds";
            listBoxRounds.Size = new Size(286, 319);
            listBoxRounds.TabIndex = 15;
            // 
            // startPanel
            // 
            startPanel.BackColor = SystemColors.Info;
            startPanel.Controls.Add(startButton);
            startPanel.Location = new Point(226, 197);
            startPanel.Name = "startPanel";
            startPanel.Size = new Size(972, 491);
            startPanel.TabIndex = 16;
            // 
            // startButton
            // 
            startButton.Location = new Point(112, 130);
            startButton.Name = "startButton";
            startButton.Size = new Size(143, 49);
            startButton.TabIndex = 0;
            startButton.Text = "Start Game";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // pannelFinal
            // 
            pannelFinal.BackColor = Color.SteelBlue;
            pannelFinal.BorderStyle = BorderStyle.FixedSingle;
            pannelFinal.Controls.Add(textBoxFinal);
            pannelFinal.Controls.Add(buttonFinal);
            pannelFinal.Location = new Point(442, 138);
            pannelFinal.Name = "pannelFinal";
            pannelFinal.Size = new Size(372, 202);
            pannelFinal.TabIndex = 17;
            pannelFinal.Visible = false;
            // 
            // textBoxFinal
            // 
            textBoxFinal.Location = new Point(60, 26);
            textBoxFinal.Name = "textBoxFinal";
            textBoxFinal.ReadOnly = true;
            textBoxFinal.Size = new Size(252, 65);
            textBoxFinal.TabIndex = 2;
            textBoxFinal.Text = "";
            textBoxFinal.Visible = false;
            // 
            // buttonFinal
            // 
            buttonFinal.Location = new Point(116, 130);
            buttonFinal.Name = "buttonFinal";
            buttonFinal.Size = new Size(143, 49);
            buttonFinal.TabIndex = 0;
            buttonFinal.Text = "Restart";
            buttonFinal.UseVisualStyleBackColor = true;
            buttonFinal.Visible = false;
            buttonFinal.Click += butonFinal_Click;
            // 
            // panelCallAFriend
            // 
            panelCallAFriend.BackColor = SystemColors.MenuHighlight;
            panelCallAFriend.Controls.Add(textBoxCallAFriend);
            panelCallAFriend.Controls.Add(startPanel);
            panelCallAFriend.ForeColor = SystemColors.ControlText;
            panelCallAFriend.Location = new Point(44, 19);
            panelCallAFriend.Name = "panelCallAFriend";
            panelCallAFriend.Size = new Size(266, 100);
            panelCallAFriend.TabIndex = 18;
            panelCallAFriend.Visible = false;
            // 
            // textBoxCallAFriend
            // 
            textBoxCallAFriend.Location = new Point(16, 19);
            textBoxCallAFriend.Name = "textBoxCallAFriend";
            textBoxCallAFriend.Size = new Size(233, 65);
            textBoxCallAFriend.TabIndex = 19;
            textBoxCallAFriend.Text = "";
            textBoxCallAFriend.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            //BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1166, 607);
            Controls.Add(panelCallAFriend);
            Controls.Add(buttonCashOut);
            Controls.Add(buttonLifelineAudience);
            Controls.Add(buttonLifeline5050);
            Controls.Add(buttonLifelineCall);
            Controls.Add(richTextBox1);
            Controls.Add(labelDtext);
            Controls.Add(labelCtext);
            Controls.Add(labelBtext);
            Controls.Add(labelAtext);
            Controls.Add(buttonAnswer4);
            Controls.Add(buttonAnswer2);
            Controls.Add(buttonAnswer3);
            Controls.Add(buttonAnswer1);
            Controls.Add(startButton);
            Controls.Add(startPanel);
            Controls.Add(listBoxRounds);
            Controls.Add(pannelFinal);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Who Wants to Be a Millionaire";
            panelCallAFriend.ResumeLayout(false);
            //ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAnswer1;
        private Button buttonAnswer3;
        private Button buttonAnswer2;
        private Button buttonAnswer4;
        private Label labelAtext;
        private Label labelBtext;
        private Label labelCtext;
        private Label labelDtext;
        private RichTextBox richTextBox1;
        private Button buttonLifelineCall;
        private Button buttonLifeline5050;
        private Button buttonLifelineAudience;
        private Button buttonCashOut;
        private ListBox listBoxRounds;
        private Panel startPanel;
        private Button startButton;
        private Panel pannelFinal;
        private Button buttonFinal;
        private RichTextBox textBoxFinal;
        private Panel panelCallAFriend;
        private RichTextBox textBoxCallAFriend;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
