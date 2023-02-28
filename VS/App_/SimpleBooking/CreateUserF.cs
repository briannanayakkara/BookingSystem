using SimpleBooking.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleBooking.Models;

namespace SimpleBooking
{
    public partial class CreateUserF : Form
    {
        bool _admin = false;
        public CreateUserF(bool check)
        {
            InitializeComponent();
            _admin = check;
        }

        private void CreateUserF_Load(object sender, EventArgs e)
        {

        }

        private void TextboxChange(object sender, EventArgs e)
        {
            enablebtn();
        }
        private void enablebtn()
        {
            if (userName.Text.Length != 0 && Sname.Text.Length != 0 && userName.Text.Length != 0 && email.Text.Length != 0 && phone.Text.Length != 0 && Region.Text.Length != 0 && Bday.Text.Length != 0 && pass.Text.Length != 0 && pass.Text == passR.Text)
            {
                CreateAccountbtn.Enabled = true;
            }
            else
            {
                CreateAccountbtn.Enabled = false;
            }
        }

        private async void CreateAccountbtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (_admin) { i = 1; };

            var user = new CreateUser
            {
                AdminLvl = i,
                Firstname = Fname.Text,
                Lastname = Sname.Text,
                Username = userName.Text,
                Email = email.Text,
                Phone = Convert.ToInt32(phone.Text),
                Region = Region.Text,
                Bday = Convert.ToDateTime(Bday.Text),
                Password = pass.Text
            };

            var success = await ApiHelper.CreateUser(user);

            
            if (success.IsSuccessStatusCode)
            {
                MessageBox.Show("User created successfully");
                this.Close();
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Failed to create user");
            }
        }
    }
}
