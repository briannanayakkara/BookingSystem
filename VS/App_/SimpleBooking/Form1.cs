using SimpleBooking.Share;

namespace SimpleBooking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, EventArgs e)
        {

            bool result = await ApiHelper.VerifyUser(username.Text, password.Text);

            if (result)
            {
                // navigate to the main page
                Main mainPage = new Main(username.Text);
                mainPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed. Please try again");
            }
         
            
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            CreateUserF create = new CreateUserF();
            this.Hide();
            create.Show();
            
        }
    }
}