using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Hazard_per_test2 : Form
    {
        private int correctClicks;
        private System.Windows.Forms.Timer videoTimer;
        private Label timestampDisplay;

        private System.Collections.Generic.List<string> timestamps;
        eeeeeeeeee
        public Hazard_per_test2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);
            this.Size = new System.Drawing.Size(1239, 649);

            axWindowsMediaPlayer1.uiMode = "none"; // Hide user controls
            axWindowsMediaPlayer1.fullScreen = false;
            axWindowsMediaPlayer1.stretchToFit = true;

            // Timer setup
            videoTimer = new System.Windows.Forms.Timer();
            videoTimer.Interval = 1000; // Check every second
            videoTimer.Tick += VideoTimer_Tick;

            correctClicks = 0;

            // Initialize timestamp display
            timestampDisplay = new Label
            {
                Location = new System.Drawing.Point(943, 28),
                Size = new System.Drawing.Size(200, 300),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(timestampDisplay);

            timestamps = new System.Collections.Generic.List<string>();

            axWindowsMediaPlayer1.ClickEvent += Video_Click;
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;
        }


        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "Video_2.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            videoTimer.Start();
        }

        private void Video_Click(object sender, _WMPOCXEvents_ClickEvent e)
        {
            double currentTime = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            TimeSpan timestamp = TimeSpan.FromSeconds(currentTime);
            string formattedTime = timestamp.ToString(@"mm\:ss");
            string timestampWithMarker = $"⚑ {formattedTime}";
            timestamps.Add(timestampWithMarker);

            timestampDisplay.Text = string.Join("\n", timestamps);
        }

        private void VideoTimer_Tick(object sender, EventArgs e)
        {
            // Fallback: Ensure we stop when video ends
            if (axWindowsMediaPlayer1.Ctlcontrols.currentPosition >= axWindowsMediaPlayer1.currentMedia.duration)
            {
                videoTimer.Stop();
                ShowResults();
            }
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Detect when the video has stopped
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsStopped)
            {
                videoTimer.Stop();
                ShowResults();
            }
        }
        private bool resultsDisplayed = false; // Add a flag to prevent duplicate displays

        private void ShowResults()
        {
            if (resultsDisplayed)
                return; // Exit if results have already been displayed

            resultsDisplayed = true; // Set the flag to true
            videoTimer.Stop(); // Ensure the timer stops
            axWindowsMediaPlayer1.PlayStateChange -= AxWindowsMediaPlayer1_PlayStateChange; // Unsubscribe event

            string resultText = "Flagged Timestamps:\n";
            bool pointsAdded = false;

            foreach (var timestamp in timestamps)
            {
                string timePart = timestamp.Substring(2); // Remove the ⚑ marker
                TimeSpan ts = TimeSpan.Parse(timePart);
                double timestampInSeconds = ts.TotalSeconds;

                int points = 0;
                if (timestampInSeconds >= TimeSpan.Parse("00:46").TotalSeconds && timestampInSeconds < TimeSpan.Parse("00:47").TotalSeconds)
                {
                    points = 5;
                }
                else if (timestampInSeconds >= TimeSpan.Parse("00:47").TotalSeconds && timestampInSeconds < TimeSpan.Parse("00:48").TotalSeconds)
                {
                    points = 4;
                }
                else if (timestampInSeconds >= TimeSpan.Parse("00:48").TotalSeconds && timestampInSeconds < TimeSpan.Parse("00:49").TotalSeconds)
                {
                    points = 3;
                }
                else if (timestampInSeconds >= TimeSpan.Parse("00:49").TotalSeconds && timestampInSeconds < TimeSpan.Parse("00:50").TotalSeconds)
                {
                    points = 2;
                }
                else if (timestampInSeconds >= TimeSpan.Parse("00:50").TotalSeconds && timestampInSeconds < TimeSpan.Parse("00:51").TotalSeconds)
                {
                    points = 1;
                }

                // Only add the first set of points within each interval
                if (points > 0 && !pointsAdded)
                {
                    correctClicks += points;
                    pointsAdded = true;
                }

                resultText += $"{(points > 0 ? "Correct" : "Incorrect")}: {timestamp} (+{points} points)\n";
            }

            // Show the results in a new form with a "Next" button
            Form resultsForm = new Form
            {
                Text = "Final Results",
                Size = new System.Drawing.Size(342, 151),
                StartPosition = FormStartPosition.CenterParent
            };

            Label resultsLabel = new Label
            {
                Text = $"Your total points: {correctClicks}",
                Dock = DockStyle.Fill,
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(10)
            };

            Button nextButton = new Button
            {
                Text = "Next",
                Dock = DockStyle.Bottom,
                Height = 40
            };

            nextButton.Click += (s, e) =>
            {
                resultsForm.Close();
                // Open the next form with the new video
                Hazard_per_test3 nextForm = new Hazard_per_test3(); // Replace with your next form logic
                nextForm.Show();
                this.Close();
            };

            resultsForm.Controls.Add(resultsLabel);
            resultsForm.Controls.Add(nextButton);
            resultsForm.ShowDialog();
        }


    }
}
