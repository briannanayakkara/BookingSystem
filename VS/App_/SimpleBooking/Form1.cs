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

            int result = await ApiHelper.VerifyUser(username.Text, password.Text);

            if (result == 1)
            {
                // navigate to the main page for venue owners
                Main mainPage = new Main(username.Text,result);
                mainPage.Show();
                this.Hide();
            }
            else if (result == 0)
            {
                // navigate to the main page for non-venue owners
                Main mainPage = new Main(username.Text,result);
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
            CreateUserF create = new CreateUserF(checkBox1.Checked);
            this.Hide();
            create.Show();
            
        }
    }
}