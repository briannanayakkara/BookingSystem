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
        public Main()
        {
            InitializeComponent();
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
