using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Traffic_Signs_page : Form
    {
        public static List<string> CompletedTopics { get; private set; } = new List<string>();

        // Static dictionary to store checkbox states
        private static Dictionary<string, bool> CheckboxStates = new Dictionary<string, bool>
        {
            { "Giving Orders", false },
            { "Warning Signs", false },
            { "Direction Signs", false },
            { "Information Signs", false },
            { "Road Work Signs", false }
        };

        public Traffic_Signs_page()
        {
            InitializeComponent();
            RestoreCheckboxStates();
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);

            this.StartPosition = FormStartPosition.CenterScreen;

            // Load data from file on form load
            LoadData();
        }

        private void RestoreCheckboxStates()
        {
            // Restore each checkbox state from the static dictionary
            Giving_Order_Complete.Checked = CheckboxStates["Giving Orders"];
            Warning_Signs_Complete.Checked = CheckboxStates["Warning Signs"];
            Direction_Signs_Complete.Checked = CheckboxStates["Direction Signs"];
            Information_Signs_Complete.Checked = CheckboxStates["Information Signs"];
            Road_Work_Complete.Checked = CheckboxStates["Road Work Signs"];

            // Debug logging for validation
            Console.WriteLine("Checkbox States Restored:");
            foreach (var state in CheckboxStates)
            {
                Console.WriteLine($"{state.Key}: {state.Value}");
            }
        }

        private void UpdateCompletedTopics(string topic, bool isCompleted)
        {
            if (isCompleted)
            {
                // Add topic to CompletedTopics only if it's not already there
                if (!CompletedTopics.Contains(topic))
                {
                    CompletedTopics.Add(topic);
                }
            }
            else
            {
                CompletedTopics.Remove(topic);
            }

            // Update the static dictionary with the checkbox state
            CheckboxStates[topic] = isCompleted;

            // Debug logging for validation
            Console.WriteLine($"Updated Checkbox State: {topic} = {isCompleted}");

            // Save data to file
            SaveData();
        }



        private void SaveData()
        {
            try
            {
                // Use a HashSet to ensure uniqueness
                var uniqueTopics = new HashSet<string>();

                // Include topics from the CompletedTopics list
                foreach (var topic in CompletedTopics)
                {
                    uniqueTopics.Add(topic.Trim());
                }

                // Save unique topics and checkbox states to the file
                using (StreamWriter writer = new StreamWriter("data.txt"))
                {
                    // Write unique completed topics
                    writer.WriteLine(string.Join(",", uniqueTopics));

                    // Write checkbox states
                    foreach (var entry in CheckboxStates)
                    {
                        writer.WriteLine($"{entry.Key}:{entry.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists("data.txt"))
                {
                    using (StreamReader reader = new StreamReader("data.txt"))
                    {
                        var uniqueTopics = new HashSet<string>();
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(":"))
                            {
                                var parts = line.Split(':');
                                CheckboxStates[parts[0]] = bool.Parse(parts[1]);
                            }
                            else
                            {
                                // Handle comma-separated topics and add to the set
                                var topics = line.Split(',');
                                foreach (var topic in topics)
                                {
                                    uniqueTopics.Add(topic.Trim());
                                }
                            }
                        }

                        // Update the CompletedTopics list with unique values
                        CompletedTopics = new List<string>(uniqueTopics);

                        // Restore checkbox states
                        RestoreCheckboxStates();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
        }



        private void Giving_Order_Complete_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCompletedTopics("Giving Orders", Giving_Order_Complete.Checked);
        }

        private void Warning_Signs_Complete_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCompletedTopics("Warning Signs", Warning_Signs_Complete.Checked);
        }

        private void Direction_Signs_Complete_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCompletedTopics("Direction Signs", Direction_Signs_Complete.Checked);
        }

        private void Information_Signs_Complete_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCompletedTopics("Information Signs", Information_Signs_Complete.Checked);
        }

        private void Road_Work_Complete_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCompletedTopics("Road Work Signs", Road_Work_Complete.Checked);
        }

        private void Orders_Signs_Click(object sender, EventArgs e)
        {
            Orders_Signs nextForm = new Orders_Signs();
            nextForm.Show();
            this.Hide();
        }
        private void Warning_sign_Click(object sender, EventArgs e)
        {
            Warning_Sign nextForm = new Warning_Sign();
            nextForm.Show();
            this.Hide();
        }

        private void Direction_Sign_Click(object sender, EventArgs e)
        {
            Direction_Signs nextForm = new Direction_Signs();
            nextForm.Show();
            this.Hide();
        }

        private void Information_Sign_Click(object sender, EventArgs e)
        {
            Information_Signs nextForm = new Information_Signs();
            nextForm.Show();
            this.Hide();
        }

        private void RoadWork_Signs_Click(object sender, EventArgs e)
        {
            Road_works_signs nextForm = new Road_works_signs();
            nextForm.Show();
            this.Hide();
        }
        private void BackToMain_Click(object sender, EventArgs e)
        {
            MainPage nextForm = new MainPage();
            nextForm.Show();
            this.Hide();
        }
    }
}

