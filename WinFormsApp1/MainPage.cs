namespace WinFormsApp1
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings_Page.GlobalBackgroundColor;
            this.Font = new Font(this.Font.FontFamily, Settings_Page.GlobalFontSize, Settings_Page.GlobalFontStyle);

        }

        private void Practice_Click(object sender, EventArgs e)
        {
            PracticePage nextForm = new PracticePage();
            nextForm.Show();
            this.Hide();
        }
        private void Mock_test_Click(object sender, EventArgs e)
        {
            InstructionsForm nextForm = new InstructionsForm();
            nextForm.Show();
            this.Hide();
        }

        private void Signs_Click(object sender, EventArgs e)
        {
            Traffic_Signs_page nextForm = new Traffic_Signs_page();
            nextForm.Show();
            this.Hide();
        }

        private void Progress_Click(object sender, EventArgs e)
        {
            Progress_Page nextForm = new Progress_Page();
            nextForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings_Page nextForm = new Settings_Page();
            nextForm.Show();
            this.Hide();
        }
    }
    //completed

}

