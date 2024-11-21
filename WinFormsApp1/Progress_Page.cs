using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Progress_Page : Form
    {
        private Dictionary<int, int> mockTestScores; // Mock test scores
        private Dictionary<int, int> practiceTestScores; // Practice test scores
        private const int PassingScorePercentage = 70; // Passing percentage
        private Label topicsCompletedLabel;
        private Dictionary<int, int> testQuestions = new Dictionary<int, int>
        {
            { 1, 30 },
            { 2, 30 },
            { 3, 30 }
        };

        public Progress_Page(Dictionary<int, int> mockScores, Dictionary<int, int> practiceScores)
        {
            InitializeComponent();

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

            // Add View Flagged Questions button
            Button viewFlaggedQuestionsButton = new Button
            {
                Text = "View Flagged Questions",
                Size = new Size(200, 30),
                Location = new Point((ClientSize.Width - 200) / 2, yPosition + 20)
            };
            viewFlaggedQuestionsButton.Click += ViewFlaggedQuestionsButton_Click;
            Controls.Add(viewFlaggedQuestionsButton);


            // Topics Completed Label
            topicsCompletedLabel = new Label
            {
                Text = "Topics Completed: None",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, yPosition )
            };
            Controls.Add(topicsCompletedLabel);

            // Start periodic updates
            System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // Check for updates every second
            };
            updateTimer.Tick += (s, e) => UpdateTopicsCompleted();
            updateTimer.Start();

            // Add Back to Main button
            Button backToMainButton = new Button
            {
                Text = "Back to Main",
                Size = new Size(100, 30),
                Location = new Point((ClientSize.Width - 100) / 2, viewFlaggedQuestionsButton.Bottom + 20)
            };
            backToMainButton.Click += BackToMain_Click;
            Controls.Add(backToMainButton);
        }

        private void AddProgressRow(string category, int testNumber, Dictionary<int, int> scores, ref int yPosition)
        {
            Label testLabel = new Label
            {
                Text = $"{category} {testNumber}",
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, yPosition)
            };
            Controls.Add(testLabel);

            int percentage = scores.ContainsKey(testNumber) && testQuestions.ContainsKey(testNumber)
                ? (scores[testNumber] * 100) / testQuestions[testNumber]
                : 0;

            ProgressBar progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = percentage,
                Size = new Size(200, 20),
                Location = new Point(100, yPosition)
            };
            Controls.Add(progressBar);

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

            yPosition += 40;
        }

        private void ViewFlaggedQuestionsButton_Click(object sender, EventArgs e)
        {
            FlaggedQuestionsForm flaggedQuestionsForm = new FlaggedQuestionsForm();
            flaggedQuestionsForm.ShowDialog();
        }

        private void BackToMain_Click(object sender, EventArgs e)
        {
            MainPage nextForm = new MainPage();
            nextForm.Show();
            this.Hide();
        }

        private void UpdateTopicsCompleted()
        {
            Debug.WriteLine("UpdateTopicsCompleted called");
            if (topicsCompletedLabel == null)
            {
                Debug.WriteLine("topicsCompletedLabel is null!");
                return; // Exit if not initialized
            }

            if (Traffic_Signs_page.CompletedTopics.Any())
            {
                topicsCompletedLabel.Text = "Topics Completed: " +
                                            string.Join(", ", Traffic_Signs_page.CompletedTopics);
            }
            else
            {
                topicsCompletedLabel.Text = "Topics Completed: None";
            }
        }


    }
}
