using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Progress_Page : Form
    {
        private Dictionary<int, int> mockTestScores; // Dictionary to store mock test scores
        private Dictionary<int, int> practiceTestScores; // Dictionary to store practice test scores
        private const int PassingScorePercentage = 70; // Passing percentage
        private Dictionary<int, int> testQuestions = new Dictionary<int, int>
        {
            { 1, 30 }, // Test 1 has 2 questions
            { 2, 30 }, // Test 2 has 2 questions
            { 3, 30 }  // Test 3 has 2 questions
        };

        public Progress_Page(Dictionary<int, int> mockScores, Dictionary<int, int> practiceScores)
        {
            InitializeComponent();

            // Initialize scores
            mockTestScores = mockScores;
            practiceTestScores = practiceScores;

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

            // Add mock test progress
            Label mockProgressLabel = new Label
            {
                Text = "Mock Test Progress",
                Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline),
                AutoSize = true,
                Location = new Point(20, yPosition)
            };
            Controls.Add(mockProgressLabel);

            yPosition += 30;

            foreach (var testNumber in testQuestions.Keys)
            {
                AddProgressRow("Test", testNumber, mockTestScores, ref yPosition);
            }

            // Add practice test progress
            Label practiceProgressLabel = new Label
            {
                Text = "Practice Test Progress",
                Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline),
                AutoSize = true,
                Location = new Point(20, yPosition)
            };
            Controls.Add(practiceProgressLabel);

            yPosition += 30;

            foreach (var testNumber in testQuestions.Keys)
            {
                AddProgressRow("Test", testNumber, practiceTestScores, ref yPosition);
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

        private void AddProgressRow(string category, int testNumber, Dictionary<int, int> scores, ref int yPosition)
        {
            // Display test label
            Label testLabel = new Label
            {
                Text = $"{category} {testNumber}",
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, yPosition)
            };
            Controls.Add(testLabel);

            // Calculate percentage
            int percentage = scores.ContainsKey(testNumber) && testQuestions.ContainsKey(testNumber)
                ? (scores[testNumber] * 100) / testQuestions[testNumber]
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

            // Display percentage text
            Label scoreLabel = new Label
            {
                Text = scores.ContainsKey(testNumber)
                    ? $"{percentage}%"
                    : "Not Attempted",
                Font = new Font("Arial", 10, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(progressBar.Right + 10, yPosition)
            };
            Controls.Add(scoreLabel);

            yPosition += 40; // Increment position for the next row
        }

        private void BackToMain_Click(object sender, EventArgs e)
        {
            MainPage nextForm = new MainPage();
            nextForm.Show();
            this.Hide();
        }
    }
}
