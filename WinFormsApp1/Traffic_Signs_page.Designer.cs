namespace WinFormsApp1
{
    partial class Traffic_Signs_page
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
            Orders_Signs = new Button();
            Warning_sign = new Button();
            Direction_Sign = new Button();
            Information_Sign = new Button();
            RoadWork_Signs = new Button();
            Giving_Order_Complete = new CheckBox();
            Warning_Signs_Complete = new CheckBox();
            Direction_Signs_Complete = new CheckBox();
            Information_Signs_Complete = new CheckBox();
            Road_Work_Complete = new CheckBox();
            BackToMain = new Button();
            SuspendLayout();
            // 
            // Orders_Signs
            // 
            Orders_Signs.BackgroundImage = Properties.Resources.StopSIgn;
            Orders_Signs.BackgroundImageLayout = ImageLayout.Stretch;
            Orders_Signs.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Orders_Signs.ForeColor = Color.Black;
            Orders_Signs.Location = new Point(68, 39);
            Orders_Signs.Name = "Orders_Signs";
            Orders_Signs.Size = new Size(236, 161);
            Orders_Signs.TabIndex = 0;
            Orders_Signs.Text = "Signs Giving Order";
            Orders_Signs.TextAlign = ContentAlignment.TopCenter;
            Orders_Signs.TextImageRelation = TextImageRelation.TextAboveImage;
            Orders_Signs.UseVisualStyleBackColor = true;
            Orders_Signs.Click += Orders_Signs_Click;
            // 
            // Warning_sign
            // 
            Warning_sign.BackgroundImage = Properties.Resources.StopSIgn;
            Warning_sign.BackgroundImageLayout = ImageLayout.Stretch;
            Warning_sign.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Warning_sign.ForeColor = Color.Black;
            Warning_sign.Location = new Point(325, 39);
            Warning_sign.Name = "Warning_sign";
            Warning_sign.Size = new Size(236, 161);
            Warning_sign.TabIndex = 1;
            Warning_sign.Text = "Warning Signs";
            Warning_sign.TextAlign = ContentAlignment.TopCenter;
            Warning_sign.TextImageRelation = TextImageRelation.TextAboveImage;
            Warning_sign.UseVisualStyleBackColor = true;
            Warning_sign.Click += Warning_sign_Click;
            // 
            // Direction_Sign
            // 
            Direction_Sign.BackgroundImage = Properties.Resources.StopSIgn;
            Direction_Sign.BackgroundImageLayout = ImageLayout.Stretch;
            Direction_Sign.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Direction_Sign.ForeColor = Color.Black;
            Direction_Sign.Location = new Point(592, 39);
            Direction_Sign.Name = "Direction_Sign";
            Direction_Sign.Size = new Size(236, 161);
            Direction_Sign.TabIndex = 2;
            Direction_Sign.Text = "Direction Signs";
            Direction_Sign.TextAlign = ContentAlignment.TopCenter;
            Direction_Sign.TextImageRelation = TextImageRelation.TextAboveImage;
            Direction_Sign.UseVisualStyleBackColor = true;
            Direction_Sign.Click += Direction_Sign_Click;
            // 
            // Information_Sign
            // 
            Information_Sign.BackgroundImage = Properties.Resources.StopSIgn;
            Information_Sign.BackgroundImageLayout = ImageLayout.Stretch;
            Information_Sign.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Information_Sign.ForeColor = Color.Black;
            Information_Sign.Location = new Point(68, 254);
            Information_Sign.Name = "Information_Sign";
            Information_Sign.Size = new Size(236, 161);
            Information_Sign.TabIndex = 3;
            Information_Sign.Text = "Information Signs";
            Information_Sign.TextAlign = ContentAlignment.TopCenter;
            Information_Sign.TextImageRelation = TextImageRelation.TextAboveImage;
            Information_Sign.UseVisualStyleBackColor = true;
            Information_Sign.Click += Information_Sign_Click;
            // 
            // RoadWork_Signs
            // 
            RoadWork_Signs.BackgroundImage = Properties.Resources.StopSIgn;
            RoadWork_Signs.BackgroundImageLayout = ImageLayout.Stretch;
            RoadWork_Signs.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoadWork_Signs.ForeColor = Color.Black;
            RoadWork_Signs.Location = new Point(592, 254);
            RoadWork_Signs.Name = "RoadWork_Signs";
            RoadWork_Signs.Size = new Size(236, 161);
            RoadWork_Signs.TabIndex = 4;
            RoadWork_Signs.Text = "Road Work Signs";
            RoadWork_Signs.TextAlign = ContentAlignment.TopCenter;
            RoadWork_Signs.TextImageRelation = TextImageRelation.TextAboveImage;
            RoadWork_Signs.UseVisualStyleBackColor = true;
            RoadWork_Signs.Click += RoadWork_Signs_Click;
            // 
            // Giving_Order_Complete
            // 
            Giving_Order_Complete.AutoSize = true;
            Giving_Order_Complete.Location = new Point(68, 206);
            Giving_Order_Complete.Name = "Giving_Order_Complete";
            Giving_Order_Complete.Size = new Size(78, 19);
            Giving_Order_Complete.TabIndex = 5;
            Giving_Order_Complete.Text = "Complete";
            Giving_Order_Complete.UseVisualStyleBackColor = true;
            Giving_Order_Complete.CheckedChanged += Giving_Order_Complete_CheckedChanged;
            // 
            // Warning_Signs_Complete
            // 
            Warning_Signs_Complete.AutoSize = true;
            Warning_Signs_Complete.Location = new Point(325, 206);
            Warning_Signs_Complete.Name = "Warning_Signs_Complete";
            Warning_Signs_Complete.Size = new Size(78, 19);
            Warning_Signs_Complete.TabIndex = 6;
            Warning_Signs_Complete.Text = "Complete";
            Warning_Signs_Complete.UseVisualStyleBackColor = true;
            Warning_Signs_Complete.CheckedChanged += Warning_Signs_Complete_CheckedChanged;
            // 
            // Direction_Signs_Complete
            // 
            Direction_Signs_Complete.AutoSize = true;
            Direction_Signs_Complete.Location = new Point(592, 206);
            Direction_Signs_Complete.Name = "Direction_Signs_Complete";
            Direction_Signs_Complete.Size = new Size(78, 19);
            Direction_Signs_Complete.TabIndex = 7;
            Direction_Signs_Complete.Text = "Complete";
            Direction_Signs_Complete.UseVisualStyleBackColor = true;
            Direction_Signs_Complete.CheckedChanged += Direction_Signs_Complete_CheckedChanged;
            // 
            // Information_Signs_Complete
            // 
            Information_Signs_Complete.AutoSize = true;
            Information_Signs_Complete.Location = new Point(68, 421);
            Information_Signs_Complete.Name = "Information_Signs_Complete";
            Information_Signs_Complete.Size = new Size(78, 19);
            Information_Signs_Complete.TabIndex = 8;
            Information_Signs_Complete.Text = "Complete";
            Information_Signs_Complete.UseVisualStyleBackColor = true;
            Information_Signs_Complete.CheckedChanged += Information_Signs_Complete_CheckedChanged;
            // 
            // Road_Work_Complete
            // 
            Road_Work_Complete.AutoSize = true;
            Road_Work_Complete.Location = new Point(592, 421);
            Road_Work_Complete.Name = "Road_Work_Complete";
            Road_Work_Complete.Size = new Size(78, 19);
            Road_Work_Complete.TabIndex = 9;
            Road_Work_Complete.Text = "Complete";
            Road_Work_Complete.UseVisualStyleBackColor = true;
            Road_Work_Complete.CheckedChanged += Road_Work_Complete_CheckedChanged;
            // 
            // BackToMain
            // 
            BackToMain.Location = new Point(12, 12);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(31, 23);
            BackToMain.TabIndex = 10;
            BackToMain.Text = "<";
            BackToMain.UseVisualStyleBackColor = true;
            BackToMain.Click += BackToMain_Click;
            // 
            // Traffic_Signs_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 518);
            Controls.Add(BackToMain);
            Controls.Add(Road_Work_Complete);
            Controls.Add(Information_Signs_Complete);
            Controls.Add(Direction_Signs_Complete);
            Controls.Add(Warning_Signs_Complete);
            Controls.Add(Giving_Order_Complete);
            Controls.Add(RoadWork_Signs);
            Controls.Add(Information_Sign);
            Controls.Add(Direction_Sign);
            Controls.Add(Warning_sign);
            Controls.Add(Orders_Signs);
            Name = "Traffic_Signs_page";
            Text = "Traffic Signs Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Orders_Signs;
        private Button Warning_sign;
        private Button Direction_Sign;
        private Button Information_Sign;
        private Button RoadWork_Signs;
        private CheckBox Giving_Order_Complete;
        private CheckBox Warning_Signs_Complete;
        private CheckBox Direction_Signs_Complete;
        private CheckBox Information_Signs_Complete;
        private CheckBox Road_Work_Complete;
        private Button BackToMain;
    }
}