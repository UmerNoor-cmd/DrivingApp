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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PracticePage));
            introLabel = new Label();
            startButton = new Button();
            Top_Pic = new PictureBox();
            Next = new Button();
            Previous = new Button();
            Backform = new Button();
            ((System.ComponentModel.ISupportInitialize)Top_Pic).BeginInit();
            SuspendLayout();
            // 
            // introLabel
            // 
            introLabel.AutoSize = true;
            introLabel.Location = new Point(220, 175);
            introLabel.Name = "introLabel";
            introLabel.Size = new Size(374, 75);
            introLabel.TabIndex = 0;
            introLabel.Text = resources.GetString("introLabel.Text");
            introLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            startButton.Location = new Point(378, 253);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 2;
            startButton.Text = "Start Quiz";
            startButton.UseVisualStyleBackColor = true;
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
            // PracticePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Backform);
            Controls.Add(Next);
            Controls.Add(Previous);
            Controls.Add(Top_Pic);
            Controls.Add(startButton);
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
        private Button startButton;
        private PictureBox Top_Pic;
        private Button Next;
        private Button Previous;
        private Button Backform;
    }
}