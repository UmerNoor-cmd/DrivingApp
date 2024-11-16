using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PracticePage : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private Label trackerLabel; // Label for tracking question number
        private Button previousButton; // Previous button
        private Button nextButton; // Next button

        public PracticePage()
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

            // Initialize tracker label
            trackerLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            // Initialize navigation buttons
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
            // Clear the form
            Controls.Clear();

            // Add introduction label
            Controls.Add(introLabel);

            // Add introduction label
            Controls.Add(Top_Pic);

            //Button to go back to previous form
            Controls.Add(Backform);

            startButton.Click += StartQuizButton_Click;
            Controls.Add(startButton);
        }


        private void StartQuizButton_Click(object? sender, EventArgs e)
        {
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
            {
                ShowScore();
                return;
            }

            // Clear the form
            Controls.Clear();

            // Display tracker for question number
            trackerLabel.Text = $"Question {currentQuestionIndex + 1} of {questions.Count}";
            trackerLabel.Location = new Point(ClientSize.Width - trackerLabel.Width - 20, 10); // Top-right corner
            Controls.Add(trackerLabel);

            // Display the current question
            Question currentQuestion = questions[currentQuestionIndex];

            Label questionLabel = new Label
            {
                Text = currentQuestion.Text,
                AutoSize = true
            };
            questionLabel.Location = new Point((ClientSize.Width - questionLabel.Width) / 2, 50);
            Controls.Add(questionLabel);

            // Add radio buttons for options
            int yPosition = questionLabel.Bottom + 20;
            for (int i = 0; i < currentQuestion.Options.Count; i++)
            {
                RadioButton optionButton = new RadioButton
                {
                    Text = currentQuestion.Options[i],
                    AutoSize = true,
                    Tag = i // Store the option index
                };
                optionButton.Location = new Point((ClientSize.Width - optionButton.Width) / 2, yPosition);
                Controls.Add(optionButton);
                yPosition += 30;
            }

            // Add Previous and Next buttons
            previousButton.Location = new Point(10, yPosition + 10);
            nextButton.Location = new Point(ClientSize.Width - nextButton.Width - 10, yPosition + 10);

            Controls.Add(previousButton);
            Controls.Add(nextButton);
        }

        private void Previous_Click(object? sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--; // Go to the previous question
                LoadQuestion();
            }
        }

        private void Next_Click(object? sender, EventArgs e)
        {
            // Check if the correct answer is selected
            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    int selectedOption = (int)radioButton.Tag;
                    if (selectedOption == questions[currentQuestionIndex].CorrectOptionIndex)
                    {
                        score++; // Increment the score for a correct answer
                    }

                    currentQuestionIndex++; // Move to the next question
                    LoadQuestion();
                    return;
                }
            }

            // If no option is selected, prompt the user
            MessageBox.Show("Please select an option before proceeding.");
        }

        private void ShowScore()
        {
            // Clear the form
            Controls.Clear();

            // Display the final score
            Label scoreLabel = new Label
            {
                Text = $"Quiz Completed!\nYour score: {score} out of {questions.Count}",
                AutoSize = true
            };
            scoreLabel.Location = new Point((ClientSize.Width - scoreLabel.Width) / 2, 100);
            Controls.Add(scoreLabel);

            // Add a Finish button to close the form
            Button finishButton = new Button
            {
                Text = "Finish",
                AutoSize = true
            };
            finishButton.Location = new Point((ClientSize.Width - finishButton.Width) / 2, scoreLabel.Bottom + 20);
            finishButton.Click += (s, e) => ShowIntroduction(); // Navigate back to the start screen when clicked

            Controls.Add(finishButton);
        }

        private void Backform_Click(object sender, EventArgs e)
        {
            MainPage nextForm = new MainPage();
            nextForm.Show();
            this.Hide();
        }


    }
    //completed

    // Helper class to represent a question
    public class Question
    {
        public string? Text { get; set; }
        public List<string>? Options { get; set; }
        public int CorrectOptionIndex { get; set; }
    }
}
