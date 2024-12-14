using AxWMPLib;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Hazard_perception_test : Form
    {
        private int correctClicks;
        private System.Windows.Forms.Timer videoTimer;
        private Label timestampDisplay;
        private System.Collections.Generic.List<string> timestamps;

        public Hazard_perception_test()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);
            this.Size = new System.Drawing.Size(1239, 649);
            // Configure axWindowsMediaPlayer on form load
            axWindowsMediaPlayer1.uiMode = "none"; // Hide user controls
            axWindowsMediaPlayer1.fullScreen = false;
            axWindowsMediaPlayer1.stretchToFit = true;

            // Initialize the timer
            videoTimer = new System.Windows.Forms.Timer();
            videoTimer.Interval = 1000; // Check every second
            videoTimer.Tick += VideoTimer_Tick;

            // Initialize the counter for correct clicks
            correctClicks = 0;

            // Initialize the label to display timestamps
            timestampDisplay = new Label();
            timestampDisplay.Location = new System.Drawing.Point(943, 28); // Adjust location as needed
            timestampDisplay.Size = new System.Drawing.Size(200, 300); // Size of the display area
            timestampDisplay.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(timestampDisplay);

            // List to store timestamps
            timestamps = new System.Collections.Generic.List<string>();

            // Event handlers for clicks on the video player
            axWindowsMediaPlayer1.ClickEvent += Video_Click;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "MY EYES  _ Miles Morales Edit (4K).mp4"; // Set the path to your video
            axWindowsMediaPlayer1.Ctlcontrols.play(); // Play video automatically

            // Start the timer to monitor video end
            videoTimer.Start();
        }

        private void Video_Click(object sender, _WMPOCXEvents_ClickEvent e)
        {
            // Get the current position of the video
            double currentTime = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

            // Format the timestamp and add to the list with marker
            TimeSpan timestamp = TimeSpan.FromSeconds(currentTime);
            string formattedTime = timestamp.ToString(@"mm\:ss");
            string timestampWithMarker = $"⚑ {formattedTime}";
            timestamps.Add(timestampWithMarker);

            // Update the timestamp display
            timestampDisplay.Text = string.Join("\n", timestamps);
        }

        private void VideoTimer_Tick(object sender, EventArgs e)
        {
            // Check if the video has reached its end
            if (axWindowsMediaPlayer1.Ctlcontrols.currentPosition >= axWindowsMediaPlayer1.currentMedia.duration)
            {
                // Video has ended, stop the timer
                videoTimer.Stop();

                // Prepare the hardcoded timestamp for comparison (5 seconds)
                double fiveSeconds = TimeSpan.Parse("00:05").TotalSeconds;

                // Gather all timestamps and categorize them as correct or incorrect with points
                string resultText = "Flagged Timestamps:\n";
                int totalPoints = 0;
                bool pointsAdded = false; // Track if any points have been added

                foreach (var timestamp in timestamps)
                {
                    // Extract time part from the formatted timestamp
                    string timePart = timestamp.Substring(2); // Remove the ⚑ marker
                    TimeSpan ts = TimeSpan.Parse(timePart);
                    double timestampInSeconds = ts.TotalSeconds;

                    // Compare timestamp against each specific time point for points
                    int points = 0;
                    if (timestampInSeconds <= TimeSpan.Parse("00:01").TotalSeconds)
                    {
                        points = 5;
                    }
                    else if (timestampInSeconds <= TimeSpan.Parse("00:02").TotalSeconds)
                    {
                        points = 4;
                    }
                    else if (timestampInSeconds <= TimeSpan.Parse("00:03").TotalSeconds)
                    {
                        points = 3;
                    }
                    else if (timestampInSeconds <= TimeSpan.Parse("00:04").TotalSeconds)
                    {
                        points = 2;
                    }
                    else if (timestampInSeconds <= TimeSpan.Parse("00:05").TotalSeconds)
                    {
                        points = 1;
                    }

                    // Only add the first set of points within each interval
                    if (points > 0 && !pointsAdded)
                    {
                        correctClicks += points;
                        pointsAdded = true; // Mark points as added
                    }

                    // Append the result to the display text
                    resultText += $"{(points > 0 ? "Correct" : "Incorrect")}: {timestamp} (+{points} points)\n";
                }

                // Show the result as a message box {resultText}
                MessageBox.Show($"Your total points: {correctClicks}", "Final Points", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }



}






