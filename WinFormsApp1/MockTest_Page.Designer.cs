namespace WinFormsApp1
{
    partial class MockTest_Page
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
        //completed

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BacktoForm = new Button();
            SuspendLayout();
            // 
            // BacktoForm
            // 
            BacktoForm.Location = new Point(12, 12);
            BacktoForm.Name = "BacktoForm";
            BacktoForm.Size = new Size(30, 25);
            BacktoForm.TabIndex = 0;
            BacktoForm.Text = "<";
            BacktoForm.UseVisualStyleBackColor = true;
            BacktoForm.Click += BacktoForm_Click;
            // 
            // MockTest_Page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BacktoForm);
            Name = "MockTest_Page";
            Text = "Mock Test Page";
            ResumeLayout(false);
        }

        #endregion

        private Button BacktoForm;
    }
}