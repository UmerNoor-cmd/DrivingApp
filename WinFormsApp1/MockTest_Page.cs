using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MockTest_Page : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        private Label trackerLabel; // Label for tracking question number
        private Button previousButton; // Previous button
        private Button nextButton; // Next button

        private System.Windows.Forms.Timer quizTimer; // Timer object
        private Label timerLabel; // Label for the timer
        private int timeRemaining = 30; // Countdown time in seconds

        public MockTest_Page()
        {
            InitializeComponent();

            questions = new List<Question>
            {
                new Question
                {
                    Text = "What is the capital of France?",
                    Options = new List<string> { "Berlin", "Madrid", "Paris", "Rome" },
                    CorrectOptionIndex = 2
                },
                new Question
                {
                    Text = "Which planet is known as the Red Planet?",
                    Options = new List<string> { "Earth", "Mars", "Jupiter", "Saturn" },
                    CorrectOptionIndex = 1
                },
                new Question
                {
                    Text = "What is the largest ocean on Earth?",
                    Options = new List<string> { "Atlantic", "Indian", "Arctic", "Pacific" },
                    CorrectOptionIndex = 3
                }
            };

            trackerLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            previousButton = new Button
            {
                Text = "Previous",
                AutoSize = true
            };
            previousButton.Click += Previous_Click;

            nextButton = new Button
            {
                Text = "Next",
                AutoSize = true
            };
            nextButton.Click += Next_Click;

            ShowIntroduction();
        }

        private void ShowIntroduction()
        {
            Controls.Clear();

            Label mockTestIntroLabel = new Label
            {
                Text = "Welcome to the Mock Test! You will be given 10 questions.",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point((ClientSize.Width - 300) / 2, 50)
            };
            Controls.Add(mockTestIntroLabel);

            Button mockTestStartButton = new Button
            {
                Text = "Start Test",
                AutoSize = true,
                Location = new Point((ClientSize.Width - 100) / 2, 100)
            };
            mockTestStartButton.Click += StartQuizButton_Click;
            Controls.Add(mockTestStartButton);
        }

        private void StartQuizButton_Click(object? sender, EventArgs e)
        {
            InitializeTimer();
            LoadQuestion();
        }

        private void InitializeTimer()
        {
            if (quizTimer == null)
            {
                quizTimer = new System.Windows.Forms.Timer();
                quizTimer.Interval = 1000; // 1-second intervals
                quizTimer.Tick += QuizTimer_Tick;
            }

            quizTimer.Start();

            timerLabel = new Label
            {
                Text = $"Time Left: {timeRemaining} seconds",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(10, 10)
            };
            Controls.Add(timerLabel);
        }

        private void QuizTimer_Tick(object? sender, EventArgs e)
        {
            timeRemaining--;

            if (timeRemaining <= 0)
            {
                quizTimer.Stop();
                ShowScore();
            }
            else
            {
                timerLabel.Text = $"Time Left: {timeRemaining} seconds";
            }
        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
            {
                quizTimer.Stop();
                ShowScore();
                return;
            }

            Controls.Clear();
            Controls.Add(timerLabel); // Ensure the timer label is always displayed

            trackerLabel.Text = $"Question {currentQuestionIndex + 1} of {questions.Count}";
            trackerLabel.Location = new Point(ClientSize.Width - trackerLabel.Width - 20, 10);
            Controls.Add(trackerLabel);

            Question currentQuestion = questions[currentQuestionIndex];

            Label questionLabel = new Label
            {
                Text = currentQuestion.Text,
                AutoSize = true
            };
            questionLabel.Location = new Point((ClientSize.Width - questionLabel.Width) / 2, 50);
            Controls.Add(questionLabel);

            int yPosition = questionLabel.Bottom + 20;
            for (int i = 0; i < currentQuestion.Options.Count; i++)
            {
                RadioButton optionButton = new RadioButton
                {
                    Text = currentQuestion.Options[i],
                    AutoSize = true,
                    Tag = i
                };
                optionButton.Location = new Point((ClientSize.Width - optionButton.Width) / 2, yPosition);
                Controls.Add(optionButton);
                yPosition += 30;
            }

            previousButton.Location = new Point(10, yPosition + 10);
            nextButton.Location = new Point(ClientSize.Width - nextButton.Width - 10, yPosition + 10);

            Controls.Add(previousButton);
            Controls.Add(nextButton);
        }

        private void Previous_Click(object? sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                LoadQuestion();
            }
        }

        private void Next_Click(object? sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    if (radioButton.Tag is int selectedOption)
                    {
                        if (selectedOption == questions[currentQuestionIndex].CorrectOptionIndex)
                        {
                            score++;
                        }

                        currentQuestionIndex++;
                        LoadQuestion();
                        return;
                    }
                }
            }

            MessageBox.Show("Please select an option before proceeding.");
        }

        private void ShowScore()
        {
            Controls.Clear();

            Label scoreLabel = new Label
            {
                Text = $"Test Completed!\nYour score: {score} out of {questions.Count}",
                AutoSize = true
            };
            scoreLabel.Location = new Point((ClientSize.Width - scoreLabel.Width) / 2, 100);
            Controls.Add(scoreLabel);

            Button finishButton = new Button
            {
                Text = "Finish",
                AutoSize = true
            };
            finishButton.Location = new Point((ClientSize.Width - finishButton.Width) / 2, scoreLabel.Bottom + 20);
            finishButton.Click += (s, e) => ShowIntroduction();
            Controls.Add(finishButton);
        }
    }


}
