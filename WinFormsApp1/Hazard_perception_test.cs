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

            // Format the timestamp and add to the list
            TimeSpan timestamp = TimeSpan.FromSeconds(currentTime);
            string formattedTime = timestamp.ToString(@"mm\:ss");
            timestamps.Add(formattedTime);

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
                string fiveSecondsTimestamp = "00:05";
                double fiveSeconds = TimeSpan.Parse(fiveSecondsTimestamp).TotalSeconds;

                // Gather all timestamps and categorize them as correct or incorrect
                string resultText = "Flagged Timestamps:\n";
                foreach (var timestamp in timestamps)
                {
                    // Convert the timestamp into seconds
                    TimeSpan ts = TimeSpan.Parse(timestamp);
                    double timestampInSeconds = ts.TotalSeconds;

                    // Compare the timestamp to the "00:05" mark
                    string correctness = timestampInSeconds <= fiveSeconds ? "Correct" : "Incorrect";

                    if (correctness == "Correct")
                    {
                        correctClicks++;
                    }

                    resultText += $"{correctness}: {timestamp}\n";
                }

                // Show the result as a message box
                MessageBox.Show($"{resultText}Your total points: {correctClicks}", "Final Points", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
