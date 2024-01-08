using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

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

        class RoundedButton : Button
        {
            GraphicsPath GetRoundPath(RectangleF Rect, int radius)
            {
                float r2 = radius / 2f;
                GraphicsPath GraphPath = new GraphicsPath();
                GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
                GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
                GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
                GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
                GraphPath.AddArc(Rect.X + Rect.Width - radius,
                                 Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
                GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
                GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
                GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
                GraphPath.CloseFigure();
                return GraphPath;
            }
            private Color defaultBorderColor = Color.Black;
            private Color hoverBorderColor = Color.Black;
            private Color defaultBackColor = SystemColors.Control;  // Set your default background color
            private Color hoverBackColor = Color.DodgerBlue;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
                using (GraphicsPath GraphPath = GetRoundPath(Rect, 50))
                {
                    this.Region = new Region(GraphPath);
                    Color borderColor = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)) ? hoverBorderColor : defaultBorderColor;
                    Color backColor = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)) ? hoverBackColor : defaultBackColor;

                    using (SolidBrush brush = new SolidBrush(backColor))
                    {
                        e.Graphics.FillPath(brush, GraphPath);
                    }

                    using (Pen pen = new Pen(borderColor, 1.75f))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawPath(pen, GraphPath);
                    }

                    // Draw the button text
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
                        {
                            e.Graphics.DrawString(this.Text, this.Font, textBrush, this.ClientRectangle, sf);
                        }
                    }
                }
            }
        }
        class RhombusLabel : Label
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                using (GraphicsPath myPath = new GraphicsPath())
                {
                    myPath.AddLines(new[]
                        {
                new Point(0, Height / 2),
                new Point(Width / 2, 0),
                new Point(Width, Height / 2),
                new Point(Width / 2, Height)
            });
                    Region = new Region(myPath);
                }

                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
                    {
                        e.Graphics.DrawString(this.Text, this.Font, textBrush, this.ClientRectangle, sf);
                    }
                }
            }
        }

        class RoundedRichTextBox : RichTextBox
        {
            private const int WM_NCPAINT = 0x85;

            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowDC(IntPtr hWnd);

            [DllImport("user32.dll")]
            private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg == WM_NCPAINT)
                {
                    IntPtr hdc = GetWindowDC(m.HWnd);
                    using (Graphics g = Graphics.FromHdcInternal(hdc))
                    {
                        using (Pen pen = new Pen(Color.Black, 2))
                        {
                            Rectangle rect = new Rectangle(0, 0, Width, Height);
                            g.DrawEllipse(pen, rect);
                        }
                    }
                    ReleaseDC(m.HWnd, hdc);
                }
            }
        }

        public class RhombusPictureBox : PictureBox
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                using (GraphicsPath path = new GraphicsPath())
                {
                    int width = Width;
                    int height = Height;

                    Point[] points =
                    {
                new Point(width / 2, 0),
                new Point(width, height / 2),
                new Point(width / 2, height),
                new Point(0, height / 2)
            };

                    path.AddPolygon(points);

                    using (SolidBrush brush = new SolidBrush(Color.DodgerBlue))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            }
        }



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonAnswer1 = new RoundedButton();
            buttonAnswer3 = new RoundedButton();
            buttonAnswer2 = new RoundedButton();
            buttonAnswer4 = new RoundedButton();
            labelAtext = new RhombusLabel();
            labelBtext = new RhombusLabel();
            labelCtext = new RhombusLabel();
            labelDtext = new RhombusLabel();
            richTextBox1 = new RoundedRichTextBox();
            buttonLifelineCall = new Button();
            buttonLifeline5050 = new Button();
            buttonLifelineAudience = new Button();
            buttonCashOut = new Button();
            listBoxRounds = new ListBox();
            startPanel = new Panel();
            startButton = new Button();
            pannelFinal = new Panel();
            textBoxFinal = new RoundedRichTextBox();
            buttonFinal = new Button();
            panelCallAFriend = new Panel();
            textBoxCallAFriend = new RichTextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox1 = new RhombusPictureBox();
            pictureBox2 = new RhombusPictureBox();
            panelAudiance = new Panel();
            textBoxAudiance = new RichTextBox();

            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            // 
            // buttonAnswer1
            // 
            buttonAnswer1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAnswer1.Location = new Point(44, 461);
            buttonAnswer1.Margin = new Padding(3, 2, 3, 2);
            buttonAnswer1.Name = "buttonAnswer1";
            buttonAnswer1.Size = new Size(367, 49);
            buttonAnswer1.TabIndex = 0;
            buttonAnswer1.Text = "<answer_slot>";
            buttonAnswer1.Click += buttonAnswer1_Click;
            // 
            // buttonAnswer3
            // 
            buttonAnswer3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
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
            buttonAnswer2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
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
            buttonAnswer4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
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
            labelAtext.BackColor = Color.DodgerBlue;
            labelAtext.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelAtext.ForeColor = Color.Black;
            labelAtext.Location = new Point(60, 468);
            labelAtext.Name = "labelAtext";
            labelAtext.Size = new Size(36, 36);
            labelAtext.TabIndex = 5;
            labelAtext.Text = "A";
            labelAtext.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelBtext
            // 
            labelBtext.BackColor = Color.DodgerBlue;
            labelBtext.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelBtext.ForeColor = Color.Black;
            labelBtext.Location = new Point(481, 468);
            labelBtext.Name = "labelBtext";
            labelBtext.Size = new Size(36, 36);
            labelBtext.TabIndex = 6;
            labelBtext.Text = "B";
            labelBtext.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCtext
            // 
            labelCtext.BackColor = Color.DodgerBlue;
            labelCtext.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelCtext.ForeColor = Color.Black;
            labelCtext.Location = new Point(60, 537);
            labelCtext.Name = "labelCtext";
            labelCtext.Size = new Size(36, 36);
            labelCtext.TabIndex = 7;
            labelCtext.Text = "C";
            labelCtext.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDtext
            // 
            labelDtext.BackColor = Color.DodgerBlue;
            labelDtext.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelDtext.ForeColor = Color.Black;
            labelDtext.Location = new Point(481, 537);
            labelDtext.Name = "labelDtext";
            labelDtext.Size = new Size(36, 36);
            labelDtext.TabIndex = 8;
            labelDtext.Text = "D";
            labelDtext.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.LightGray;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Arial", 19F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(130, 8);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(601, 96);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // buttonLifelineCall
            // 
            buttonLifelineCall.BackColor = Color.DodgerBlue;
            buttonLifelineCall.Cursor = Cursors.Hand;
            buttonLifelineCall.FlatAppearance.BorderSize = 0;
            buttonLifelineCall.FlatStyle = FlatStyle.Flat;
            buttonLifelineCall.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLifelineCall.ForeColor = Color.White;
            buttonLifelineCall.Location = new Point(854, 9);
            buttonLifelineCall.Name = "buttonLifelineCall";
            buttonLifelineCall.Size = new Size(84, 50);
            buttonLifelineCall.TabIndex = 21;
            buttonLifelineCall.Text = "Call";
            buttonLifelineCall.UseVisualStyleBackColor = false;
            buttonLifelineCall.Click += buttonLifelineCall_Click;
            // 
            // buttonLifeline5050
            // 
            buttonLifeline5050.BackColor = Color.DodgerBlue;
            buttonLifeline5050.Cursor = Cursors.Hand;
            buttonLifeline5050.FlatAppearance.BorderSize = 0;
            buttonLifeline5050.FlatStyle = FlatStyle.Flat;
            buttonLifeline5050.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLifeline5050.ForeColor = Color.White;
            buttonLifeline5050.Location = new Point(954, 9);
            buttonLifeline5050.Name = "buttonLifeline5050";
            buttonLifeline5050.Size = new Size(84, 50);
            buttonLifeline5050.TabIndex = 20;
            buttonLifeline5050.Text = "50/50";
            buttonLifeline5050.UseVisualStyleBackColor = false;
            buttonLifeline5050.Click += buttonLifeline5050_Click;
            // 
            // buttonLifelineAudience
            // 
            buttonLifelineAudience.BackColor = Color.DodgerBlue;
            buttonLifelineAudience.Cursor = Cursors.Hand;
            buttonLifelineAudience.FlatAppearance.BorderSize = 0;
            buttonLifelineAudience.FlatStyle = FlatStyle.Flat;
            buttonLifelineAudience.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLifelineAudience.ForeColor = Color.White;
            buttonLifelineAudience.Location = new Point(1056, 8);
            buttonLifelineAudience.Name = "buttonLifelineAudience";
            buttonLifelineAudience.Size = new Size(83, 50);
            buttonLifelineAudience.TabIndex = 19;
            buttonLifelineAudience.Text = "Audience";
            buttonLifelineAudience.UseVisualStyleBackColor = false;
            buttonLifelineAudience.Click += ButtonLifelineAudience_Click;
            // 
            // buttonCashOut
            // 
            buttonCashOut.BackColor = Color.DodgerBlue;
            buttonCashOut.FlatAppearance.BorderColor = Color.Black;
            buttonCashOut.FlatStyle = FlatStyle.Flat;
            buttonCashOut.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCashOut.ForeColor = Color.White;
            buttonCashOut.Location = new Point(854, 414);
            buttonCashOut.Margin = new Padding(3, 2, 3, 2);
            buttonCashOut.Name = "buttonCashOut";
            buttonCashOut.Size = new Size(285, 44);
            buttonCashOut.TabIndex = 13;
            buttonCashOut.Text = "Cash out";
            buttonCashOut.UseVisualStyleBackColor = false;
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
            startPanel.BackColor = Color.LightGray;
            startPanel.Controls.Add(startButton);
            startPanel.Location = new Point(-1, -1);
            startPanel.Name = "startPanel";
            startPanel.Size = new Size(1166, 612);
            startPanel.TabIndex = 16;
            // 
            // startButton
            // 
            startButton.BackColor = SystemColors.Control;
            startButton.FlatAppearance.BorderColor = Color.Black;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Franklin Gothic Medium Cond", 40F, FontStyle.Regular, GraphicsUnit.Point);
            startButton.Location = new Point(317, 238);
            startButton.Name = "startButton";
            startButton.Size = new Size(497, 249);
            startButton.TabIndex = 0;
            startButton.Text = "Start Game";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += StartButton_Click;
            // 
            // pannelFinal
            // 
            pannelFinal.BackColor = Color.SteelBlue;
            pannelFinal.BorderStyle = BorderStyle.FixedSingle;
            pannelFinal.Controls.Add(textBoxFinal);
            pannelFinal.Controls.Add(buttonFinal);
            pannelFinal.Location = new Point(2, -1);
            pannelFinal.Name = "pannelFinal";
            pannelFinal.Size = new Size(1166, 612);
            pannelFinal.TabIndex = 17;
            pannelFinal.Visible = false;
            // 
            // textBoxFinal
            // 
            textBoxFinal.BackColor = Color.LightGray;
            textBoxFinal.BorderStyle = BorderStyle.None;
            textBoxFinal.Font = new Font("Arial", 19F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxFinal.Margin = new Padding(3, 2, 3, 2);
            textBoxFinal.ReadOnly = true;
            textBoxFinal.ScrollBars = RichTextBoxScrollBars.None;

            textBoxFinal.Location = new Point(311, 35);
            textBoxFinal.Name = "textBoxFinal";
            textBoxFinal.ReadOnly = true;
            textBoxFinal.Size = new Size(497, 144);
            textBoxFinal.TabIndex = 18;
            textBoxFinal.Text = "";
            textBoxFinal.Visible = false;
            // 
            // buttonFinal
            // 
            buttonFinal.BackColor = SystemColors.Control;
            buttonFinal.FlatAppearance.BorderColor = Color.Black;
            buttonFinal.FlatStyle = FlatStyle.Flat;
            buttonFinal.Font = new Font("Franklin Gothic Medium Cond", 40F, FontStyle.Regular, GraphicsUnit.Point);
            buttonFinal.Location = new Point(311, 237);
            buttonFinal.Name = "buttonFinal";
            buttonFinal.Size = new Size(497, 249);
            buttonFinal.TabIndex = 0;
            buttonFinal.Text = "Restart";
            buttonFinal.UseVisualStyleBackColor = false;
            buttonFinal.Visible = false;
            buttonFinal.Click += butonFinal_Click;
            // 
            // panelCallAFriend
            // 
            panelCallAFriend.BackColor = SystemColors.MenuHighlight;
            panelCallAFriend.Controls.Add(textBoxCallAFriend);
            panelCallAFriend.ForeColor = SystemColors.ControlText;
            panelCallAFriend.Location = new Point(44, 112);
            panelCallAFriend.Name = "panelCallAFriend";
            panelCallAFriend.Size = new Size(266, 118);
            panelCallAFriend.TabIndex = 18;
            panelCallAFriend.Visible = false;
            // 
            // textBoxCallAFriend
            // 
            textBoxCallAFriend.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxCallAFriend.Location = new Point(16, 19);
            textBoxCallAFriend.Name = "textBoxCallAFriend";
            textBoxCallAFriend.Size = new Size(228, 80);
            textBoxCallAFriend.TabIndex = 19;
            textBoxCallAFriend.Text = "";
            textBoxCallAFriend.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(44, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 52);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Location = new Point(762, 36);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 52);
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // panelAudiance
            // 
            panelAudiance.BackColor = SystemColors.MenuHighlight;
            panelAudiance.Controls.Add(textBoxAudiance);
            panelAudiance.ForeColor = SystemColors.ControlText;
            panelAudiance.Location = new Point(544, 112);
            panelAudiance.Name = "panelAudiance";
            panelAudiance.Size = new Size(266, 118);
            panelAudiance.TabIndex = 20;
            panelAudiance.Visible = false;
            // 
            // textBoxAudiance
            // 
            textBoxAudiance.Font = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxAudiance.Location = new Point(16, 19);
            textBoxAudiance.Name = "textBoxAudiance";
            textBoxAudiance.Size = new Size(233, 80);
            textBoxAudiance.TabIndex = 19;
            textBoxAudiance.Text = "";
            textBoxAudiance.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1166, 607);
            Controls.Add(panelAudiance);
            Controls.Add(startPanel);
            Controls.Add(pannelFinal);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
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
            Controls.Add(listBoxRounds);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Who Wants to Be a Millionaire";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Darken the color when mouse enters
                button.BackColor = ControlPaint.Dark(button.BackColor, 0.2f);
            }
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Restore the original color when mouse leaves
                button.BackColor = Color.DodgerBlue;
            }
        }

        private void OnButtonGreenEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Darken the color when mouse enters
                button.BackColor = Color.GreenYellow;
            }
        }

        private void OnButtonGreenLeave(object sender, EventArgs e)
        {

            if (sender is Button button)
            {
                button.BackColor = SystemColors.Control;
                // Restore the original color when mouse leaves
                //button.BackColor = Color.GreenYellow;
            }
        }

        #endregion

        private RoundedButton buttonAnswer1;
        private RoundedButton buttonAnswer3;
        private RoundedButton buttonAnswer2;
        private RoundedButton buttonAnswer4;
        private RhombusLabel labelAtext;
        private RhombusLabel labelBtext;
        private RhombusLabel labelCtext;
        private RhombusLabel labelDtext;
        private RoundedRichTextBox richTextBox1;
        private Button buttonLifelineCall;
        private Button buttonLifeline5050;
        private Button buttonLifelineAudience;
        private Button buttonCashOut;
        private ListBox listBoxRounds;
        private Panel startPanel;
        private Button startButton;
        private Panel pannelFinal;
        private Button buttonFinal;
        private RoundedRichTextBox textBoxFinal;
        private Panel panelCallAFriend;
        private RichTextBox textBoxCallAFriend;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RhombusPictureBox pictureBox1;
        private RhombusPictureBox pictureBox2;
        private Panel panelAudiance;
        private RichTextBox textBoxAudiance;
    }
}
