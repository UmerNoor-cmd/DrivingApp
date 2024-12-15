namespace WinFormsApp1
{
    partial class Settings_Page
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
            button1 = new Button();
            Change_Color = new Button();
            reset = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(49, 22);
            button1.TabIndex = 0;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Change_Color
            // 
            Change_Color.Location = new Point(258, 12);
            Change_Color.Name = "Change_Color";
            Change_Color.Size = new Size(83, 70);
            Change_Color.TabIndex = 1;
            Change_Color.Text = "Change Color";
            Change_Color.UseVisualStyleBackColor = true;
            Change_Color.Click += Change_Color_Click;
            // 
            // reset
            // 
            reset.Location = new Point(133, 192);
            reset.Name = "reset";
            reset.Size = new Size(100, 38);
            reset.TabIndex = 2;
            reset.Text = "Reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // Settings_Page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 242);
            Controls.Add(reset);
            Controls.Add(Change_Color);
            Controls.Add(button1);
            Name = "Settings_Page";
            Text = "Settings_Page";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button Change_Color;
        private Button reset;
    }
}