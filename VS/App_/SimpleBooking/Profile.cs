using SimpleBooking.Models;
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

namespace SimpleBooking
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();

        }

        public int _userID;

        public async void FillUserData(string username)
        {
            var user = await ApiHelper.GetUser(username);
            if (user != null)
            {
                Fname.Text = user.Firstname;
                Sname.Text = user.Lastname;
                userName.Text = user.Username;
                email.Text = user.Email;
                Region.Text = user.Region;
                phone.Text = user.Phone.ToString();
                Bday.Text = user.Bday.ToString("yyyy-MM-dd");

            }
        }

        private async void UpdateUser_Click(object sender, EventArgs e)
        {
            if (pass.Text == passR.Text)
            {
                var userData = new UserData
                {
                    Firstname = Fname.Text,
                    Lastname = Sname.Text,
                    Username = userName.Text,
                    Email = email.Text,
                    Phone = Convert.ToInt32(phone.Text),
                    Region = Region.Text,
                    Bday = Convert.ToDateTime(Bday.Text),
                    Password = pass.Text
                };

                var response = await ApiHelper.EditUser(_userID, userData);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Changes saved successfully");
                }
                else
                {
                    MessageBox.Show("Failed to save changes");
                }
            }
            else
            { MessageBox.Show("Password do not match"); }
            
        }
    }
}
