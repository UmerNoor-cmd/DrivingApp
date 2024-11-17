namespace WinFormsApp1
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
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
            Progress_Page nextForm = new Progress_Page(GlobalData.TestScores);
            nextForm.Show();
            this.Hide();
        }

    }
    //completed

}

