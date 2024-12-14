using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1;

namespace WinFormsApp1
{
    public partial class MockTest_Page : Form
    {
        private List<List<Question>> tests; // List of tests
        private List<Question> selectedTest; // Selected test questions
        private int currentQuestionIndex = 0;
        private int score = 0;

        private Label trackerLabel; // Label for tracking question number
        private Button previousButton; // Previous button
        private Button nextButton; // Next button

        private System.Windows.Forms.Timer quizTimer; // Timer object
        private Label timerLabel; // Label for the timer
        private int timeRemaining = 57 * 60; // Countdown time in seconds (57 minutes)
        private int testNumber = 0; // Track the current test number
        private Dictionary<int, int> testScores = new Dictionary<int, int>(); // Global dictionary to track scores
        // Add a list to store flagged questions for the selected test
        private List<int> flaggedQuestions = new List<int>();
        // Flag button
        private Button flagButton;
        private PictureBox questionPictureBox; // PictureBox for question image

        private Dictionary<int, int> userAnswers = new Dictionary<int, int>();


        public MockTest_Page()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);



            tests = GlobalData.AllTests;

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

            // Initialize the flag button
            flagButton = new Button
            {
                Text = "Flag",
                AutoSize = true
            };
            flagButton.Click += Flag_Click;

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
            Controls.Clear();

            Size = new Size(450, 200);

            Label introLabel = new Label
            {
                Text = "    Welcome to the Mock Test!\n  \nYou will be given 30 questions.",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point((ClientSize.Width-250) / 2, 10)
            };
            Controls.Add(introLabel);

            Button startButton = new Button
            {
                Text = "Start Test",
                Size = new Size(120, 50),
                Location = new Point((ClientSize.Width-100) / 2, 100)
            };
            startButton.Click += StartQuizButton_Click;

            Controls.Add(startButton);

