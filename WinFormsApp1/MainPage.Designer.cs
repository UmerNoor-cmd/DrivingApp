namespace WinFormsApp1
{
    partial class MainPage
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
            Practice = new Button();
            Mock_test = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // Practice
            // 
            Practice.BackColor = Color.CadetBlue;
            Practice.Cursor = Cursors.Hand;
            Practice.Location = new Point(248, 105);
            Practice.Name = "Practice";
            Practice.Size = new Size(75, 78);
            Practice.TabIndex = 0;
            Practice.Text = "PRACTISE";
            Practice.UseVisualStyleBackColor = false;
            Practice.Click += Practice_Click;
            // 
            // Mock_test
            // 
            Mock_test.BackColor = Color.Cyan;
            Mock_test.Cursor = Cursors.Hand;
            Mock_test.Location = new Point(499, 105);
            Mock_test.Name = "Mock_test";
            Mock_test.Size = new Size(75, 78);
            Mock_test.TabIndex = 1;
            Mock_test.Text = "Mock Exam";
            Mock_test.UseVisualStyleBackColor = false;
            Mock_test.Click += this.MockTest_Page_Click;
            // 
            // button3
            // 
            button3.Location = new Point(499, 215);
            button3.Name = "button3";
            button3.Size = new Size(75, 78);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(248, 215);
            button4.Name = "button4";
            button4.Size = new Size(75, 78);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(Mock_test);
            Controls.Add(Practice);
            Name = "MainPage";
            Text = "Main Page";
            ResumeLayout(false);
        }

        #endregion

        private Button Practice;
        private Button Mock_test;
        private Button button3;
        private Button button4;
    }
}
