using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FlaggedQuestionsForm : Form
    {
        public FlaggedQuestionsForm()
        {
            InitializeComponent();
            DisplayFlaggedQuestions();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);
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

            // Path to the file containing flagged questions
            string filePath = "Flagged_Questions.txt";

            if (!File.Exists(filePath))
            {
                Label noDataLabel = new Label
                {
                    Text = "No flagged questions found.",
                    Font = new Font("Arial", 12, FontStyle.Italic),
                    AutoSize = true,
                    Location = new Point(20, yPosition)
                };
                scrollablePanel.Controls.Add(noDataLabel);

                Button closeButtonemp = new Button
                {
                    Text = "Close",
                    Size = new Size(100, 30),
                    Location = new Point((ClientSize.Width - 100) / 2, yPosition + 20)
                };
                closeButtonemp.Click += (s, e) => Close();
                scrollablePanel.Controls.Add(closeButtonemp);

                return;
            }

            try
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath);

                string currentTest = string.Empty;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();

                    // Check if the line contains a test identifier
                    if (line.StartsWith("Test") && line.Contains(", Question"))
                    {
                        currentTest = line; // Store the test identifier
                        Label testLabel = new Label
                        {
                            Text = currentTest,
                            Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline),
                            AutoSize = true,
                            Location = new Point(20, yPosition)
                        };
                        scrollablePanel.Controls.Add(testLabel);
                        yPosition += 30;
                    }
                    else if (line.StartsWith("Question:"))
                    {
                        string questionText = line.Substring("Question:".Length).Trim();
                        string answerText = lines[++i].Substring("Answer:".Length).Trim();

                        Label questionLabel = new Label
                        {
                            Text = $"Q: {questionText}\nA: {answerText}",
                            Font = new Font("Arial", 10, FontStyle.Regular),
                            AutoSize = true,
                            Location = new Point(40, yPosition)
                        };
                        scrollablePanel.Controls.Add(questionLabel);

                        yPosition += 50;
                    }
                }
            }
            catch (Exception ex)
            {
                Label errorLabel = new Label
                {
                    Text = $"Error reading flagged questions: {ex.Message}",
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, yPosition)
                };
                scrollablePanel.Controls.Add(errorLabel);
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
