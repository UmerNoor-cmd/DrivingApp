namespace WinFormsApp1
{
    partial class Road_works_signs
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
            Back.Size = new Size(39, 23);
            Back.TabIndex = 0;
            Back.Text = "<";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click_1;
            // 
            // Road_works_signs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 761);
            Controls.Add(Back);
            Name = "Road_works_signs";
            Text = "Road works signs";
            ResumeLayout(false);
        }

        #endregion

        private Button Back;
    }
}