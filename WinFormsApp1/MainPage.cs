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
            PracticePage nextForm=new PracticePage();
            nextForm.Show();
            this.Hide();
        }
        private void MockTest_Page_Click(object sender, EventArgs e)
        {
            MockTest_Page nextForm = new MockTest_Page();
            nextForm.Show();
            this.Hide();
        }
    }

}

