using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PracticePage : Form
    {
        private List<Test> tests; // List of tests
        private Test? selectedTest; // The randomly selected test
        private Test? previousTest; // Keep track of the last selected test
        private int currentQuestionIndex = 0;
        private int score = 0;
        private Label trackerLabel; // Label for tracking question number
        private Button previousButton; // Previous button
        private Button nextButton; // Next button
        private Label testNameLabel; // Label to display the test name
        private PictureBox questionPictureBox; // PictureBox for question image


        public PracticePage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);

            // Create tests
            tests = new List<Test>
            {
                new Test
                {
                    Questions = new List<Question>
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
                            Text = "Identify this landmark:",
                            Options = new List<string> { "Eiffel Tower", "Big Ben", "Statue of Liberty", "Colosseum" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\STOP_SIGN_PIC.jpg") // Add a valid image file path
                        },
                        // Add more unique questions for this test
                    }
                },
                new Test
                {
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "What is the largest ocean on Earth?",
                            Options = new List<string> { "Atlantic", "Indian", "Arctic", "Pacific" },
                            CorrectOptionIndex = 3
                        },
                        new Question
                        {
                            Text = "What is the square root of 64?",
                            Options = new List<string> { "6", "7", "8", "9" },
                            CorrectOptionIndex = 2
                        },
                        // Add more unique questions for this test
                    }
                },
                new Test
                {
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Text = "What is the chemical symbol for water?",
                            Options = new List<string> { "O2", "CO2", "H2O", "NaCl" },
                            CorrectOptionIndex = 2
                        },
                        new Question
                        {
                            Text = "Which continent is known as the Dark Continent?",
                            Options = new List<string> { "Africa", "Asia", "Europe", "South America" },
                            CorrectOptionIndex = 0
                        },
                        // Add more unique questions for this test
                    }
                }
            };

            // Initialize tracker label
            trackerLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            testNameLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, 10) // Top-left corner
            };
            Controls.Add(testNameLabel);


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

            // Initialize PictureBox for question images
            questionPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(300, 200), // Default size
                Visible = false, // Initially hidden; only shown if there's an image
                Location = new Point((ClientSize.Width - 300) / 2, 200) // Centered

            };


            ShowIntroduction();
        }

        private void ShowIntroduction()
        {
            // Clear the form
            Controls.Clear();

            // Add introduction label
            Controls.Add(introLabel);

            // Add introduction image
            Controls.Add(Top_Pic);

            // Button to go back to previous form
            Controls.Add(Backform);

            Controls.Add(Test1);

            Controls.Add(Test2);

            Controls.Add(Test3);

        }




        private void LoadQuestion()
        {
            if (selectedTest == null || currentQuestionIndex >= selectedTest.Questions.Count)
            {
                ShowScore();
                return;
            }

            // Clear other controls but retain the testNameLabel
            Controls.Clear();
            Controls.Add(testNameLabel);
            Controls.Add(Quit);
            Controls.Add(showAnswerButton); // Add the Show Answer button
            Controls.Add(questionPictureBox);

            // Display tracker for question number
            trackerLabel.Text = $"Question {currentQuestionIndex + 1} of {selectedTest.Questions.Count}";
            trackerLabel.Location = new Point(ClientSize.Width - trackerLabel.Width - 20, 10); // Top-right corner
            Controls.Add(trackerLabel);

            // Display the current question
            Question currentQuestion = selectedTest.Questions[currentQuestionIndex];

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


            // Display image if available
            if (currentQuestion.Image != null)
            {
                questionPictureBox.Image = currentQuestion.Image;
                questionPictureBox.Visible = true;
            }
            else
            {
                questionPictureBox.Visible = false;
            }


            // Add Previous and Next buttons
            previousButton.Location = new Point(10, yPosition + 10);
            nextButton.Location = new Point(ClientSize.Width - nextButton.Width - 10, yPosition + 10);
            Quit.Location = new Point(10, yPosition + 40);
            showAnswerButton.Location = new Point(ClientSize.Width - showAnswerButton.Width - 10, yPosition + 40); // Below the Quit button


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
                    if (selectedOption == selectedTest?.Questions[currentQuestionIndex].CorrectOptionIndex)
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



            // Save the score globally with the test index
            if (selectedTest != null)
            {
                int testIndex = tests.IndexOf(selectedTest) + 1; // Test index starts from 1
                GlobalData.PracticeScores[testIndex] = score; // Save the score for this test
            }

            // Display the final score
            Label scoreLabel = new Label
            {
                Text = $"Quiz Completed!\nYour score: {score} out of {selectedTest?.Questions.Count}",
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

        private void Test1_Click(object sender, EventArgs e)
        {
            StartTest(0);
        }

        private void Test2_Click(object sender, EventArgs e)
        {
            StartTest(1);
        }

        private void Test3_Click(object sender, EventArgs e)
        {
            StartTest(2);
        }

        private void StartTest(int testIndex)
        {
            selectedTest = tests[testIndex];
            currentQuestionIndex = 0;
            score = 0;

            // Update the test name label
            testNameLabel.Text = $"Test {testIndex + 1}";
            LoadQuestion();
        }


        private void Quit_Click(object sender, EventArgs e)
        {
            // Reset test-related variables
            selectedTest = null;
            previousTest = null;
            currentQuestionIndex = 0;
            score = 0;

            // Return to the introduction screen
            ShowIntroduction();
        }

        private void showAnswerButton_Click(object sender, EventArgs e)
        {
            if (selectedTest == null || currentQuestionIndex >= selectedTest.Questions.Count)
            {
                MessageBox.Show("No question loaded to show the answer.");
                return;
            }

            // Find the correct answer for the current question
            Question currentQuestion = selectedTest.Questions[currentQuestionIndex];
            int correctOptionIndex = currentQuestion.CorrectOptionIndex;

            // Iterate through controls to find the RadioButton with the correct answer
            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton && (int)radioButton.Tag == correctOptionIndex)
                {
                    radioButton.BackColor = Color.LightGreen; // Highlight the correct answer
                    break;
                }
            }
        }
    }

    // Helper class to represent a test
    public class Test
    {
        public List<Question> Questions { get; set; } = new List<Question>();
    }

    // Helper class to represent a question
    public class Question
    {
        public string? Text { get; set; }
        public List<string>? Options { get; set; }
        public int CorrectOptionIndex { get; set; }
        public Image? Image { get; set; } // New property for image

    }


}
