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
        private void Mock_test_Click(object sender, EventArgs e)
        {
            PracticePage nextForm = new PracticePage();
            nextForm.Show();
            this.Hide();
        }
    }
    //completed

}

