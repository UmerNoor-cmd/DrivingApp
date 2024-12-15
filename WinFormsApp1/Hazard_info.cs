using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Hazard_info : Form
    {
        public Hazard_info()
        {
            Text = "Instructions";
            Size = new Size(850, 450);
            StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);


            // Instructions Label
            Label instructionsLabel = new Label
            {
                Text = "This test has 3 clips. You can score up to 5 points for each hazard. You need to get 5 points or more in total to pass. \r\n\r\n" +
                "Each clip features everyday road scenes\r\ncontains one 'developing hazard'." +
                "\r\n\r\nYou get points for spotting the developing hazards as soon as they start to happen. " +
                "\r\n\r\nA developing hazard is something that would cause you to take action, like changing speed or direction." +
                "\r\n\r\nClick as soon as you see a hazard starting to develop on the video.\r\nYou don't lose points if you click and get it wrong." +
                "\r\n\r\n However, you shouldn't click continuously or in a pattern. " +
                "\r\n\r\nIn the real test you will fail if you do this. You can't Quit Once the Test Starts" +
                           "\r\n\r\nPlease read the instructions carefully before starting.",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            Controls.Add(instructionsLabel);

            // Checkbox for reading instructions
            instructionsCheckbox = new CheckBox
            {
                Text = "I have read all of the instructions",
                Location = new Point(20, instructionsLabel.Bottom + 20)
            };
            Controls.Add(instructionsCheckbox);

            // Close button
            closeButton = new Button
            {
                Text = "Play Clip",
                AutoSize = true,
                Location = new Point(20, instructionsCheckbox.Bottom + 20)
            };
            closeButton.Click += CloseButton_Click;
            Controls.Add(closeButton);
        }


        public CheckBox instructionsCheckbox;
        public Button closeButton;



        private void CloseButton_Click(object sender, EventArgs e)
        {
            // If the checkbox is checked, close the instructions window
            if (instructionsCheckbox.Checked)
            {
                Hazard_perception_test nextForm = new Hazard_perception_test();
                nextForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please read and accept the instructions before starting the quiz.");
            }
        }

    }
}
