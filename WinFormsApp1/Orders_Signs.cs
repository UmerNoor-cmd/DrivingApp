using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Orders_Signs : Form
    {
        public Orders_Signs()
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
            AddSignRow(signsGridView, "Signs with red circles are mostly prohibitive.\r\nPlates below signs qualify their message.", "Blank.png");
            AddSignRow(signsGridView, "Entry to 20 mph zone", "Entry_to_20_mph_zone.png");
            AddSignRow(signsGridView, "End of 20 mph zone", "End_of_20_mph_zone.png");
            AddSignRow(signsGridView, "Give priority to vehicles from opposite direction", "Give priority tovehicles fromoppositedirection.png");
            AddSignRow(signsGridView, "Give way to traffic on major road", "Give way totraffic onmajor road.png");
            AddSignRow(signsGridView, "Manually operated temporary STOP and GO signs", "Manually operated temporary STOP and GO signs.png");
            AddSignRow(signsGridView, "Maximum Speed", "Maximum_Speed.png");
            AddSignRow(signsGridView, "National speed limit applies", "National_speed_limit_applies.png");
            AddSignRow(signsGridView, "No buses (over 8 passenger seats)", "No buses (over 8passengerseats).png");
            AddSignRow(signsGridView, "No cycling", "No cycling.png");
            AddSignRow(signsGridView, "No entry forvehicular traffic", "No entry forvehicular traffic.png");
            AddSignRow(signsGridView, "No goods vehicles over maximum gross weight shown (in tonnes)except for loading and unloading", "No goods vehiclesover maximumgross weightshown (in tonnes)except for loadingand unloading.png");
            AddSignRow(signsGridView, "No left turn", "No left turn.png");
            AddSignRow(signsGridView, "No motor vehicles", "No motorvehicles.png");
            AddSignRow(signsGridView, "No right turn", "No right turn.png");
            AddSignRow(signsGridView, "No stopping during period indicated except for buses", "No stopping duringperiod indicatedexcept for buses.png");
            AddSignRow(signsGridView, "No stopping during times shown except for as long as necessary to set down or pick up passengers", "No stopping duringtimes shownexcept for as longas necessary to setdown or pick uppassengers.png");
            AddSignRow(signsGridView, "No stopping(Clearway)", "No stopping(Clearway).png");
            AddSignRow(signsGridView, "No vehicle or combination of vehicles over length shown", "No vehicle or combination of vehicles over length shown.png");
            AddSignRow(signsGridView, "No vehicles except bicycles being pushed", "No vehiclesexcept bicyclesbeing pushed.png");
            AddSignRow(signsGridView, "No vehicles over maximum gross weightshown(in tonnes)", "No vehiclesover maximumgross weightshown(in tonnes).png");
            AddSignRow(signsGridView, "No vehicles over height shown", "No vehiclesoverheight shown.png");
            AddSignRow(signsGridView, "No vehicles over width shown", "No vehiclesoverwidth shown.png");
            AddSignRow(signsGridView, "No overtaking", "No_overtaking.png");
            AddSignRow(signsGridView, "No towed caravans", "No_towed_caravans.png");
            AddSignRow(signsGridView, "No vehicles carrying explosives", "No_vehicles_carrying_explosives.png");
            AddSignRow(signsGridView, "No waiting", "No_waiting.png");
            AddSignRow(signsGridView, "No U-turns", "NoU-turns.png");
            AddSignRow(signsGridView, "Parking restricted to permit holders", "Parking restrictedto permit holders.png");
            AddSignRow(signsGridView, "School crossing patrol", "School_crossing_patrol.png");
            AddSignRow(signsGridView, "Stop and Give Way", "Stop_and_Give_Way.png");
            AddSignRow(signsGridView, "Signs with blue circles but no red border mostly give\r\npositive instruction.", "Blank.png");
            AddSignRow(signsGridView, "With-flow pedal cycle lane", "With-flow pedal cycle lane.png");
            AddSignRow(signsGridView, "Contra-flow bus lane", "Contra-flow bus lane.png");
            AddSignRow(signsGridView, "With-flow bus and cycle lane", "With-flow bus and cycle lane.png");
            AddSignRow(signsGridView, "One-way traffic (comparecircular Aheadonly sign)", "One-way traffic (comparecircular Aheadonly sign).png");
            AddSignRow(signsGridView, "Pedestrian crossing point over tram way", "Pedestrian crossing point over tram way.png");
            AddSignRow(signsGridView, "Trams only", "Trams only.png");
            AddSignRow(signsGridView, "Buses and cycles only", "Buses and cycles only.png");
            AddSignRow(signsGridView, "Minimum speed", "Minimum speed.png");
            AddSignRow(signsGridView, "End of minimumspeed", "End of minimumspeed.png");
            AddSignRow(signsGridView, "Segregated pedal cycleand pedestrian route Buses", "Segregated pedal cycleand pedestrian route Buses.png");
            AddSignRow(signsGridView, "Route to beused by pedal cycles only", "Route to beused by pedal cycles only.png");
            AddSignRow(signsGridView, "Mini-roundabout(roundabout circulation)", "Mini-roundabout(roundabout circulation).png");
            AddSignRow(signsGridView, "Vehicles may pass either side to reach same destination", "Vehicles may pass either side to reach same destination.png");
            AddSignRow(signsGridView, "Keep left(right if symbol reversed)", "Keep left(right if symbol reversed).png");
            AddSignRow(signsGridView, "Turn left(right if symbol reversed)", "Turn left(right if symbol reversed).png");
            AddSignRow(signsGridView, "Turn left ahead (right if symbolreversed)", "Turn left ahead (right if symbolreversed).png");
            AddSignRow(signsGridView, "Ahead only", "Ahead only.png");








            if (signsGridView.Rows.Count > 1) // Ensure the row exists
            {
                signsGridView.Rows[0].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                signsGridView.Rows[31].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            }
            // Add DataGridView to form
            Controls.Add(signsGridView);
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Traffic_Signs_page nextForm = new Traffic_Signs_page();
            nextForm.Show();
            this.Hide();
        }
        private void AddSignRow(DataGridView grid, string info, string imagePath)
        {
            // Load image
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFullPath = System.IO.Path.Combine(appDirectory, "Signs_Giving_Order", imagePath);

            if (!System.IO.File.Exists(imageFullPath))
                throw new System.IO.FileNotFoundException($"Image file not found: {imageFullPath}");

            Image signImage = Image.FromFile(imageFullPath);

            // Add row
            grid.Rows.Add(signImage, info);
        }
    }
}
