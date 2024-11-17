using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Progress_Page : Form
    {
        private Dictionary<int, int> testScores; // Dictionary to store test numbers and their scores
        private const int PassingScorePercentage = 70; // Passing percentage
        private Dictionary<int, int> testQuestions = new Dictionary<int, int>
        {
            { 1, 2 }, // Test 1 has 2 questions
            { 2, 2 }, // Test 2 has 2 questions
            { 3, 2 }  // Test 3 has 2 questions
        };

        public Progress_Page(Dictionary<int, int> scores)
        {
            InitializeComponent();

            // Initialize test scores
            testScores = scores;

            InitializeProgressBar();
        }

        private void InitializeProgressBar()
        {
            Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "Progress Overview",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point((ClientSize.Width - 200) / 2, 20)
            };
            Controls.Add(titleLabel);

            int yPosition = titleLabel.Bottom + 30;

            for (int testNumber = 1; testNumber <= testQuestions.Count; testNumber++)
            {
                // Display test label
                Label testLabel = new Label
                {
                    Text = $"Test {testNumber}",
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, yPosition)
                };
                Controls.Add(testLabel);

                // Calculate the percentage score
                int percentage = testScores.ContainsKey(testNumber) && testQuestions.ContainsKey(testNumber)
                    ? (testScores[testNumber] * 100) / testQuestions[testNumber]
                    : 0;

                // Display progress bar
                ProgressBar progressBar = new ProgressBar
                {
                    Minimum = 0,
                    Maximum = 100,
                    Value = percentage,
                    Size = new Size(200, 20),
                    Location = new Point(100, yPosition)
                };
                Controls.Add(progressBar);

                // Display score percentage as text
                Label scoreLabel = new Label
                {
                    Text = testScores.ContainsKey(testNumber)
                        ? $"{percentage}%"
                        : "Not Attempted",
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    AutoSize = true,
                    Location = new Point(progressBar.Right + 10, yPosition)
                };
                Controls.Add(scoreLabel);

                // Increment yPosition for the next test
                yPosition += 40;
            }

            // Add Back to Main button
            Button backToMainButton = new Button
            {
                Text = "Back to Main",
                Size = new Size(100, 30),
                Location = new Point((ClientSize.Width - 100) / 2, yPosition + 20)
            };
            backToMainButton.Click += BackToMain_Click;
            Controls.Add(backToMainButton);
        }

        private void BackToMain_Click(object sender, EventArgs e)
        {
            MainPage nextForm = new MainPage();
            nextForm.Show();
            this.Hide();
        }
    }
}
