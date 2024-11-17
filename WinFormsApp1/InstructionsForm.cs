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
    public partial class InstructionsForm : Form
    {

            public CheckBox instructionsCheckbox;
            public Button closeButton;

            public InstructionsForm()
            {
                Text = "Instructions";
                Size = new Size(800, 300);
                StartPosition = FormStartPosition.CenterScreen;

                // Instructions Label
                Label instructionsLabel = new Label
                {
                    Text = "This is a time-limited test. You will have 30 seconds to complete each question.\n\n" +
                           "Once you start the quiz, the timer will begin, and your result will be recorded as your real attempt.\n\n" +
                           "Please read the instructions carefully before starting.",
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
                    Text = "Close",
                    AutoSize = true,
                    Location = new Point(20, instructionsCheckbox.Bottom + 20)
                };
                closeButton.Click += CloseButton_Click;
                Controls.Add(closeButton);
            }

            private void CloseButton_Click(object sender, EventArgs e)
            {
                // If the checkbox is checked, close the instructions window
                if (instructionsCheckbox.Checked)
                {
                    MockTest_Page nextForm = new MockTest_Page();
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

