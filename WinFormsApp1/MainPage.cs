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
            MockTest_Page nextForm = new MockTest_Page();
            nextForm.Show();
            this.Hide();
        }

        private void Signs_Click(object sender, EventArgs e)
        {
            Traffic_Signs_page nextForm = new Traffic_Signs_page();
            nextForm.Show();
            this.Hide();
        }
    }
    //completed

}

