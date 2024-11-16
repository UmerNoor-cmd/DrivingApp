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
            SuspendLayout();
            // 
            // Orders_Signs
            // 
            Orders_Signs.BackgroundImage = Properties.Resources.StopSIgn;
            Orders_Signs.BackgroundImageLayout = ImageLayout.Stretch;
            Orders_Signs.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Orders_Signs.ForeColor = Color.Black;
            Orders_Signs.Location = new Point(12, 12);
            Orders_Signs.Name = "Orders_Signs";
            Orders_Signs.Size = new Size(236, 161);
            Orders_Signs.TabIndex = 0;
            Orders_Signs.Text = "Signs Giving Order";
            Orders_Signs.TextAlign = ContentAlignment.TopCenter;
            Orders_Signs.TextImageRelation = TextImageRelation.TextAboveImage;
            Orders_Signs.UseVisualStyleBackColor = true;
            Orders_Signs.Click += this.Orders_Signs_Click;
            // 
            // Warning_sign
            // 
            Warning_sign.BackgroundImage = Properties.Resources.StopSIgn;
            Warning_sign.BackgroundImageLayout = ImageLayout.Stretch;
            Warning_sign.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Warning_sign.ForeColor = Color.Black;
            Warning_sign.Location = new Point(285, 12);
            Warning_sign.Name = "Warning_sign";
            Warning_sign.Size = new Size(236, 161);
            Warning_sign.TabIndex = 1;
            Warning_sign.Text = "Warning Signs";
            Warning_sign.TextAlign = ContentAlignment.TopCenter;
            Warning_sign.TextImageRelation = TextImageRelation.TextAboveImage;
            Warning_sign.UseVisualStyleBackColor = true;
            Warning_sign.Click += this.Warning_sign_Click;
            // 
            // Direction_Sign
            // 
            Direction_Sign.BackgroundImage = Properties.Resources.StopSIgn;
            Direction_Sign.BackgroundImageLayout = ImageLayout.Stretch;
            Direction_Sign.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Direction_Sign.ForeColor = Color.Black;
            Direction_Sign.Location = new Point(552, 12);
            Direction_Sign.Name = "Direction_Sign";
            Direction_Sign.Size = new Size(236, 161);
            Direction_Sign.TabIndex = 2;
            Direction_Sign.Text = "Direction Signs";
            Direction_Sign.TextAlign = ContentAlignment.TopCenter;
            Direction_Sign.TextImageRelation = TextImageRelation.TextAboveImage;
            Direction_Sign.UseVisualStyleBackColor = true;
            Direction_Sign.Click += this.Direction_Sign_Click;
            // 
            // Information_Sign
            // 
            Information_Sign.BackgroundImage = Properties.Resources.StopSIgn;
            Information_Sign.BackgroundImageLayout = ImageLayout.Stretch;
            Information_Sign.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Information_Sign.ForeColor = Color.Black;
            Information_Sign.Location = new Point(148, 203);
            Information_Sign.Name = "Information_Sign";
            Information_Sign.Size = new Size(236, 161);
            Information_Sign.TabIndex = 3;
            Information_Sign.Text = "Information Signs";
            Information_Sign.TextAlign = ContentAlignment.TopCenter;
            Information_Sign.TextImageRelation = TextImageRelation.TextAboveImage;
            Information_Sign.UseVisualStyleBackColor = true;
            // 
            // RoadWork_Signs
            // 
            RoadWork_Signs.BackgroundImage = Properties.Resources.StopSIgn;
            RoadWork_Signs.BackgroundImageLayout = ImageLayout.Stretch;
            RoadWork_Signs.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoadWork_Signs.ForeColor = Color.Black;
            RoadWork_Signs.Location = new Point(431, 203);
            RoadWork_Signs.Name = "RoadWork_Signs";
            RoadWork_Signs.Size = new Size(236, 161);
            RoadWork_Signs.TabIndex = 4;
            RoadWork_Signs.Text = "Road Work Signs";
            RoadWork_Signs.TextAlign = ContentAlignment.TopCenter;
            RoadWork_Signs.TextImageRelation = TextImageRelation.TextAboveImage;
            RoadWork_Signs.UseVisualStyleBackColor = true;
            // 
            // Traffic_Signs_page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RoadWork_Signs);
            Controls.Add(Information_Sign);
            Controls.Add(Direction_Sign);
            Controls.Add(Warning_sign);
            Controls.Add(Orders_Signs);
            Name = "Traffic_Signs_page";
            Text = "Traffic Signs Page";
            ResumeLayout(false);
        }

        #endregion

        private Button Orders_Signs;
        private Button Warning_sign;
        private Button Direction_Sign;
        private Button Information_Sign;
        private Button RoadWork_Signs;
    }
}