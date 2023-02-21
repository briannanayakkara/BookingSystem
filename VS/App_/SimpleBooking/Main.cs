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
    public partial class Main : Form
    {
        private string _username;
        private int _userID;
        public Main(string username)
        {
            InitializeComponent();
            _username = username;
            UpdateUserData();
        }
        public async void UpdateUserData()
        {
            var user = await ApiHelper.GetUser(_username);
            if (user != null)
            {
                _userID = user.UserID;
                labelName.Text = user.ToString();
            }
            else
            {
                labelName.Text = "User not found.";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            venues1.Hide();
            profile1.Hide();
            bookings1.Hide();
        }

        private void Venuebtn_Click(object sender, EventArgs e)
        {
            // hide
            profile1.Hide();
            bookings1.Hide();

            //show
            venues1.Show();
            venues1.BringToFront();
        }

        private void Bookingsbtn_Click(object sender, EventArgs e)
        {
            // hide
            profile1.Hide();
            venues1.Hide();

            //show
            bookings1.Show();
            bookings1.BringToFront();
        }

        private void EditUserbtn_Click(object sender, EventArgs e)
        {
            // hide
            venues1.Hide();
            bookings1.Hide();

            //show
            profile1.Show();
            profile1.BringToFront();
        }
    }
}
