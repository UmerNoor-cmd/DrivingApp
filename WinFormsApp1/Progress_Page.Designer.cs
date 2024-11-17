namespace WinFormsApp1
{
    partial class Progress_Page
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
            BackToMain = new Button();
            SuspendLayout();
            // 
            // BackToMain
            // 
            BackToMain.Location = new Point(21, 17);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(31, 23);
            BackToMain.TabIndex = 0;
            BackToMain.Text = "<";
            BackToMain.UseVisualStyleBackColor = true;
            BackToMain.Click += BackToMain_Click;
            // 
            // Progress_Page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BackToMain);
            Name = "Progress_Page";
            Text = "Progress Page";
            ResumeLayout(false);
        }

        #endregion

        private Button BackToMain;
    }
}