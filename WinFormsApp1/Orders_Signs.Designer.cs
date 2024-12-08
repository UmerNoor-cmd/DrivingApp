namespace WinFormsApp1
{
    partial class Orders_Signs
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
            components = new System.ComponentModel.Container();
            questionBindingSource = new BindingSource(components);
            Back = new Button();
            ((System.ComponentModel.ISupportInitialize)questionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // questionBindingSource
            // 
            questionBindingSource.DataSource = typeof(Question);
            // 
            // Back
            // 
            Back.Location = new Point(1, 0);
            Back.Name = "Back";
            Back.Size = new Size(41, 24);
            Back.TabIndex = 0;
            Back.Text = "<";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click;
            // 
            // Orders_Signs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 761);
            Controls.Add(Back);
            Name = "Orders_Signs";
            Text = "Order_Signs_Page";
            ((System.ComponentModel.ISupportInitialize)questionBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource questionBindingSource;
        private Button Back;
    }
}