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
    public partial class CreateVenue : UserControl
    {
        public string _username;
        public CreateVenue()
        {
            InitializeComponent();
            CreateVbtn.Enabled = false;
        }
        private void EnableCreateVbtn()
        {
            if (Namevtxt.Text.Length != 0 && LimitUpDown1.Text.Length != 0 && EmployeeUpDown2.Text.Length != 0 && Regiontxt.Text.Length != 0 && Typetxt.Text.Length != 0 && CVRtxt.Text.Length != 0)
            {
                CreateVbtn.Enabled = true;
            }
            else
            {
                CreateVbtn.Enabled = false;
            }
        }
        private async void CreateVbtn_Click(object sender, EventArgs e)
        {
            var venue = new CreateVenues
            {
                Name = Namevtxt.Text,
                Limit = Convert.ToInt32(LimitUpDown1.Text),
                EmployeeQty = Convert.ToInt32(EmployeeUpDown2.Text),
                Region = Regiontxt.Text,
                Type = Typetxt.Text,
                CVR = CVRtxt.Text,
                username = _username
            };

            var success = await ApiHelper.CreateVenue(venue);

            if (success.IsSuccessStatusCode)
            {
                MessageBox.Show("Venue created successfully");
            }
            else
            {
                MessageBox.Show("Failed to create venue");
            }
        }

        private void Namevtxt_TextChanged(object sender, EventArgs e)
        {
            EnableCreateVbtn();
        }
    }
}
