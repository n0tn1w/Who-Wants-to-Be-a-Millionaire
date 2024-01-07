namespace Millionaire
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            SuspendLayout();
            // 
            // buttonAnswer1
            // 
            buttonAnswer1.Location = new Point(50, 615);
            buttonAnswer1.Name = "buttonAnswer1";
            buttonAnswer1.Size = new Size(419, 65);
            buttonAnswer1.TabIndex = 0;
            buttonAnswer1.Text = "<answer_slot>";
            buttonAnswer1.UseVisualStyleBackColor = true;
            // 
            // buttonAnswer3
            // 
            buttonAnswer3.Location = new Point(50, 707);
            buttonAnswer3.Name = "buttonAnswer3";
            buttonAnswer3.Size = new Size(419, 65);
            buttonAnswer3.TabIndex = 1;
            buttonAnswer3.Text = "<answer_slot>";
            buttonAnswer3.UseVisualStyleBackColor = true;
            // 
            // buttonAnswer2
            // 
            buttonAnswer2.Location = new Point(534, 615);
            buttonAnswer2.Name = "buttonAnswer2";
            buttonAnswer2.Size = new Size(419, 65);
            buttonAnswer2.TabIndex = 2;
            buttonAnswer2.Text = "<answer_slot>";
            buttonAnswer2.UseVisualStyleBackColor = true;
            // 
            // buttonAnswer4
            // 
            buttonAnswer4.Location = new Point(534, 707);
            buttonAnswer4.Name = "buttonAnswer4";
            buttonAnswer4.Size = new Size(419, 65);
            buttonAnswer4.TabIndex = 3;
            buttonAnswer4.Text = "<answer_slot>";
            buttonAnswer4.UseVisualStyleBackColor = true;
            // 
            // labelAtext
            // 
            labelAtext.AutoSize = true;
            labelAtext.Location = new Point(68, 637);
            labelAtext.Name = "labelAtext";
            labelAtext.Size = new Size(19, 20);
            labelAtext.TabIndex = 5;
            labelAtext.Text = "A";
            // 
            // labelBtext
            // 
            labelBtext.AutoSize = true;
            labelBtext.Location = new Point(560, 637);
            labelBtext.Name = "labelBtext";
            labelBtext.Size = new Size(18, 20);
            labelBtext.TabIndex = 6;
            labelBtext.Text = "B";
            // 
            // labelCtext
            // 
            labelCtext.AutoSize = true;
            labelCtext.Location = new Point(68, 729);
            labelCtext.Name = "labelCtext";
            labelCtext.Size = new Size(18, 20);
            labelCtext.TabIndex = 7;
            labelCtext.Text = "C";
            // 
            // labelDtext
            // 
            labelDtext.AutoSize = true;
            labelDtext.Location = new Point(560, 729);
            labelDtext.Name = "labelDtext";
            labelDtext.Size = new Size(20, 20);
            labelDtext.TabIndex = 8;
            labelDtext.Text = "D";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(50, 466);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(903, 127);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // buttonLifelineCall
            // 
            buttonLifelineCall.Location = new Point(976, 12);
            buttonLifelineCall.Name = "buttonLifelineCall";
            buttonLifelineCall.Size = new Size(96, 66);
            buttonLifelineCall.TabIndex = 10;
            buttonLifelineCall.Text = "Call";
            buttonLifelineCall.UseVisualStyleBackColor = true;
            // 
            // buttonLifeline5050
            // 
            buttonLifeline5050.Location = new Point(1090, 12);
            buttonLifeline5050.Name = "buttonLifeline5050";
            buttonLifeline5050.Size = new Size(96, 66);
            buttonLifeline5050.TabIndex = 11;
            buttonLifeline5050.Text = "50/50";
            buttonLifeline5050.UseVisualStyleBackColor = true;
            // 
            // buttonLifelineAudience
            // 
            buttonLifelineAudience.Location = new Point(1206, 12);
            buttonLifelineAudience.Name = "buttonLifelineAudience";
            buttonLifelineAudience.Size = new Size(96, 66);
            buttonLifelineAudience.TabIndex = 12;
            buttonLifelineAudience.Text = "Audience";
            buttonLifelineAudience.UseVisualStyleBackColor = true;
            // 
            // buttonCashOut
            // 
            buttonCashOut.Location = new Point(976, 534);
            buttonCashOut.Name = "buttonCashOut";
            buttonCashOut.Size = new Size(326, 59);
            buttonCashOut.TabIndex = 13;
            buttonCashOut.Text = "Cash out";
            buttonCashOut.UseVisualStyleBackColor = true;
            // 
            // listBoxRounds
            // 
            listBoxRounds = new ListBox();
            listBoxRounds.Font = new Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxRounds.FormattingEnabled = true;
            listBoxRounds.ItemHeight = 25;
            listBoxRounds.Items.AddRange(new object[] { "15  100,000 лева", "14  50,000 лева", "13  25,000 лева", "12  10,000 лева", "11  5,000 лева", "10  2,500 лева", "9  2,000 лева", "8  1,500 лева", "7  1,000 лева", "6  500 лева", "5  250 лева", "4  200 лева", "3  150 лева", "2  100 лева", "1  50 лева" });
            listBoxRounds.Location = new Point(976, 99);
            listBoxRounds.Name = "listBoxRounds";
            listBoxRounds.Size = new Size(326, 404);

            listBoxRounds.TabIndex = 15;
            buttonCashOut.Click += (sender, e) =>
            {
                    listBoxRounds.SelectedIndex = 1;
            };
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1326, 824);
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
            Controls.Add(listBoxRounds);
            Name = "MainForm";
            Text = "Who Wants to Be a Millionaire";
            ResumeLayout(false);
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
    }
}
