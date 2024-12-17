using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                        new Question { Text = "When should you use hazard warning lights while driving?", Options = new List<string> { "When your vehicle has broken down", "When parking on the pavement", "When driving in fog", "When following a slow-moving vehicle" }, CorrectOptionIndex = 0 },
                        new Question { Text = "You're driving on an icy road. What should you do when approaching a sharp bend?", Options = new List<string> { "Brake firmly and quickly", "Slow down gently in plenty of time", "Steer sharply into the bend", "Keep close to the middle of the road" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What must you do when overtaking a car at night?", Options = new List<string> { "Flash your headlights as you pass", "Sound your horn before overtaking", "Ensure you don’t dazzle other road users", "Overtake as quickly as possible" }, CorrectOptionIndex = 2 },
                        new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Cyclists must dismount", "Cycles aren't allowed", "Cycle route ahead", "Cycle in single file" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("Practice Pictorial Questions\\Cycle route ahead.png") // Add a valid image file path
                        },
                        new Question { Text = "You're driving on a motorway. What does it mean if the vehicle in front has its hazard lights on?", Options = new List<string> { "The driver is changing lanes", "There’s a traffic problem ahead", "The driver is slowing down quickly", "The vehicle is reversing" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What’s the main reason for carrying out a vehicle check before a long journey?", Options = new List<string> { "To make sure your vehicle is clean", "To avoid the risk of breaking down", "To ensure you arrive on time", "To prevent getting tired while driving" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What should you do if your mobile phone rings while driving?", Options = new List<string> { "Stop immediately to answer", "Ignore it or let voicemail take the call", "Pull over safely and then answer", "Answer it while driving slowly" }, CorrectOptionIndex = 2 },
                        new Question
                        {
                            Text = "What does this sign indicate?",
                            Options = new List<string> { "A diversion route", "A picnic area", "A pedestrian zone", "A cycle route" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("Practice Pictorial Questions\\A diversion route.png") // Add a valid image file path
                        },
                        new Question { Text = "Why is it important to check your mirrors before changing direction?", Options = new List<string> { "To make sure the road is clear behind you", "To signal correctly", "To avoid sudden stops", "To maintain a safe speed" }, CorrectOptionIndex = 0 },
                        new Question { Text = "You're driving along a country road. What should you expect to find after a bend?", Options = new List<string> { "A narrow bridge", "A clear road ahead", "A parked vehicle", "An animal or slow-moving vehicle" }, CorrectOptionIndex = 3 },
                        new Question { Text = "What’s the legal minimum tread depth for car tyres?", Options = new List<string> { "2.5 mm", "1.6 mm", "3.0 mm", "2.0 mm" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What does this sign indicate?",
                            Options = new List<string> { "Service area 30 miles ahead", "Maximum speed 30 mph", "Minimum speed 30 mph", "Lay-by 30 miles ahead" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("Practice Pictorial Questions\\Minimum speed 30 mph.png") // Add a valid image file path
                        },
                        new Question { Text = "What does it mean if a road has a solid white line along its edge?", Options = new List<string> { "No parking at any time", "No overtaking", "Edge of the carriageway", "A cycle lane" }, CorrectOptionIndex = 2 },
                        new Question { Text = "You're driving in heavy rain. What should you do if your steering suddenly feels light?", Options = new List<string> { "Steer more firmly", "Slow down gradually", "Speed up to regain control", "Brake firmly and quickly" }, CorrectOptionIndex = 1 },
                        new Question { Text = "You’re driving near a school. What should you do when the amber lights are flashing?", Options = new List<string> { "Drive past quickly", "Stop and wait for the lights to go out", "Slow down and watch for children", "Sound your horn as a warning" }, CorrectOptionIndex = 2 },
                        new Question
                        {
                            Text = "What does this sign indicate?",
                            Options = new List<string> { "Give way to oncoming vehicles", "Approaching traffic passes you on both sides", "Turn off at the next available junction", "Pass either side to get to the same destination" },
                            CorrectOptionIndex = 3,
                            Image = Image.FromFile("Practice Pictorial Questions\\Pass either side to get to the same destination.png") // Add a valid image file path
                        },
                        new Question { Text = "When are you allowed to park on the pavement?", Options = new List<string> { "If you’re loading or unloading", "If there are no road markings", "When it’s permitted by signs", "At any time in a residential area" }, CorrectOptionIndex = 2 },
                        new Question { Text = "What should you do if you see a pedestrian with a white cane and red band?", Options = new List<string> { "Give way as they’re deaf and blind", "Stop and offer help", "Flash your lights as a warning", "Sound your horn to attract attention" }, CorrectOptionIndex = 0 },
                        new Question { Text = "What must you do at a box junction with solid yellow lines?", Options = new List<string> { "Stop before entering the box", "Only enter if your exit is clear", "Wait in the box until traffic moves", "Drive through as quickly as possible" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What does a sign with a brown background show?",
                            Options = new List<string> { "Tourist directions", "Primary roads", "Motorway routes", "Minor roads" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("Practice Pictorial Questions\\Tourist directions.png") // Add a valid image file path
                        },
                        new Question { Text = "What can you do to reduce fuel consumption while driving?", Options = new List<string> { "Drive at high speeds", "Keep engine revs low", "Brake late and hard", "Change gears frequently" }, CorrectOptionIndex = 1 },
                        new Question { Text = "You're approaching a roundabout. What should you do if you see a cyclist ahead?", Options = new List<string> { "Overtake them before the roundabout", "Give them plenty of room", "Sound your horn", "Stop and let them pass" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What should you do if you become tired while driving?", Options = new List<string> { "Drive faster to get to your destination sooner", "Pull over and take a short break", "Open the windows for fresh air", "Turn up the radio to stay awake" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What information would be shown in a triangular road sign?",
                            Options = new List<string> { "Road narrows", "Ahead only", "Keep left", "Minimum speed" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("Practice Pictorial Questions\\Road narrows.png") // Add a valid image file path
                        },

                        new Question { Text = "When are you allowed to use your fog lights?", Options = new List<string> { "At any time of day or night", "Only when visibility is seriously reduced", "When driving at high speeds", "When driving in heavy traffic" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What should you do if you’re dazzled by an oncoming vehicle’s headlights?", Options = new List<string> { "Flash your own headlights", "Slow down and look to the left", "Close your eyes briefly", "Speed up to avoid the glare" }, CorrectOptionIndex = 1 },
                        new Question { Text = "You're driving on a motorway. What color are the reflective studs on the left-hand edge of the carriageway?", Options = new List<string> { "White", "Red", "Amber", "Green" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What does '25' mean on this motorway sign?",
                            Options = new List<string> { "The distance to the nearest town", "The route number of the road", "The number of the next junction", "The speed limit on the slip road" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("Practice Pictorial Questions\\The number of the next junction.png") // Add a valid image file path
                        },
                        new Question { Text = "You’re approaching traffic lights that have been green for some time. What should you do?", Options = new List<string> { "Speed up before they change", "Be ready to stop", "Maintain your speed", "Stop immediately" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What’s the main reason for a 20 mph speed limit near schools?", Options = new List<string> { "To reduce noise pollution", "To increase traffic flow", "To protect children crossing the road", "To prevent accidents during rush hour" }, CorrectOptionIndex = 2 },
                    }
                },
                new Test
                {
                    Questions = new List<Question>
                    {
                        new Question { Text = "You're driving on a wet road. How can stopping distances be affected?", Options = new List<string> { "They can be doubled", "They are halved", "They remain the same", "They are reduced by a third" }, CorrectOptionIndex = 0 },
                        new Question { Text = "What should you do if you have to stop your vehicle in an emergency?", Options = new List<string> { "Brake gently and smoothly", "Apply the parking brake immediately", "Keep both hands on the steering wheel", "Press the brake pedal firmly and avoid swerving" }, CorrectOptionIndex = 3 },
                        new Question { Text = "You're approaching a zebra crossing where pedestrians are waiting. What should you do?", Options = new List<string> { "Continue driving at the same speed", "Slow down and stop to let them cross", "Sound your horn to warn them", "Flash your headlights" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Turn left for parking area", "No through road on the left", "No entry for traffic turning left", "Turn left for ferry terminal" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("Practice Pictorial Questions\\No through road on the left.png") // Add a valid image file path
                        },

                        new Question { Text = "Why should you keep well back when following a large vehicle?", Options = new List<string> { "To see and be seen more easily", "To overtake it quickly", "To reduce fuel consumption", "To improve grip on the road" }, CorrectOptionIndex = 0 },
                        new Question { Text = "What’s the purpose of the hard shoulder on a motorway?", Options = new List<string> { "For parking during breaks", "For use in emergencies or breakdowns", "For overtaking slow vehicles", "For pedestrians to walk" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What’s the legal age for supervising a learner driver?", Options = new List<string> { "16", "18", "21", "25" }, CorrectOptionIndex = 2 },
                        new Question
                        {
                            Text = "What do these zigzag white lines mean??",
                            Options = new List<string> { "No parking at any time", "Parking allowed only for a short time", "Slow down to 20 mph", "Sounding horns isn't allowed" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("Practice Pictorial Questions\\No parking at any time.png") // Add a valid image file path
                        },
                        new Question { Text = "What must you check before towing a trailer?", Options = new List<string> { "The weight of the load", "The trailer’s registration", "The trailer’s interior", "The trailer’s fuel level" }, CorrectOptionIndex = 0 },
                        new Question { Text = "When driving at night, what should you do when meeting an oncoming vehicle?", Options = new List<string> { "Use your full beam headlights", "Flash your headlights", "Switch to dipped headlights", "Turn your headlights off" }, CorrectOptionIndex = 2 },
                        new Question { Text = "What should you do if your vehicle breaks down on a motorway?", Options = new List<string> { "Stop in the left-hand lane", "Turn on hazard warning lights and stop on the hard shoulder", "Call for help while standing in the carriageway", "Continue driving slowly" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Through traffic to use left lane", "Right-hand lane T-junction only", "Right-hand lane closed ahead", "\r\n11 tonne weight limit" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("Practice Pictorial Questions\\Right-hand lane closed ahead.png") // Add a valid image file path
                        },

                        new Question { Text = "What’s the main hazard when following a cyclist?", Options = new List<string> { "They might brake suddenly", "They may swerve or wobble", "They could speed up quickly", "They might signal incorrectly" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What does a circular road sign with a red border mean?", Options = new List<string> { "An instruction", "A warning", "An order", "Information" }, CorrectOptionIndex = 2 },
                        new Question { Text = "What should you do when overtaking a horse and rider?", Options = new List<string> { "Drive past quickly to reduce time near the horse", "Sound your horn to warn them", "Drive slowly and give them plenty of room", "Flash your headlights as you approach" }, CorrectOptionIndex = 2 },
                        new Question
                        {
                            Text = "You're about to overtake. What should you do when you see this sign?",
                            Options = new List<string> { "Overtake the other driver as quickly as possible", "Move to the right to get a better view", "Switch your headlights on before overtaking", "Hold back until you can see clearly ahead" },
                            CorrectOptionIndex = 3,
                            Image = Image.FromFile("Practice Pictorial Questions\\Hold back until you can see clearly ahead.png") // Add a valid image file path
                        },
                        new Question { Text = "You're driving on a narrow road. What should you do if a car is approaching from the opposite direction?", Options = new List<string> { "Drive faster to pass quickly", "Slow down or stop to let them pass", "Honk your horn as a warning", "Maintain your speed and direction" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What’s the speed limit for cars in a built-up area?", Options = new List<string> { "20 mph", "30 mph", "40 mph", "50 mph" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What does a broken white line down the center of the road mean?", Options = new List<string> { "You can overtake if the road is clear", "No overtaking allowed", "Pedestrian crossing ahead", "Hazard warning" }, CorrectOptionIndex = 0 },
                        new Question
                        {
                            Text = "When may you cross a double solid white line in the middle of the road?",
                            Options = new List<string> { "To pass a road maintenance vehicle travelling at 10 mph or less", "To pass a vehicle that's towing a trailer", "To pass traffic that's queuing back at a junction", "To pass a car signalling to turn left ahead" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("Practice Pictorial Questions\\To pass a road maintenance vehicle travelling at 10 mph or less.png") // Add a valid image file path
                        },

                        new Question { Text = "What should you do if you see a car stopped on the hard shoulder with its hazard lights on?", Options = new List<string> { "Stop and offer help", "Slow down and drive carefully", "Pull over and park behind them", "Continue driving unless you need help" }, CorrectOptionIndex = 3 },
                        new Question { Text = "What’s the safest way to turn left at a junction?", Options = new List<string> { "Signal late to confuse traffic", "Keep to the left and signal in good time", "Move to the center of the road", "Stop before signaling" }, CorrectOptionIndex = 1 },
                        new Question { Text = "How should you approach a junction with limited visibility?", Options = new List<string> { "Approach at normal speed", "Stop before the junction and look", "Sound your horn as you move through", "Proceed quickly to clear the junction" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What's the meaning of this traffic sign?",
                            Options = new List<string> { "Give priority to vehicles coming towards you", "You have priority over vehicles coming towards you", "End of two-way road", "Bus lane ahead" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("Practice Pictorial Questions\\You have priority over vehicles coming towards you.png") // Add a valid image file path
                        },
                        new Question { Text = "Why is it important to avoid sudden braking?", Options = new List<string> { "It reduces vehicle emissions", "It saves fuel", "It can cause skidding or loss of control", "It increases stopping distance" }, CorrectOptionIndex = 2 },
                        new Question { Text = "What does a flashing amber light at a pelican crossing mean?", Options = new List<string> { "You must stop immediately", "Give way to pedestrians already on the crossing", "Continue driving at normal speed", "Pedestrians must wait for the light to change" }, CorrectOptionIndex = 1 },
                        new Question { Text = "How should you position your car when waiting to turn right at a junction?", Options = new List<string> { "Keep to the left side of the road", "Keep as close to the center line as safe", "Position in the left lane", "Block the road to prevent overtaking" }, CorrectOptionIndex = 1 },
                        new Question
                        {
                            Text = "What should you do when you see this sign at a crossroads?",
                            Options = new List<string> { "Telephone the police", "Carry on with great care", "Maintain the same speed", "Find another route" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("Practice Pictorial Questions\\Cycle route ahead.png") // Add a valid image file path
                        },
                        new Question { Text = "What must you do if you see a red and white triangle sign?", Options = new List<string> { "Stop immediately", "Proceed without stopping", "Take extra care – it’s a warning sign", "Speed up to clear the hazard" }, CorrectOptionIndex = 2 },
                        new Question { Text = "Why should you use your mirrors before changing lanes?", Options = new List<string> { "To check for traffic approaching from behind", "To speed up safely", "To give a hand signal", "To look for pedestrians" }, CorrectOptionIndex = 0 },
                        
                    }
                },
                new Test
                {
                    Questions = new List<Question>
                    {
                        new Question { Text = "You're driving on a motorway. What does a green reflective stud indicate?", Options = new List<string> { "The edge of the carriageway", "A slip road or exit", "The central reservation", "A hard shoulder" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What should you do when driving through roadworks?", Options = new List<string> { "Ignore speed limits", "Follow the speed limit and drive carefully", "Flash your lights to warn workers", "Sound your horn continuously" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What can cause excessive tyre wear?", Options = new List<string> { "Under-inflated tyres", "High-quality road surfaces", "Frequent gear changes", "Warm weather" }, CorrectOptionIndex = 0 },
                        new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "No parking at all from Monday to Friday", "No parking on the days and times shown", "End of the urban clearway restrictions", "You can park on the days and times shown" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("Practice Pictorial Questions\\No parking on the days and times shown.png") // Add a valid image file path
                        },
                        new Question { Text = "What’s the main cause of skidding?", Options = new List<string> { "Worn tyres", "The driver’s actions", "Poor weather conditions", "High-quality roads" }, CorrectOptionIndex = 1 },
                        new Question { Text = "When must you use dipped headlights?", Options = new List<string> { "At dawn and dusk", "During heavy rain or fog", "In narrow country roads", "All of the above" }, CorrectOptionIndex = 3 },
                        new Question { Text = "What should you do when joining a motorway?", Options = new List<string> { "Stop at the end of the slip road", "Match your speed to traffic on the motorway", "Drive slowly and carefully", "Signal only when you’re on the motorway" }, CorrectOptionIndex = 1 },
                               new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Bridge over the road", "Water across the road", "Road ahead ends", "Uneven road surface" },
                            CorrectOptionIndex = 1,
                            Image = Image.FromFile("Practice Pictorial Questions\\Water across the road.png") // Add a valid image file path
                        },

                        new Question { Text = "You're on a motorway. What does a red 'X' sign above your lane mean?", Options = new List<string> { "Move into another lane", "Speed up and leave the lane", "Stop immediately in the lane", "Drive cautiously in the lane" }, CorrectOptionIndex = 0 },
                        new Question { Text = "Why should you check your mirrors regularly while driving?", Options = new List<string> { "To avoid stopping", "To monitor traffic around you", "To check your appearance", "To see road signs clearly" }, CorrectOptionIndex = 1 },         
                        new Question { Text = "What should you do when joining a motorway?", Options = new List<string> { "Stop at the end of the slip road", "Match your speed to traffic on the motorway", "Drive slowly and carefully", "Signal only when you’re on the motorway" }, CorrectOptionIndex = 1 },
                               new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Steep hill downwards", "Uneven road", "Steep hill upwards", "Adverse camber" },
                            CorrectOptionIndex = 0,
                            Image = Image.FromFile("Practice Pictorial Questions\\Steep hill downwards.png") // Add a valid image file path
                        },

                        new Question { Text = "When must you stop your vehicle?", Options = new List<string> { "When signalled by a pedestrian", "At a junction without traffic lights", "When signalled by a police officer", "If you're unsure of the route" }, CorrectOptionIndex = 2 },
                        new Question { Text = "What should you do if you’re dazzled by the headlights of an oncoming vehicle?", Options = new List<string> { "Look towards the left-hand edge of the road", "Flash your lights at the other driver", "Increase your speed to get past quickly", "Look directly at the oncoming lights" }, CorrectOptionIndex = 0 },
                        new Question { Text = "What should you do when joining a motorway?", Options = new List<string> { "Stop at the end of the slip road", "Match your speed to traffic on the motorway", "Drive slowly and carefully", "Signal only when you’re on the motorway" }, CorrectOptionIndex = 1 },
                               new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Wait at the crossroads", "Give way to farm vehicles", "Give way to trams", "Wait at the barriers" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("Practice Pictorial Questions\\Give way to trams.png") // Add a valid image file path
                        },

                        new Question { Text = "What does a solid white line at the side of the road indicate?", Options = new List<string> { "The road is narrow", "You can park here", "The edge of the carriageway", "There’s a pedestrian crossing ahead" }, CorrectOptionIndex = 2 },
                        new Question { Text = "How can you reduce fuel consumption while driving?", Options = new List<string> { "Drive at high speeds", "Accelerate and brake gently", "Use higher gears late", "Carry unnecessary weight" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What should you do when joining a motorway?", Options = new List<string> { "Stop at the end of the slip road", "Match your speed to traffic on the motorway", "Drive slowly and carefully", "Signal only when you’re on the motorway" }, CorrectOptionIndex = 1 },
                               new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Mini-roundabout", "Ring road", "No vehicles", "Roundabout" },
                            CorrectOptionIndex = 3,
                            Image = Image.FromFile("Practice Pictorial Questions\\Roundabout.png") // Add a valid image file path
                        },
                        new Question { Text = "You see a hazard ahead. What’s the first thing you should do?", Options = new List<string> { "Sound your horn", "Check your mirrors", "Accelerate past the hazard", "Flash your headlights" }, CorrectOptionIndex = 1 },
                        new Question { Text = "Why is it dangerous to use a mobile phone while driving?", Options = new List<string> { "It reduces your field of vision", "It increases reaction times", "It improves control of the car", "It improves awareness of hazards" }, CorrectOptionIndex = 1 },  
                        new Question { Text = "What should you do when joining a motorway?", Options = new List<string> { "Stop at the end of the slip road", "Match your speed to traffic on the motorway", "Drive slowly and carefully", "Signal only when you’re on the motorway" }, CorrectOptionIndex = 1 },
                               new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Vehicles may park on the right-hand side of the road only", "Vehicles may park on the left-hand side of the road only", "Vehicles may not park on the verge or footway", "Vehicles may park fully on the verge or footway" },
                            CorrectOptionIndex = 3,
                            Image = Image.FromFile("Practice Pictorial Questions\\Vehicles may park fully on the verge or footway.png") // Add a valid image file path
                        },
                        new Question { Text = "You’re driving on a road with a 60 mph speed limit. When would you drive at a much lower speed?", Options = new List<string> { "At night time", "In heavy rain or fog", "On dry, clear roads", "When overtaking" }, CorrectOptionIndex = 1 },
                        new Question { Text = "You’re turning right at a crossroads. An oncoming driver is also turning right. What’s the safest way to turn?", Options = new List<string> { "Turn in front of the oncoming vehicle", "Turn behind the oncoming vehicle", "Stop and signal for the other driver", "Flash your lights at the driver" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What should you do when joining a motorway?", Options = new List<string> { "Stop at the end of the slip road", "Match your speed to traffic on the motorway", "Drive slowly and carefully", "Signal only when you’re on the motorway" }, CorrectOptionIndex = 1 },
                               new Question
                        {
                            Text = "What does this sign mean?",
                            Options = new List<string> { "Multi-exit roundabout", "Six roads converge", "Risk of ice", "Place of historical interest" },
                            CorrectOptionIndex = 2,
                            Image = Image.FromFile("Practice Pictorial Questions\\Risk of ice.png") // Add a valid image file path
                        },
                        new Question { Text = "Why should you use the left-hand lane on a motorway?", Options = new List<string> { "For overtaking only", "For normal driving", "For slow vehicles only", "For emergency stops only" }, CorrectOptionIndex = 1 },
                        new Question { Text = "What should you do if your car catches fire while driving?", Options = new List<string> { "Continue driving to a safe area", "Stop, get out, and call emergency services", "Pour water on the fire immediately", "Stay in the car until help arrives" }, CorrectOptionIndex = 1 },
                        
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
            Size = new Size(1078, 481);
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

            // Update the score in the text file
            string filePath = "PracticeScores.txt";
            List<string> fileLines = File.Exists(filePath) ? new List<string>(File.ReadAllLines(filePath)) : new List<string>();
            string testIdentifier = $"Test: {testNameLabel.Text}";

            // Find if this test's score already exists
            int existingIndex = fileLines.FindIndex(line => line.StartsWith(testIdentifier));
            string updatedScoreText = $"{testIdentifier}, Score: {score}/{selectedTest?.Questions.Count}";

            if (existingIndex >= 0)
            {
                // Replace the old score with the new one
                fileLines[existingIndex] = updatedScoreText;
            }
            else
            {
                // Add the new score
                fileLines.Add(updatedScoreText);
            }

            // Write all lines back to the file
            File.WriteAllLines(filePath, fileLines);

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
