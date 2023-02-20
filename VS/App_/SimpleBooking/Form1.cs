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
            var responce = await ApiHelper.VerifyU(username.Text,password.Text);
            if (responce == "Log in successfull")
            {
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else 
            {
                MessageBox.Show(responce);
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