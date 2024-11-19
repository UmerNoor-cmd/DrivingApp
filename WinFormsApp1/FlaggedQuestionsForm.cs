using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FlaggedQuestionsForm : Form
    {
        public FlaggedQuestionsForm()
        {
            InitializeComponent();
            DisplayFlaggedQuestions();
        }

        private void DisplayFlaggedQuestions()
        {
            Controls.Clear();

            // Create a panel for scrolling
            Panel scrollablePanel = new Panel
            {
                AutoScroll = true, // Enable scrolling
                Dock = DockStyle.Fill, // Fill the entire form
            };
            Controls.Add(scrollablePanel);

            Label titleLabel = new Label
            {
                Text = "Flagged Questions",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point((ClientSize.Width - 200) / 2, 20)
            };
            scrollablePanel.Controls.Add(titleLabel);

            int yPosition = titleLabel.Bottom + 30;

            foreach (var test in GlobalData.FlaggedQuestions)
            {
                Label testLabel = new Label
                {
                    Text = $"Test {test.Key}:",
                    Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline),
                    AutoSize = true,
                    Location = new Point(20, yPosition)
                };
                scrollablePanel.Controls.Add(testLabel);

                yPosition += 30;

                foreach (int questionIndex in test.Value)
                {
                    Question question = GlobalData.AllTests[test.Key - 1][questionIndex]; // Get the flagged question
                    Label questionLabel = new Label
                    {
                        Text = $"Q: {question.Text}\nA: {question.Options[question.CorrectOptionIndex]}",
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        AutoSize = true,
                        Location = new Point(40, yPosition)
                    };
                    scrollablePanel.Controls.Add(questionLabel);

                    yPosition += 50;
                }
            }

            Button closeButton = new Button
            {
                Text = "Close",
                Size = new Size(100, 30),
                Location = new Point((ClientSize.Width - 100) / 2, yPosition + 20)
            };
            closeButton.Click += (s, e) => Close();
            scrollablePanel.Controls.Add(closeButton);

            // Adjust the size of the panel and form
            scrollablePanel.Size = new Size(ClientSize.Width, ClientSize.Height);
        }
    }
}

