namespace WinFormsApp1
{
    partial class PracticePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            introLabel = new Label();
            Top_Pic = new PictureBox();
            Next = new Button();
            Previous = new Button();
            Backform = new Button();
            Test1 = new Button();
            Test2 = new Button();
            Test3 = new Button();
            Quit = new Button();
            showAnswerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Top_Pic).BeginInit();
            SuspendLayout();
            // 
            // introLabel
            // 
            introLabel.AutoSize = true;
            introLabel.Location = new Point(220, 175);
            introLabel.Name = "introLabel";
            introLabel.Size = new Size(374, 60);
            introLabel.TabIndex = 0;
            introLabel.Text = "Welcome! You are about to practice the theory side of this application\r\nYou will be given 20 questions to test your knowledge\r\nChoose the test of your choice when you're ready!\r\n\r\n";
            introLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Top_Pic
            // 
            Top_Pic.Image = Properties.Resources.dual_carriageway_sunrise;
            Top_Pic.Location = new Point(220, 12);
            Top_Pic.Name = "Top_Pic";
            Top_Pic.Size = new Size(374, 160);
            Top_Pic.SizeMode = PictureBoxSizeMode.StretchImage;
            Top_Pic.TabIndex = 1;
            Top_Pic.TabStop = false;
            // 
            // Next
            // 
            Next.Location = new Point(758, 12);
            Next.Name = "Next";
            Next.Size = new Size(30, 26);
            Next.TabIndex = 4;
            Next.Text = ">";
            Next.UseVisualStyleBackColor = true;
            Next.Click += Next_Click;
            // 
            // Previous
            // 
            Previous.Location = new Point(722, 12);
            Previous.Name = "Previous";
            Previous.Size = new Size(30, 26);
            Previous.TabIndex = 3;
            Previous.Text = "<";
            Previous.UseVisualStyleBackColor = true;
            Previous.Click += Previous_Click;
            // 
            // Backform
            // 
            Backform.Location = new Point(12, 12);
            Backform.Name = "Backform";
            Backform.Size = new Size(30, 26);
            Backform.TabIndex = 5;
            Backform.Text = "<";
            Backform.UseVisualStyleBackColor = true;
            Backform.Click += Backform_Click;
            // 
            // Test1
            // 
            Test1.Location = new Point(171, 253);
            Test1.Name = "Test1";
            Test1.Size = new Size(96, 88);
            Test1.TabIndex = 6;
            Test1.Text = "Test 1";
            Test1.UseVisualStyleBackColor = true;
            Test1.Click += Test1_Click;
            // 
            // Test2
            // 
            Test2.Location = new Point(363, 253);
            Test2.Name = "Test2";
            Test2.Size = new Size(96, 88);
            Test2.TabIndex = 7;
            Test2.Text = "Test 2";
            Test2.UseVisualStyleBackColor = true;
            Test2.Click += Test2_Click;
            // 
            // Test3
            // 
            Test3.Location = new Point(551, 253);
            Test3.Name = "Test3";
            Test3.Size = new Size(96, 88);
            Test3.TabIndex = 8;
            Test3.Text = "Test 3";
            Test3.UseVisualStyleBackColor = true;
            Test3.Click += Test3_Click;
            // 
            // Quit
            // 
            Quit.Location = new Point(375, 212);
            Quit.Name = "Quit";
            Quit.Size = new Size(75, 23);
            Quit.TabIndex = 9;
            Quit.Text = "Quit Test";
            Quit.UseVisualStyleBackColor = true;
            Quit.Click += Quit_Click;
            // 
            // showAnswerButton
            // 
            showAnswerButton.Location = new Point(347, 367);
            showAnswerButton.Name = "showAnswerButton";
            showAnswerButton.Size = new Size(112, 23);
            showAnswerButton.TabIndex = 10;
            showAnswerButton.Text = "Show Answer";
            showAnswerButton.UseVisualStyleBackColor = true;
            showAnswerButton.Click += showAnswerButton_Click;
            // 
            // PracticePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showAnswerButton);
            Controls.Add(Quit);
            Controls.Add(Test3);
            Controls.Add(Test2);
            Controls.Add(Test1);
            Controls.Add(Backform);
            Controls.Add(Next);
            Controls.Add(Previous);
            Controls.Add(Top_Pic);
            Controls.Add(introLabel);
            Name = "PracticePage";
            Text = "Practice Page";
            ((System.ComponentModel.ISupportInitialize)Top_Pic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        //completed

        private Label introLabel;
        private PictureBox Top_Pic;
        private Button Next;
        private Button Previous;
        private Button Backform;
        private Button Test1;
        private Button Test2;
        private Button Test3;
        private Button Quit;
        private Button showAnswerButton;
    }
}