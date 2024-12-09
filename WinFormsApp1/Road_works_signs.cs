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
    public partial class Road_works_signs : Form
    {
        public Road_works_signs()
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
            AddSignRow(signsGridView, "Road works signs", "Blank.png");
            AddSignRow(signsGridView, "One lane crossover at contraflow  road works", "One lane crossover at contraflow  road works.png");
            AddSignRow(signsGridView, "Lane restrictions at road works ahead ", "Lane restrictions at road works ahead .png");
            AddSignRow(signsGridView, "Signs used on the back of slow-moving or stationary vehicles warning of a lane closed ahead by a works vehicle", "Signs used on the back of slow-moving or stationary vehicles warning of a lane closed ahead by a works vehicle.png");
            AddSignRow(signsGridView, "End of road works and any temporary restrictions including speed limits", "End of road works and any temporary restrictions including speed limits.png");
            AddSignRow(signsGridView, "Road works 1 mile ahead", "Road works 1 mile ahead.png");
            AddSignRow(signsGridView, "Mandatory speed limit ahead", "Mandatory speed limit ahead.png");
            AddSignRow(signsGridView, "Slow-moving or stationary works vehicle blocking a traffic lane. Pass in the direction shown by the arrow.", "Slow-moving or stationary works vehicle blocking a traffic lane. Pass in the direction shown by the arrow..png");
            AddSignRow(signsGridView, "Temporary lane closure(the number and position of arrows and red bars may be varied according to lanes open and closed)", "Temporary lane closure(the number and position of arrows and red bars may be varied according to lanes open and closed).png");
            AddSignRow(signsGridView, "Temporary hazard at road works ", "Temporary hazard at road works .png");
            AddSignRow(signsGridView, "Loose chippings", "Loose chippings.png");
            AddSignRow(signsGridView, "Road works", "Road works.png");




            if (signsGridView.Rows.Count > 1) // Ensure the row exists
            {
                signsGridView.Rows[0].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            }
            // Add DataGridView to form
            Controls.Add(signsGridView);
        }

        private void AddSignRow(DataGridView grid, string info, string imagePath)
        {
            // Load image
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFullPath = System.IO.Path.Combine(appDirectory, "Road_Work_Signs", imagePath);

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
