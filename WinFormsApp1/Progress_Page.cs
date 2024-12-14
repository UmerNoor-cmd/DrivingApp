using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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



        private Dictionary<int, int> LoadMockScores(string filePath)
        {
            var scores = new Dictionary<int, int>();

            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File {filePath} does not exist.");
                return scores; // Return an empty dictionary if the file does not exist
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                try
                {
                    // Split the line using a format that matches the "Test: Test 1, Score: 0/3"
                    var parts = line.Split(new[] { "Test: ", ", Score: " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2
                        && parts[0].StartsWith("Test ")
                        && int.TryParse(parts[0].Replace("Test ", string.Empty), out int testNumber)
                        && int.TryParse(parts[1].Split('/')[0], out int score))
                    {
                        scores[testNumber] = score;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                }
            }

            return scores;
        }


        private Dictionary<int, int> LoadPracticeScores(string filePath)
        {
            var scores = new Dictionary<int, int>();

            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File {filePath} does not exist.");
                return scores; // Return an empty dictionary if the file does not exist
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                try
                {
                    // Split the line using a format that matches the "Test: Test 1, Score: 2/3"
                    var parts = line.Split(new[] { "Test: ", ", Score: " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2
                        && parts[0].StartsWith("Test ")
                        && int.TryParse(parts[0].Replace("Test ", string.Empty), out int testNumber)
                        && int.TryParse(parts[1].Split('/')[0], out int score))
                    {
                        scores[testNumber] = score;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                }
            }

            return scores;
        }

        public Progress_Page()
        {
            InitializeComponent();

            // Load mock test scores from the new file
            string mockScoresFilePath = "Mock_Score.txt";
            mockTestScores = LoadMockScores(mockScoresFilePath);

            // Load practice test scores from the saved file
            string practiceScoresFilePath = "PracticeScores.txt";
            practiceTestScores = LoadPracticeScores(practiceScoresFilePath);

            InitializeProgressBar();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);
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
                Location = new Point(20, yPosition)
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

            // Define the path to the file
            string filePath = "data.txt";
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File {filePath} does not exist.");
                return;
            }

            // Read the file content and parse it
            var completedTopics = new List<string>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2 && bool.TryParse(parts[1], out bool isCompleted) && isCompleted)
                    {
                        completedTopics.Add(parts[0].Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading or parsing file {filePath}: {ex.Message}");
                return;
            }

            // Update the label with the completed topics
            if (completedTopics.Any())
            {
                topicsCompletedLabel.Text = "Topics Completed: " + string.Join(", ", completedTopics);
            }
            else
            {
                topicsCompletedLabel.Text = "Topics Completed: None";
            }
        }

    }
}
