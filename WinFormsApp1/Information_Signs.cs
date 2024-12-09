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
    public partial class Information_Signs : Form
    {
        public Information_Signs()
        {
            InitializeComponent();
            InitializeGrid();
        }


        private void InitializeGrid()
        {
            // Create and configure DataGridView
            DataGridView signsGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowTemplate = { Height = 100 }, // Adjust row height to fit images
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            // Add columns
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Sign Image",
                Name = "ImageColumn",
                ImageLayout = DataGridViewImageCellLayout.Zoom // Adjust image display
            };
            signsGridView.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn infoColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Information",
                Name = "InfoColumn"
            };
            signsGridView.Columns.Add(infoColumn);

            // Add data
            AddSignRow(signsGridView, "All rectangular", "Blank.png");
            AddSignRow(signsGridView, "Motorway service area sign showing the operator’s name", "Motorway service area sign showing the operator’s name.png");
            AddSignRow(signsGridView, "‘Countdown’ markers at exit from motorway (each bar represents 100 yards to the exit).", "‘Countdown’ markers at exit from motorway (each bar represents 100 yards to the exit)..png");
            AddSignRow(signsGridView, "Traffic on the main carriageway coming from right has priority over joining traffic", "Traffic on the main carriageway coming from right has priority over joining traffic.png");
            AddSignRow(signsGridView, "Appropriate traffic lanes at junction ahead", "Appropriate traffic lanes at junction ahead.png");
            AddSignRow(signsGridView, "Start of motorway and point from which motorway regulations apply", "Start of motorway and point from which motorway regulations apply.png");
            AddSignRow(signsGridView, "End of motorway", "End of motorway.png");
            AddSignRow(signsGridView, "Vehicles permitted to use an HOV lane ahead", "Vehicles permitted to use an HOV lane ahead.png");
            AddSignRow(signsGridView, "Lane designated for use by high occupancy vehicles (HOV) - see rule 142", "Lane designated for use by high occupancy vehicles (HOV) - see rule 142.png");
            AddSignRow(signsGridView, "With-flow bus lane ahead which pedal cycles and taxis may also use", "With-flow bus lane ahead which pedal cycles and taxis may also use.png");
            AddSignRow(signsGridView, "Parking place for solo motorcycles", "Parking place for solo motorcycles.png");
            AddSignRow(signsGridView, "Advance warning of restriction or prohibition ahead", "Advance warning of restriction or prohibition ahead.png");
            AddSignRow(signsGridView, "End of controlled parking zone", "End of controlled parking zone.png");
            AddSignRow(signsGridView, "Entrance to congestion charging zone", "Entrance to congestion charging zone.png");
            AddSignRow(signsGridView, "Entrance to controlled parking zone", "Entrance to controlled parking zone.png");
            AddSignRow(signsGridView, "Information signs - continued", "Blank.png");
            AddSignRow(signsGridView, "Bus lane on road at  junction ahead", "Bus lane on road at  junction ahead.png");
            AddSignRow(signsGridView, "Area in which cameras are used to enforce traffic regulations", "Area in which cameras are used to enforce traffic regulations.png");
            AddSignRow(signsGridView, "Home Zone Entry", "Home Zone Entry.png");
            AddSignRow(signsGridView, "Recommended route for pedal cycles", "Recommended route for pedal cycles.png");
            AddSignRow(signsGridView, "No through road for vehicles", "No through road for vehicles.png");
            AddSignRow(signsGridView, "Tourist information point", "Tourist information point.png");
            AddSignRow(signsGridView, "Hospital ahead with Accident and Emergency facilities", "Hospital ahead with Accident and Emergency facilities.png");
            AddSignRow(signsGridView, "Traffic has priority over oncoming vehicles", "Traffic has priority over oncoming vehicles.png");


            if (signsGridView.Rows.Count > 1) // Ensure the row exists
            {
                signsGridView.Rows[0].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                signsGridView.Rows[15].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            }
            // Add DataGridView to form
            Controls.Add(signsGridView);
        }

        private void AddSignRow(DataGridView grid, string info, string imagePath)
        {
            // Load image
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFullPath = System.IO.Path.Combine(appDirectory, "Information_Signs", imagePath);

            if (!System.IO.File.Exists(imageFullPath))
                throw new System.IO.FileNotFoundException($"Image file not found: {imageFullPath}");

            Image signImage = Image.FromFile(imageFullPath);

            // Add row
            grid.Rows.Add(signImage, info);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Traffic_Signs_page nextForm = new Traffic_Signs_page();
            nextForm.Show();
            this.Hide();
        }
    }
}
