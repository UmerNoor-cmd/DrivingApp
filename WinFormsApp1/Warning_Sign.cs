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
    public partial class Warning_Sign : Form
    {
        public Warning_Sign()
        {
            InitializeComponent();
            InitializeGrid();
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);

            this.StartPosition = FormStartPosition.CenterScreen;
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
            AddSignRow(signsGridView, "Mostly triangular", "Blank.png");
            AddSignRow(signsGridView, "Crossroads", "Crossroads.png");
            AddSignRow(signsGridView, "Distance to ‘Give Way ’line ahead", "Distance to ‘Give Way ’line ahead.png");
            AddSignRow(signsGridView, "Distance to ‘STOP’ lineahead", "Distance to ‘STOP’ lineahead.png");
            AddSignRow(signsGridView, "Dual carriage way ends", "Dual carriage way ends.png");
            AddSignRow(signsGridView, "Junction on bend ahead", "Junction on bend ahead.png");
            AddSignRow(signsGridView, "Road narrows on right (left if symbol reversed)", "Road narrows on right (left if symbol reversed).png");
            AddSignRow(signsGridView, "Staggered junction", "Staggered junction.png");
            AddSignRow(signsGridView, "T-junction with priority over vehicles from the right", "T-junction with priority over vehicles from the right.png");
            AddSignRow(signsGridView, "Traffic merging from left ahead", "Traffic merging from left ahead.png");
            AddSignRow(signsGridView, "The priority through route is indicated by the broader line.", "Blank.png");
            AddSignRow(signsGridView, "Risk of grounding", "Risk of grounding.png");
            AddSignRow(signsGridView, "Quayside or river bank", "Quayside or river bank.png");
            AddSignRow(signsGridView, "Worded warning sign", "Worded warning sign.png");
            AddSignRow(signsGridView, "Hump bridge", "Hump bridge.png");
            AddSignRow(signsGridView, "Side winds", "Side winds.png");
            AddSignRow(signsGridView, "Soft verges", "Soft verges.png");
            AddSignRow(signsGridView, "Other danger; plate indicates nature of danger", "Other danger; plate indicates nature of danger.png");
            AddSignRow(signsGridView, "Distance over which roadhumps extend", "Distance over which roadhumps extend.png");
            AddSignRow(signsGridView, "Traffic queues likely ahead", "Traffic queues likely ahead.png");
            AddSignRow(signsGridView, "Risk of ice", "Risk of ice.png");
            AddSignRow(signsGridView, "Cycle route ahead", "Cycle route ahead.png");
            AddSignRow(signsGridView, "Accompanied horses", "Accompanied horses.png");
            AddSignRow(signsGridView, "Wild horses", "Wild horses.png");
            AddSignRow(signsGridView, "Wild animals", "Wild animals.png");
            AddSignRow(signsGridView, "Cattle", "Cattle.png");
            AddSignRow(signsGridView, "Miniature warning lights at level crossings", "Miniature warning lights at level crossings.png");
            AddSignRow(signsGridView, "light signals ahead at level crossing airfield or bridge", "light signals ahead at level crossing airfield or bridge.png");
            AddSignRow(signsGridView, "Sharp deviation of route to left (or right if chevrons reversed)", "Sharp deviation of route to left (or right if chevrons reversed).png");
            AddSignRow(signsGridView, "Available width of headroom indicated", "Available width of headroom indicated.png");
            AddSignRow(signsGridView, "Overhead electric cable ; plate indicates maximum height of vehicles which can pass safely", "Overhead electric cable ; plate indicates maximum height of vehicles which can pass safely.png");
            AddSignRow(signsGridView, "Zebra crossing", "Zebra crossing.png");
            AddSignRow(signsGridView, "Pedestrians in road ahead", "Pedestrians in road ahead.png");
            AddSignRow(signsGridView, "Frail (or blind or disabled if shown) pedestrians likely to cross road ahead", "Frail (or blind or disabled if shown) pedestrians likely to cross road ahead.png");
            AddSignRow(signsGridView, "School crossing patrol ahead (some signs have amber lights which flash when crossings are in use)", "School crossing patrol ahead (some signs have amber lights which flash when crossings are in use).png");
            AddSignRow(signsGridView, "Level crossing without barrier", "Level crossing without barrier.png");
            AddSignRow(signsGridView, "Level crossing without barrier or gate ahead", "Level crossing without barrier or gate ahead.png");
            AddSignRow(signsGridView, "Level crossing with barrier or gate ahead", "Level crossing with barrier or gate ahead.png");
            AddSignRow(signsGridView, "Trams crossing ahead", "Trams crossing ahead.png");
            AddSignRow(signsGridView, "Tunnel ahead", "Tunnel ahead.png");
            AddSignRow(signsGridView, "Steep hill upwards", "Steep hill upwards.png");
            AddSignRow(signsGridView, "Steep hill downwards", "Steep hill downwards.png");
            AddSignRow(signsGridView, "Slippery road", "Slippery road.png");
            AddSignRow(signsGridView, "Traffic signals", "Traffic signals.png");
            AddSignRow(signsGridView, "Traffic signals not in use", "Traffic signals not in use.png");
            AddSignRow(signsGridView, "Falling or fallen rocks", "Falling or fallen rocks.png");
            AddSignRow(signsGridView, "Low-flying air craftor sudden aircraft noise", "Low-flying air craftor sudden aircraft noise.png");
            AddSignRow(signsGridView, "Opening or swing bridge ahead", "Opening or swing bridge ahead.png");
            AddSignRow(signsGridView, "Two-way traffic straight ahead", "Two-way traffic straight ahead.png");
            AddSignRow(signsGridView, "Two-way traffic crossesone-way road", "Two-way traffic crossesone-way road.png");
            AddSignRow(signsGridView, "Plate below some signs", "Plate below some signs.png");
            AddSignRow(signsGridView, "Uneven road", "Uneven road.png");
            AddSignRow(signsGridView, "Roundabout", "Roundabout.png");
            AddSignRow(signsGridView, "Bend to right(or left if symbol reversed)", "Bend to right(or left if symbol reversed).png");
            AddSignRow(signsGridView, "Double bend first to left (symbol may be reversed)", "Double bend first to left (symbol may be reversed).png");


            //AddSignRow(signsGridView, "Ahead only", "Ahead only.png");







            if (signsGridView.Rows.Count > 1) // Ensure the row exists
            {
                signsGridView.Rows[0].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                signsGridView.Rows[10].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            }
            // Add DataGridView to form
            Controls.Add(signsGridView);
        }

        private void AddSignRow(DataGridView grid, string info, string imagePath)
        {
            // Load image
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imageFullPath = System.IO.Path.Combine(appDirectory, "Warning_Signs", imagePath);

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
