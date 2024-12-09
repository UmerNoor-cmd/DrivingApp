namespace WinFormsApp1
{
    partial class Warning_Sign
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
            Back = new Button();
            SuspendLayout();
            // 
            // Back
            // 
            Back.Location = new Point(0, 0);
            Back.Name = "Back";
            Back.Size = new Size(44, 23);
            Back.TabIndex = 0;
            Back.Text = "<";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click_1;
            // 
            // Warning_Sign
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 761);
            Controls.Add(Back);
            Name = "Warning_Sign";
            Text = "Warning Sign";
            ResumeLayout(false);
        }

        #endregion

        private Button Back;
    }
}