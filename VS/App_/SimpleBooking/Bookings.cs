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
    public partial class Bookings : UserControl
    {

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; showBookings(); }
        }
        public Bookings()
        {
            InitializeComponent();

        }

        private async void showBookings()
        {
            string username = _username; // retrieve the username
            var bookings = await ApiHelper.GetBookingsByUsername(username);
            if (bookings != null && bookings.Any())
            {
                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(() =>
                    {
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = bookings;
                        dataGridView1.DataSource = bindingSource;

                        dataGridView1.Columns["Fullname"].Visible = true;
                        dataGridView1.Columns["Pax"].Visible = true;
                        dataGridView1.Columns["Time"].Visible = true;
                        dataGridView1.Columns["Note"].Visible = true;
                        dataGridView1.Columns["Venue"].Visible = true;
                        dataGridView1.Columns["Status"].Visible = true;

                        dataGridView1.Columns["Email"].Visible = false;
                        dataGridView1.Columns["Phone"].Visible = false;
                        dataGridView1.Columns["TableSize"].Visible = false;
                        dataGridView1.Columns["TableNr"].Visible = false;
                        dataGridView1.Columns["VenueOwner"].Visible = false;

                        dataGridView1.Visible = true;
                    }));
                }
                else
                {
                    dataGridView1.DataSource = bookings;

                    dataGridView1.Columns["Fullname"].Visible = true;
                    dataGridView1.Columns["Pax"].Visible = true;
                    dataGridView1.Columns["Time"].Visible = true;
                    dataGridView1.Columns["Note"].Visible = true;
                    dataGridView1.Columns["Venue"].Visible = true;
                    dataGridView1.Columns["Status"].Visible = true;

                    dataGridView1.Columns["Email"].Visible = false;
                    dataGridView1.Columns["Phone"].Visible = false;
                    dataGridView1.Columns["TableSize"].Visible = false;
                    dataGridView1.Columns["TableNr"].Visible = false;
                    dataGridView1.Columns["VenueOwner"].Visible = false;

                    dataGridView1.Visible = true;
                }
            }
            else
            {
                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(() =>
                    {
                        dataGridView1.Visible = false;
                    }));
                }
                else
                {
                    dataGridView1.Visible = false;
                }
            }
        }


    }
}