            Controls.Add(BacktoForm);


        }


        private void StartQuizButton_Click(object? sender, EventArgs e)
        {
            // Reset test-specific variables
            currentQuestionIndex = 0;
            score = 0;

            // Randomly select one test
            Random random = new Random();
            testNumber = random.Next(tests.Count) + 1; // Track the selected test number
            selectedTest = tests[testNumber - 1];

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

            timeRemaining = 57 * 60; // 57 minutes in seconds
            quizTimer.Start();

            timerLabel = new Label
            {
                Text = $"Time Left: {FormatTime(timeRemaining)}",
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
                timerLabel.Text = $"Time Left: {FormatTime(timeRemaining)}";
            }
        }

        private string FormatTime(int seconds)
        {
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;
            return $"{minutes:D2}:{remainingSeconds:D2}";
        }

        private void LoadQuestion()
        {
            Size = new Size(1078, 481);


            if (currentQuestionIndex >= selectedTest.Count)
            {
                quizTimer.Stop();
                ShowScore();
                return;
            }
            
            Controls.Clear();
            Controls.Add(timerLabel);

            // Display the test number
            Label testLabel = new Label
            {
                Text = $"Test Number: {testNumber}",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 40),
            };
            Controls.Add(testLabel);

            trackerLabel.Text = $"Question {currentQuestionIndex + 1} of {selectedTest.Count}";
            trackerLabel.Location = new Point(ClientSize.Width - trackerLabel.Width - 20, 10);
            Controls.Add(trackerLabel);

            Question currentQuestion = selectedTest[currentQuestionIndex];

            Label questionLabel = new Label
            {
                Text = currentQuestion.Text,
                AutoSize = true,
            };
            questionLabel.Location = new Point((ClientSize.Width - questionLabel.Width) / 6, 100);
            Controls.Add(questionLabel);

            int yPosition = questionLabel.Bottom + 20;
            for (int i = 0; i < currentQuestion.Options.Count; i++)
            {
                RadioButton optionButton = new RadioButton
                {
                    Text = currentQuestion.Options[i],
                    AutoSize = true,
                    Tag = i,
                };
                optionButton.Location = new Point((ClientSize.Width - optionButton.Width) / 6, yPosition);
                Controls.Add(optionButton);
                yPosition += 30;
            }



            flagButton.Location = new Point(10, yPosition + 10);
            previousButton.Location = new Point(flagButton.Right + 10, yPosition + 10);
            nextButton.Location = new Point(ClientSize.Width - nextButton.Width - 10, yPosition + 10);

            Controls.Add(flagButton);


            // Update flag button text based on whether the current question is flagged
            flagButton.Text = flaggedQuestions.Contains(currentQuestionIndex) ? "Unflag" : "Flag";


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

            Controls.Add(previousButton);
            Controls.Add(nextButton);
            Controls.Add(questionPictureBox);

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
            // Check if the current question is flagged
            if (flaggedQuestions.Contains(currentQuestionIndex))
            {
                // Proceed to the next question without requiring an answer
                currentQuestionIndex++;
                LoadQuestion();
                return;
            }

            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    if (radioButton.Tag is int selectedOption)
                    {
                        // Store the user's answer
                        userAnswers[currentQuestionIndex] = selectedOption;

                        if (selectedOption == selectedTest[currentQuestionIndex].CorrectOptionIndex)
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

            // Save flagged questions to global data
            GlobalData.FlaggedQuestions[testNumber] = flaggedQuestions;

            // Save the score for the current test in the global data
            if (!GlobalData.TestScores.ContainsKey(testNumber))
                GlobalData.TestScores[testNumber] = score;

            // Save the score to the shared file
            SaveScoreToFile(testNumber, score);

            // Create a scrollable panel
            Panel scrollablePanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };
            Controls.Add(scrollablePanel);

            // Display the score
            Label scoreLabel = new Label
            {
                Text = $"Test Completed!\nYour score: {score} out of {selectedTest.Count}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, 10)
            };
            scrollablePanel.Controls.Add(scoreLabel);

            int yPosition = scoreLabel.Bottom + 20;

            // Display detailed results for incorrect answers
            Label reviewLabel = new Label
            {
                Text = "Review of Incorrect Questions:",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, yPosition)
            };
            scrollablePanel.Controls.Add(reviewLabel);

            yPosition = reviewLabel.Bottom + 10;

            // Loop through the questions and display only incorrect answers
            for (int i = 0; i < selectedTest.Count; i++)
            {
                Question question = selectedTest[i];
                int userAnswer = -1; // Default value for no answer
                bool isCorrect = false;

                // Determine user's selected answer
                if (userAnswers.ContainsKey(i))
                {
                    userAnswer = userAnswers[i];
                    isCorrect = userAnswer == question.CorrectOptionIndex;
                }

                // Skip correctly answered questions
                if (isCorrect)
                    continue;

                // Display the question
                Label questionLabel = new Label
                {
                    Text = $"Q{i + 1}: {question.Text}",
                    AutoSize = true,
                    Font = new Font("Arial", 10),
                    Location = new Point(10, yPosition)
                };
                scrollablePanel.Controls.Add(questionLabel);

                yPosition = questionLabel.Bottom + 5;

                // Display the options
                for (int j = 0; j < question.Options.Count; j++)
                {
                    Label optionLabel = new Label
                    {
                        Text = question.Options[j],
                        AutoSize = true,
                        Location = new Point(20, yPosition)
                    };

                    // Highlight the user's incorrect answer in red
                    if (j == userAnswer)
                    {
                        optionLabel.ForeColor = Color.Red;
                    }
                    // Highlight the correct answer in green
                    else if (j == question.CorrectOptionIndex)
                    {
                        optionLabel.ForeColor = Color.Green;
                    }

                    scrollablePanel.Controls.Add(optionLabel);
                    yPosition = optionLabel.Bottom + 5;
                }

                yPosition += 10; // Add spacing between questions
            }

            // Finish button to go back to the introduction
            Button finishButton = new Button
            {
                Text = "Finish",
                AutoSize = true,
                Location = new Point(10, yPosition + 20)
            };
            finishButton.Click += (s, e) =>
            {
                ShowIntroduction(); // Return to introduction or main menu
            };
            scrollablePanel.Controls.Add(finishButton);
        }

        // Method to save the score to a single file
        private void SaveScoreToFile(int testNumber, int score)
        {
            string filePath = "Mock_Score.txt"; // Single file for all scores

            // Format the score line for the current test
            string scoreLine = $"Test: Test {testNumber}, Score: {score}/{selectedTest.Count}";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Append the score to the file, replacing the old score for the specific test
                var lines = File.ReadAllLines(filePath).ToList();

                bool testFound = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].StartsWith($"Test: Test {testNumber}"))
                    {
                        lines[i] = scoreLine; // Replace the old score
                        testFound = true;
                        break;
                    }
                }

                if (!testFound)
                {
                    lines.Add(scoreLine); // Add the new test score if not found
                }

                File.WriteAllLines(filePath, lines); // Write the updated scores back to the file
            }
            else
            {
                // If the file does not exist, create it and write the score
                File.WriteAllText(filePath, scoreLine);
            }
        }




        private void BacktoForm_Click(object sender, EventArgs e)
        {
            MainPage nextForm = new MainPage();
            nextForm.Show();
            this.Hide();
        }

        private void Flag_Click(object? sender, EventArgs e)
        {
            string filePath = "Flagged_Questions.txt";

            Question currentQuestion = selectedTest[currentQuestionIndex];
            string flaggedQuestionEntry = $"Test {testNumber}, Question {currentQuestionIndex + 1}:{Environment.NewLine}" +
                                          $"Question: {currentQuestion.Text}{Environment.NewLine}" +
                                          $"Answer: {currentQuestion.Options[currentQuestion.CorrectOptionIndex]}{Environment.NewLine}";

            // Toggle flag for the current question
            if (flaggedQuestions.Contains(currentQuestionIndex))
            {
                flaggedQuestions.Remove(currentQuestionIndex);
                flagButton.Text = "Flag";

                // Remove the question from the file
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath).ToList();
                    // Remove the entry by finding its start and end
                    int startIndex = lines.FindIndex(line => line.StartsWith($"Test {testNumber}, Question {currentQuestionIndex + 1}:"));
                    if (startIndex != -1)
                    {
                        // Remove the related lines for the question entry
                        int endIndex = startIndex + 2; // Assuming the question has 3 lines
                        lines.RemoveRange(startIndex, endIndex - startIndex + 1);
                        File.WriteAllLines(filePath, lines);
                    }
                }
            }
            else
            {
                flaggedQuestions.Add(currentQuestionIndex);
                flagButton.Text = "Unflag";

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    // Create the file and add the current flagged question
                    File.WriteAllText(filePath, flaggedQuestionEntry + Environment.NewLine);
                }
                else
                {
                    // Append the flagged question if it doesn't already exist
                    var lines = File.ReadAllLines(filePath);
                    if (!lines.Contains($"Test {testNumber}, Question {currentQuestionIndex + 1}:"))
                    {
                        File.AppendAllText(filePath, flaggedQuestionEntry + Environment.NewLine);
                    }
                }
            }
        }


        private void MockTest_Page_Load(object sender, EventArgs e)
        {

        }
    }
    public static class GlobalData
    {
        public static Dictionary<int, int> TestScores { get; set; } = new Dictionary<int, int>();
        public static Dictionary<int, int> PracticeScores { get; set; } = new Dictionary<int, int>(); // Practice test scores

        public static Dictionary<int, List<int>> FlaggedQuestions { get; set; } = new Dictionary<int, List<int>>(); // Flagged questions

        public static List<List<Question>> AllTests { get; set; } = new List<List<Question>>
    {
        new List<Question>
            {
                new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Turn left for parking area", "No entry for traffic turning left", "No through road on the left", "Turn left for ferry terminal" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\No_through_road_on_the_left.PNG") // Add a valid image file path
                        },
                new Question{Text = "What's the purpose of road humps, chicanes and narrowings?",Options = new List<string>{"To reduce traffic speed","To separate lanes of traffic","To allow pedestrians to cross","To increase traffic speed"},CorrectOptionIndex = 0},
                new Question{Text = "What requires extra care when you're driving or riding in windy conditions?",Options = new List<string>{"Passing pedal cyclists","Turning into a narrow road","Moving off on a hill","Using the brakes"},CorrectOptionIndex = 0},
                new Question{Text = "How would age affect an older person's driving ability?",Options = new List<string>{"They'll need glasses to read road signs","They'll take longer to react to hazards","They won't signal at junctions","They won't be able to obtain car insurance"},CorrectOptionIndex = 1},
                new Question{Text = "You're waiting to come out of a side road. Why should you look carefully for motorcycles?",Options = new List<string>{"Police patrols often use motorcycles","Motorcycles are usually faster than cars","Motorcycles can easily be hidden behind obstructions","Motorcycles have right of way"},CorrectOptionIndex = 2},
                new Question{Text = "What does a red traffic light mean?",Options = new List<string>{"Proceed with care","You should stop unless turning left","Stop, if you're able to brake safely","You must stop and wait behind the stop"},CorrectOptionIndex = 3},
                new Question{Text = "What's the purpose of a catalytic converter?",Options = new List<string>{"To reduce the risk of fire","To reduce engine wear","To reduce harmful exhaust gases","To reduce fuel consumption"},CorrectOptionIndex = 2},
                new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "No cars", "Motorcycles only", "No motorcycles", "Cars only" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\No_motorcycles.PNG") // Add a valid image file path
                        },
                new Question{Text = "What must you do when you're overtaking a car at night?",Options = new List<string>{"Select a higher gear","Flash your headlights before overtaking","Make sure you don't dazzle other road users","Switch your headlights to main beam before overtaking"},CorrectOptionIndex = 2},
                new Question{Text = "You've just gone through flood water. What should you do to make sure your brakes are working properly?",Options = new List<string>{"Stop for at least an hour to allow them time to dry","Avoid using the brakes at all for a few miles","Go slowly while gently applying the brakes","Accelerate and keep to a high speed for a short time"},CorrectOptionIndex = 2},
                new Question{Text = "When should you flash your headlights at other road users?",Options = new List<string>{"When telling them that you have right of way","When letting them know that you're there","When showing that you're giving way","When showing that you're about to turn"},CorrectOptionIndex = 1},
                new Question{Text = "You're following a slower-moving vehicle. What should you do if there's a junction just ahead on the right?",Options = new List<string>{"Slow down and prepare to overtake on the left","Accelerate quickly to overtake before reaching the junction","Overtake after checking your mirrors and signalling","Only consider overtaking when you're past the junction"},CorrectOptionIndex = 3},
                new Question{Text = "You're parked on the road at night. When must you use parking lights?",Options = new List<string>{"When the speed limit exceeds 30 mph","When you're near a bus stop","When there are continuous white lines in the middle of the road","When you're facing oncoming traffic"},CorrectOptionIndex = 0},
                new Question{Text = "What should you do when you're approaching roadworks on a motorway?",Options = new List<string>{"Obey the speed limit","Stay very close to the vehicle in front","Always use the hard shoulder","Speed up to clear the area quickly"},CorrectOptionIndex = 0},
                new Question{Text = "What should you do if the left-hand pavement is closed due to street repairs?",Options = new List<string>{"Watch out for pedestrians walking in the road","Position close to the left-hand kerb","Speed up to get past the roadworks more quickly","Use your right-hand mirror more often"},CorrectOptionIndex = 0},
                new Question{Text = "What should you do immediately after joining a motorway?",Options = new List<string>{"Try to overtake","Stay in the left-hand lane","Re-adjust your mirrors","Position your vehicle in the centre lane"},CorrectOptionIndex = 1},
                new Question
                        {
                            Text = "You're on a motorway. A lorry has stopped in the right-hand lane. What should you do when you see this sign on the lorry?:",
                            Options = new List<string> { "Stop behind the flashing lights", "Move into the right-hand lane", "Pass the lorry on the left", "Leave the motorway at the next exit" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\Pass_the_lorry_on_the_left.PNG") // Add a valid image file path
                        },
                new Question{Text = "You're about to overtake a cyclist. Why should you leave them as much room as you would give to a car?",Options = new List<string>{"The cyclist might speed up","The cyclist might have to make a left turn","The cyclist might get off their bicycle","The cyclist might be unsettled if you pass too near them"},CorrectOptionIndex = 3},
                new Question{Text = "You're the first person to arrive at an incident where people are badly injured. You've switched on your hazard warning lights and checked all engines are stopped. What else should you do?",Options = new List<string>{"Stop other cars and ask the drivers for help","Move the people who are injured clear of their vehicles","Try and get people who are injured to drink something","Make sure that an ambulance has been called"},CorrectOptionIndex = 3},
                new Question{Text = "Which document may the police ask you to produce after you've been involved in a collision?",Options = new List<string>{"Your vehicle registration document","Your theory test certificate","Your driving licence","Your vehicle service record"},CorrectOptionIndex = 2},
                new Question{Text = "You've just passed your driving test. How can you reduce your risk of being involved in a collision?",Options = new List<string>{"By taking further training","By always staying close to the vehicle in front","By staying in the left-hand lane on all roads","By never going over 40 mph"},CorrectOptionIndex = 0},
                new Question{Text = "Why should you switch your headlights on when it first starts to get dark?",Options = new List<string>{"To make your dials easier to see","So others can see you more easily","To reduce battery use","Because the street lights are lit"},CorrectOptionIndex = 1},
                new Question{Text = "What should you do when you're approaching traffic lights that have been green for some time?",Options = new List<string>{"Maintain your speed","Be ready to stop","Speed up","Brake hard"},CorrectOptionIndex = 1},
                new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Bend to the right", "No traffic from the right", "No right turn", "Road on the right closed" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\No_right_turn.PNG") // Add a valid image file path
                        },                
                new Question{Text = "You're towing a small trailer on a busy three-lane motorway. When may you use the right-hand lane?",Options = new List<string>{"When there are slower vehicles in the other lanes","When you can keep up with the other traffic","When you're overtaking","You mustn't use the right-hand lane"},CorrectOptionIndex = 3},
                new Question{Text = "You're carrying two 13-year-old children and their parents in your car. Who's responsible for seeing that the children wear seat belts?",Options = new List<string>{"The front-seat passenger","You, the driver","The children","The children's parents"},CorrectOptionIndex = 1},
                new Question{Text = "How will a roof rack affect your car?",Options = new List<string>{"There will be less wind noise","The car will accelerate faster","Fuel consumption will increase","The engine will use more oil"},CorrectOptionIndex = 2},
                new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "A pedestrian zone", "A diversion route", "A picnic area", "A cycle route" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\A_diversion_route.PNG") // Add a valid image file path
                        },               
                new Question{Text = "You're turning right onto a dual carriageway. What should you do before emerging?",Options = new List<string>{"Stop, apply the handbrake and then select a low gear","Position your vehicle well to the left of the side road","Check that the central reservation is wide enough for your vehicle","Make sure that you leave enough room for a vehicle behind"},CorrectOptionIndex = 2},
                new Question{Text = "You're driving at night with your headlights on main beam. A vehicle is overtaking you. When should you dip your headlights?",Options = new List<string>{"Some time after the vehicle has passed you","Before the vehicle starts to pass you","Only if the other driver dips their headlights","As soon as the vehicle passes you"},CorrectOptionIndex = 1}},
        new List<Question>
            {
                new Question { Text = "What's the minimum time gap you should leave when following a vehicle on a wet road?", Options = new List<string> { "Two seconds", "Four seconds", "Three seconds", "One second" }, CorrectOptionIndex = 0 },
                new Question { Text = "What should you do if you want to overtake a tractor but aren't sure that it's safe?", Options = new List<string> { "Follow another vehicle as it overtakes the tractor", "Stay behind it if you're in any doubt", "Sound your horn to make the tractor driver pull over", "Speed past, flashing your lights at oncoming traffic" }, CorrectOptionIndex = 1 },
                new Question { Text = "Do you need to plan rest stops when you're planning a long journey?", Options = new List<string> { "No, only fuel stops will be needed", "Yes, you should plan to stop every half an hour", "No, you'll be less tired if you get there as soon as possible", "Yes, regular stops help concentration" }, CorrectOptionIndex = 3 },
                new Question { Text = "When would you use the right-hand lane of a two-lane dual carriageway?", Options = new List<string> { "When you're staying at the minimum allowed speed", "When you're driving at a constant high speed", "When you're turning right or overtaking", "When you're passing a side road on the left" }, CorrectOptionIndex = 2 },
                new Question { Text = "What colour are the reflective studs between the hard shoulder and the left-hand lane of a motorway?", Options = new List<string> { "Red", "Amber", "Green", "White" }, CorrectOptionIndex = 0 },                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "No waiting for buses and cycles", "No buses and cycles allowed", "With-flow bus and cycle lane", "Contraflow bus and cycle lane" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\With-flow_bus_and_cycle_lane.PNG") // Add a valid image file path
                        },
                new Question { Text = "What will be affected if the road surface becomes soft in very hot weather?", Options = new List<string> { "The suspension", "The fuel consumption", "The exhaust emissions", "The tyre grip" }, CorrectOptionIndex = 3 },
                new Question { Text = "Which vehicles are least likely to be affected by side wind?", Options = new List<string> { "Cyclists", "Cars", "Motorcyclists", "High-sided vehicles" }, CorrectOptionIndex = 1 },
                new Question { Text = "An injured motorcyclist is lying unconscious in the road. The traffic has stopped and there's no further danger. What could you do to help?", Options = new List<string> { "Move the person off the road", "Remove their leather jacket", "Remove their safety helmet", "Seek medical assistance" }, CorrectOptionIndex = 3 },
                new Question { Text = "What colour are the reflective studs between the hard shoulder and the left-hand lane of a motorway?", Options = new List<string> { "Red", "Amber", "Green", "White" }, CorrectOptionIndex = 0 },                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Minimum speed 30 mph", "Maximum speed 30 mph", "End of minimum speed", "End of maximum speed" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\End_of_minimum_speed.PNG") // Add a valid image file path
                        },
                new Question { Text = "At an incident, how could you help a small child who isn't breathing?", Options = new List<string> { "Put them in the recovery position and slap their back", "Find their parents and explain what's happening", "Talk to them confidently until an ambulance arrives", "Open their airway and begin CPR" }, CorrectOptionIndex = 3 },
                new Question { Text = "At an incident, a casualty isn't breathing. What should you do while helping them to start breathing again?", Options = new List<string> { "Open their airway", "Shake them firmly", "Roll them onto their side", "Put their arms across their chest" }, CorrectOptionIndex = 0 },
                new Question { Text = "What colour are the reflective studs between the hard shoulder and the left-hand lane of a motorway?", Options = new List<string> { "Red", "Amber", "Green", "White" }, CorrectOptionIndex = 0 },                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "They give directions to car parks", "They give temporary directions during a diversion", "They give mandatory instructions", "They give motorway information" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\They_give_mandatory_instructions.PNG") // Add a valid image file path
                        },
                new Question { Text = "How can you avoid wheelspin when you're driving on an icy road?", Options = new List<string> { "Drive at a slow speed in the highest gear possible", "Brake gently and repeatedly", "Drive in a low gear at all times", "Use the parking brake if the wheels start to slip" }, CorrectOptionIndex = 0 },
                new Question { Text = "What should you do if you become tired while you're driving on a motorway?", Options = new List<string> { "Increase your speed and turn up the radio volume", "Close all your windows and set the heating to warm", "Leave the motorway at the next exit and rest", "Pull up on the hard shoulder and change drivers" }, CorrectOptionIndex = 2 },
                new Question { Text = "What can you do to help prevent tiredness on a long journey?", Options = new List<string> { "Eat a large meal before driving", "Take regular refreshment breaks", "Play loud music in the car", "Complete the journey without stopping" }, CorrectOptionIndex = 1 },
                new Question { Text = "You're driving at night. What should you do if you're dazzled by headlights coming towards you?", Options = new List<string> { "Pull down your sun visor", "Flash your main-beam headlights", "Slow down or stop", "Shade your eyes with your hand" }, CorrectOptionIndex = 2 },
                new Question { Text = "You're driving on a busy main road. What should you do if you find that you're driving in the wrong direction?", Options = new List<string> { "Make a 'three-point' turn in the main road", "Turn into a side road on the right and reverse into the main road", "Make a U-turn in the main road", "Turn around in a side road" }, CorrectOptionIndex = 3 },
                new Question { Text = "Your car breaks down on a level crossing. What's the first thing you should do?", Options = new List<string> { "Stay in your car until you're told to move", "Leave your vehicle and get everyone clear", "Walk down the track and signal the next train", "Tell drivers behind what's happened" }, CorrectOptionIndex = 1 },                    
                new Question { Text = "What colour are the reflective studs between the hard shoulder and the left-hand lane of a motorway?", Options = new List<string> { "Red", "Amber", "Green", "White" }, CorrectOptionIndex = 0 },                    new Question

                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Tourist directions", "Minor roads", "Primary roads", "Motorway routes" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\Tourist_directions.PNG") // Add a valid image file path
                        },new Question { Text = "Your vehicle has broken down on a motorway. What should you do if you aren't able to get onto the hard shoulder?", Options = new List<string> { "Stand behind your vehicle to warn others", "Stop the traffic behind and ask for help", "Attempt to repair your vehicle quickly", "Switch on your hazard warning lights" }, CorrectOptionIndex = 3 },
                new Question { Text = "Who's responsible for paying the vehicle tax?", Options = new List<string> { "The car dealer", "The registered keeper of the vehicle", "The Driver and Vehicle Licensing Agency (DVLA)", "The driver of the vehicle" }, CorrectOptionIndex = 1 },
                new Question { Text = "What circumstances require you to notify the Driver and Vehicle Licensing Agency (DVLA)?", Options = new List<string> { "When you have to work abroad", "When your vehicle needs an MOT certificate", "When you lend your vehicle to someone", "When your health affects your driving" }, CorrectOptionIndex = 3 },
                new Question { Text = "Why are vehicles fitted with rear fog lights?", Options = new List<string> { "To make them more visible when driving at high speed", "To make them more visible in thick fog", "To warn drivers following closely to drop back", "To show when they've broken down in a dangerous position" }, CorrectOptionIndex = 1 },
                new Question { Text = "Why should you try and park in a secure car park?", Options = new List<string> { "It makes it easy to find your car", "It helps deter thieves", "It doesn't cost anything to park here", "It stops the car being exposed to bad weather" }, CorrectOptionIndex = 1 },
                new Question { Text = "What colour are the reflective studs between the hard shoulder and the left-hand lane of a motorway?", Options = new List<string> { "Red", "Amber", "Green", "White" }, CorrectOptionIndex = 0 },                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Mini-roundabout", "Roundabout", "No vehicles", "Ring road" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\Roundabout.PNG") // Add a valid image file path
                        },
                new Question { Text = "You're driving on an open road in dry weather. What distance should you keep from the vehicle in front?", Options = new List<string> { "A two-second time gap", "Two metres (6 feet 6 inches)", "One car length", "Two car lengths" }, CorrectOptionIndex = 0 }
                },
        new List<Question>
                {
                    new Question { Text = "What should you do if a driver pulls out of a side road in front of you, causing you to brake hard?", Options = new List<string> { "Flash your lights to show your annoyance", "Sound your horn to show your annoyance", "Ignore the error and stay calm", "Overtake as soon as possible" }, CorrectOptionIndex = 2 },
                    new Question { Text = "You're waiting to turn right out of a minor road. It's clear to the left but a lorry is coming from the right. Why should you wait, even if you have enough time to turn?", Options = new List<string> { "The lorry could suddenly speed up", "The lorry might be slowing down", "The load on the lorry might be unstable", "Anything overtaking the lorry will be hidden from view" }, CorrectOptionIndex = 3 },
                    new Question { Text = "What's the national speed limit on motorways for cars and motorcycles?", Options = new List<string> { "30 mph", "70 mph", "60 mph", "50 mph" }, CorrectOptionIndex = 1 },
                    new Question { Text = "Which vehicles aren't allowed to use the right-hand lane of a three-lane motorway?", Options = new List<string> { "Vehicles towing a trailer", "Motorcycles", "Small delivery vans", "Motorcycle and sidecar outfits" }, CorrectOptionIndex = 0 },
                    new Question { Text = "What colour are the reflective studs between the hard shoulder and the left-hand lane of a motorway?", Options = new List<string> { "Red", "Amber", "Green", "White" }, CorrectOptionIndex = 0 },                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Six roads converge", "Multi-exit roundabout", "Risk of ice", "Place of historical interest" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\Risk_of_ice.PNG") // Add a valid image file path
                        },
                    new Question { Text = "You're looking for somewhere to safely park your vehicle. Where would you choose to park?", Options = new List<string> { "At or near a bus stop", "On the approach to a level crossing", "In a designated parking space", "Near the brow of a hill" }, CorrectOptionIndex = 2 },
                    new Question { Text = "When may you sound your vehicle's horn?", Options = new List<string> { "To attract a friend's attention", "To give you right of way", "To warn others of your presence", "To make slower drivers move over" }, CorrectOptionIndex = 2 },
                    new Question { Text = "What should you do when you're following a motorcyclist along a road that has a poor surface?", Options = new List<string> { "Allow the same room as normal to avoid wasting road space", "Follow closely so they can see you in their mirrors", "Allow extra room in case they swerve to avoid potholes", "Overtake immediately to avoid delays" }, CorrectOptionIndex = 2 },
                    new Question { Text = "What colour are the reflective studs between the hard shoulder and the left-hand lane of a motorway?", Options = new List<string> { "Red", "Amber", "Green", "White" }, CorrectOptionIndex = 0 },                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Give way to farm vehicles", "Wait at the barriers", "Wait at the crossroads", "Give way to trams" },
                            CorrectOptionIndex = 3,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\Give_way_to_trams.PNG") // Add a valid image file path
                        },
                    new Question { Text = "What's a Statutory Off-Road Notification (SORN)?", Options = new List<string> { "A notification to tell DVSA that a vehicle doesn't have a current MOT", "Information held by insurance companies to check a vehicle is insured", "A notification to tell DVLA that a vehicle isn't being used on the road", "Information kept by the police about the owner of a vehicle" }, CorrectOptionIndex = 2 },
                    new Question { Text = "What can you expect if you drive using rapid acceleration and heavy braking?", Options = new List<string> { "Increased road safety", "Reduced exhaust emissions", "Reduced pollution", "Increased fuel consumption" }, CorrectOptionIndex = 3 },
                    new Question { Text = "You stop on the hard shoulder of a motorway and use the emergency telephone. Where's the best place to wait for help to arrive?", Options = new List<string> { "On the hard shoulder", "With your vehicle", "Well away from the carriageway", "Next to the phone" }, CorrectOptionIndex = 2 },
                    new Question { Text = "You arrive at the scene of a crash where someone is bleeding heavily from a wound in their arm. Nothing is embedded in the wound. What could you do to help?", Options = new List<string> { "Walk them around and keep them talking", "Apply pressure over the wound", "Get them a drink", "Dab the wound" }, CorrectOptionIndex = 1 },
                    new Question { Text = "A casualty isn't breathing normally and needs CPR. At what rate should you press down and release on the centre of their chest?", Options = new List<string> { "120 times per minute", "60 times per minute", "10 times per minute", "240 times per minute" }, CorrectOptionIndex = 0 },
                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Road liable to flooding", "Steep hill downwards", "Quayside or river bank", "Uneven road surface" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\Quayside_or_river_bank.PNG") // Add a valid image file path
                        },
                    new Question { Text = "What do you need before you can legally use a motor vehicle on the road?", Options = new List<string> { "A vehicle handbook", "An appropriate driving licence", "Proof of your identity", "Breakdown cover" }, CorrectOptionIndex = 1 },
                    new Question { Text = "How should you signal if you're going straight ahead at a roundabout?", Options = new List<string> { "Signal left just after you pass the exit before the one you're going to take", "Signal right on the approach and then left to leave the roundabout", "Signal left after you leave the roundabout and enter the new road", "Signal right on the approach to the roundabout and keep the signal on" }, CorrectOptionIndex = 1 },
                    new Question { Text = "A police officer asks to see your documents. You don't have them with you. How many days do you have to produce them at a police station?", Options = new List<string> { "14 days", "21 days", "7 days", "5 days" }, CorrectOptionIndex = 0 },
                    new Question { Text = "An adult casualty isn't breathing. To maintain circulation, CPR should be given. What's the correct depth to press down on their chest?", Options = new List<string> { "15 to 20 centimetres", "10 to 15 centimetres", "1 to 2 centimetres", "5 to 6 centimetres" }, CorrectOptionIndex = 1 },
                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Route for buses", "Give way to trams", "Route for trams", "Give way to buses" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\Pictorial Questions\\Route_for_trams.PNG") // Add a valid image file path
                        },
                    new Question { Text = "You're following other vehicles in fog. You have your headlights on dipped beam. What else can you do to reduce the chances of being in a collision?", Options = new List<string> { "Keep a safe distance from the vehicle in front", "Keep up with the faster vehicles", "Use main beam instead of dipped headlights", "Keep close to the vehicle in front" }, CorrectOptionIndex = 0 },
                    new Question { Text = "A collision has just happened. An injured person is lying in a busy road. What's the first thing you should do?", Options = new List<string> { "Treat the person for shock", "Place them in the recovery position", "Warn other traffic", "Make sure the injured person is kept warm" }, CorrectOptionIndex = 2 },
                    new Question { Text = "What's the main benefit of driving a four-wheel-drive vehicle?", Options = new List<string> { "Shorter stopping distances", "Lower fuel consumption", "Improved grip on the road", "Improved passenger comfort" }, CorrectOptionIndex = 2 },
                    new Question { Text = "What advice should you give to a driver who has had a few alcoholic drinks at a party?", Options = new List<string> { "Have a strong cup of coffee and then drive home", "Drive home carefully and slowly", "Go home by public transport", "Wait a short while and then drive home" }, CorrectOptionIndex = 2 },
                    new Question { Text = "You're about to reverse into a side road. What should you do if a pedestrian is waiting to cross behind your car?", Options = new List<string> { "Reverse before the pedestrian starts to cross", "Give way to the pedestrian", "Wave to the pedestrian to stop", "Sound your horn to warn the pedestrian" }, CorrectOptionIndex = 1 },
                    new Question { Text = "What's most likely to waste fuel?", Options = new List<string> { "Under-inflated tyres", "Reducing your speed", "Using different brands of fuel", "Driving on motorways" }, CorrectOptionIndex = 0 },
                    new Question
                        {
                            Text = "What Sign is this?:",
                            Options = new List<string> { "Stop Sign", "Pause Sign", "Road Cross Sign", "No Parking Sign" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("E:\\CLIENT\\WindowsFormsApp1\\STOP_SIGN_PIC.jpg") // Add a valid image file path
                        },
                    new Question { Text = "Why should you allow extra room while overtaking a motorcyclist on a windy day?", Options = new List<string> { "The rider may be blown in front of you", "The rider may stop suddenly", "The rider may be travelling faster than normal", "The rider may turn off suddenly to get out of the wind" }, CorrectOptionIndex = 0 }
                }
        };
    }
}



