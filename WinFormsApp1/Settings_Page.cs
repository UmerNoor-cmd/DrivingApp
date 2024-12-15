using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Settings_Page : Form
    {
        // Static properties to store global settings
        public static Color GlobalBackgroundColor { get; private set; } = SystemColors.Control; // Default color
        public static float GlobalFontSize { get; private set; } = 8f; // Default font size
        public static FontStyle GlobalFontStyle { get; private set; } = FontStyle.Regular; // Default font style


        private TrackBar fontSizeSlider;
        private Label fontPreviewLabel;
        private CheckBox boldCheckBox;
        private CheckBox italicCheckBox;

        private readonly int[] fontSizes = { 8, 10, 12, 14, 16 }; // Specific font sizes

        public Settings_Page()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);

            // Add a label to preview the selected font size
            fontPreviewLabel = new Label
            {
                Text = "Aa",
                AutoSize = true,
                Font = new Font("Arial", GlobalFontSize, GlobalFontStyle),
                Location = new Point(83, 70)

            };
            Controls.Add(fontPreviewLabel);

            // Add a slider for font size selection
            fontSizeSlider = new TrackBar
            {
                Minimum = 0,
                Maximum = fontSizes.Length - 1,
                TickStyle = TickStyle.Both,
                Location = new Point(83, 100),

                Width = 200
            };
            fontSizeSlider.Value = Array.IndexOf(fontSizes, (int)GlobalFontSize); // Set default value
            fontSizeSlider.Scroll += FontSizeSlider_Scroll;
            Controls.Add(fontSizeSlider);

            // Add checkboxes for font style
            boldCheckBox = new CheckBox
            {
                Text = "Bold",
                AutoSize = true,
                Location = new Point(83, 160),
                Checked = GlobalFontStyle.HasFlag(FontStyle.Bold)
            };
            boldCheckBox.CheckedChanged += FontStyleCheckBox_CheckedChanged;
            Controls.Add(boldCheckBox);

            italicCheckBox = new CheckBox
            {
                Text = "Italic",
                AutoSize = true,
                Location = new Point(220, 160),
                Checked = GlobalFontStyle.HasFlag(FontStyle.Italic)
            };
            italicCheckBox.CheckedChanged += FontStyleCheckBox_CheckedChanged;
            Controls.Add(italicCheckBox);

        }

        private void FontSizeSlider_Scroll(object sender, EventArgs e)
        {
            // Update the global font size based on the slider value
            GlobalFontSize = fontSizes[fontSizeSlider.Value];

            // Update the font size of the preview label
            fontPreviewLabel.Font = new Font("Arial", GlobalFontSize, GlobalFontStyle);
        }

        private void FontStyleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Regular;

            if (boldCheckBox.Checked)
                fontStyle |= FontStyle.Bold;

            if (italicCheckBox.Checked)
                fontStyle |= FontStyle.Italic;

            GlobalFontStyle = fontStyle;

            // Update the font style of the preview label
            fontPreviewLabel.Font = new Font("Arial", GlobalFontSize, GlobalFontStyle);

            MessageBox.Show($"Font style updated to {GlobalFontStyle}.", "Settings",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Change_Color_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    GlobalBackgroundColor = colorDialog.Color;
                    MessageBox.Show("Background color updated. It will apply to all forms when they are reopened.",
                                    "Settings",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage nextForm = new MainPage();
            nextForm.Show();
            this.Hide();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            // File paths (update these with the correct file paths as needed)
            string[] filesToDelete = {
        "PracticeScores.txt",
        "Mock_Score.txt",
        "Flagged_Questions.txt",
        "data.txt"
    };

            bool filesDeleted = false; // Track if any files were deleted
            bool filesExist = false;  // Track if any files existed

            foreach (string file in filesToDelete)
            {
                try
                {
                    if (System.IO.File.Exists(file))
                    {
                        filesExist = true;
                        System.IO.File.Delete(file);
                        filesDeleted = true; // Mark that at least one file was deleted
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting '{file}': {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method on error
                }
            }

            // Show appropriate message after processing all files
            if (filesDeleted)
            {
                MessageBox.Show("Data has been deleted.", "Reset",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!filesExist)
            {
                MessageBox.Show("No data to reset.", "Reset",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
