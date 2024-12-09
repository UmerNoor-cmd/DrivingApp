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
    public partial class Direction_Signs : Form
    {
        public Direction_Signs()
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
            AddSignRow(signsGridView, "Mostly rectangular\r\nSigns on motorways - blue backgrounds\r\n", "Blank.png");
            AddSignRow(signsGridView, "The panel with the inclined arrow indicates the destinations which can be reached", "The panel with the inclined arrow indicates the destinations which can be reached.png");
            AddSignRow(signsGridView, "Downward pointing arrows mean ‘Get in lane’ The left-hand lane leads to a different destination from the other lanes.", "Downward pointing arrows mean ‘Get in lane’ The left-hand lane leads to a different destination from the other lanes..png");
            AddSignRow(signsGridView, "Route confirmatory sign after junction", "Route confirmatory sign after junction.png");
            AddSignRow(signsGridView, "On approaches to junctions (junction number on black background)", "On approaches to junctions (junction number on black background).png");
            AddSignRow(signsGridView, "At a junction leading directly into a motorway (junction number may be shown on a black background)", "At a junction leading directly into a motorway (junction number may be shown on a black background).png");
            AddSignRow(signsGridView, "Signs on primary routes - green backgrounds", "Blank.png");
            AddSignRow(signsGridView, "On approach to a junction in Wales (bilingual)", "On approach to a junction in Wales (bilingual).png");
            AddSignRow(signsGridView, "On approaches to junctions", "On approaches to junctions(green).png");
            AddSignRow(signsGridView, "Route confirmatory sign after junction", "Route confirmatory sign after junction(green).png");
            AddSignRow(signsGridView, "At the junction", "At the junction.png");
            AddSignRow(signsGridView, "On approaches to junctions", "On approaches to junctions.png");
            //AddSignRow(signsGridView, "Blue panels indicate that the motorway starts at the junction ahead.\r\n" +
            //    "Motorways shown in brackets can also be reached along the route indicated.\r\n" +
            //    "White panels indicate local or non-primary routes leading from the junction ahead.\r\n" +
            //    "Brown panels show the route to tourist attractions.\r\nThe name of the junction may be shown at the top of the sign.\r\n" +
            //    "The aircraft symbol indicates the route to an airport.\r\n" +
            //"A symbol may be included to warn of a hazard or restriction along that route.", "Blank.png");
            AddSignRow(signsGridView, "Green background signs - continued", "Blank.png");
            AddSignRow(signsGridView, "Primary route forming part of a ring road", "Primary route forming part of a ring road.png");
            AddSignRow(signsGridView, "Primary route forming part of a ring road", "green.png");
            AddSignRow(signsGridView, "Signs on non-primary and local routes - black borders\r\n", "Blank.png");
            AddSignRow(signsGridView, "On approaches to junctions", "On approaches to junctions(black).png");
            AddSignRow(signsGridView, "At the junction", "At the junction(black).png");
            AddSignRow(signsGridView, "Direction to toilets with access for the disabled", "Direction to toilets with access for the disabled.png");
            //AddSignRow(signsGridView, "Green panels indicate that the primary route starts at the junction ahead.\r\n" +
            //    "Route numbers on a blue background show the direction to a motorway.\r\n" +
            //    "Route numbers on a green background show the direction to a primary route", "Blank.png");
            AddSignRow(signsGridView, "Other direction signs", "Blank.png");
            AddSignRow(signsGridView, "Diversion route", "Diversion route.png");
            AddSignRow(signsGridView, "Symbols showing emergency diversion route for motorway and other main road traffic", "Symbols showing emergency diversion route for motorway and other main road traffic.png");
            AddSignRow(signsGridView, "Route for pedestrians", "Route for pedestrians.png");
            AddSignRow(signsGridView, "Recommended route for pedal cycles to place shown", "Recommended route for pedal cycles to place shown.png");
            AddSignRow(signsGridView, "Route for pedal cycles forming part of a network", "Route for pedal cycles forming part of a network.png");
            AddSignRow(signsGridView, "Advisory route for lorries", "Advisory route for lorries.png");
            AddSignRow(signsGridView, "Direction to camping and caravan site", "Direction to camping and caravan site.png");
            AddSignRow(signsGridView, "Tourist attraction", "Tourist attraction.png");
            AddSignRow(signsGridView, "Direction to a car park", "Direction to a car park.png");
            AddSignRow(signsGridView, "Ancient monument in the care of English Heritage", "Ancient monument in the care of English Heritage.png");
            AddSignRow(signsGridView, "Picnic site", "Picnic site.png");

            if (signsGridView.Rows.Count > 1) // Ensure the row exists
            {
                signsGridView.Rows[0].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                signsGridView.Rows[6].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                signsGridView.Rows[12].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                signsGridView.Rows[15].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                signsGridView.Rows[19].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);


            }
            // Add DataGridView to form
            Controls.Add(signsGridView);
        }

        private void AddSignRow(DataGridView grid, string info, string imagePath)
        {
            // Load image
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFullPath = System.IO.Path.Combine(appDirectory, "Direction_Signs", imagePath);

            if (!System.IO.File.Exists(imageFullPath))
                throw new System.IO.FileNotFoundException($"Image file not found: {imageFullPath}");

            Image signImage = Image.FromFile(imageFullPath);

            // Add row
            grid.Rows.Add(signImage, info);
        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            Traffic_Signs_page nextForm = new Traffic_Signs_page();
            nextForm.Show();
            this.Hide();
        }
    }
}
