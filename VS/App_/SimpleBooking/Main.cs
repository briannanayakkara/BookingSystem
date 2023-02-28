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
        public string _username;
        public int _userID;
        public int _i;
        public string Vname;
<<<<<<< HEAD
        public string _pass;
        public Main(string username, int i, string pass)
=======
        public Main(string username, int i)
>>>>>>> API
        {
            InitializeComponent();
            _username = username;
            UpdateUserData();
            _i = i;
            enablebtns();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
<<<<<<< HEAD
            _pass = pass;
=======
>>>>>>> API
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
            createBooking1.Hide();
            profile1.Hide();
            manageVenueItem1.Hide();
            bookings1.Hide();
            createVenue1.Hide();
            DateforBooking2.Hide();
            manageVenue1.Hide();

        }

        private void Venuebtn_Click(object sender, EventArgs e)
        {
            // hide
            profile1.Hide();
            createVenue1.Hide();
            bookings1.Hide();
            manageVenueItem1.Hide();
            DateforBooking2.Hide();
            manageVenue1.Hide();



            //show
            createBooking1.Show();
            createBooking1.BringToFront();

            createBooking1._username = _username;

        }

        private void Bookingsbtn_Click(object sender, EventArgs e)
        {
            // hide
            profile1.Hide();
            createVenue1.Hide();
            manageVenueItem1.Hide();
            manageVenue1.Hide();
            createBooking1.Hide();
            DateforBooking2.Hide();


            //show
            bookings1.Show();
            bookings1.BringToFront();

            bookings1.Username = _username;
        }

        private void EditUserbtn_Click(object sender, EventArgs e)
        {
            // hide
            createBooking1.Hide();
            createVenue1.Hide();
            manageVenue1.Hide();
            manageVenueItem1.Hide();
            bookings1.Hide();
            DateforBooking2.Hide();


            //show
            profile1.Show();
            profile1.BringToFront();

            profile1.FillUserData(_username);
            profile1._userID = _userID;

        }

        private void createBooking1_Load(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }


        // ADMIN MANAGMENT
        public void enablebtns()
        {
            if (_i == 1)
            {

                label1.Visible = true;
                comboBox1.Visible = true;
                ManageBookingsbtn.Visible = true;
                ManageVenueItemsbtn.Visible = true;
                ManageVenuebtn.Visible = true;
                CreateVenue.Visible = true;
<<<<<<< HEAD
                buttonRefresh.Visible = true;
=======
>>>>>>> API
                FillUserData();
            }
            else
            {
                
                label1.Visible = false;
                comboBox1.Visible = false;
                ManageBookingsbtn.Visible = false;
                ManageVenueItemsbtn.Visible = false;
                ManageVenuebtn.Visible = false;
                CreateVenue.Visible = false;
<<<<<<< HEAD
                buttonRefresh.Visible = false;

=======
>>>>>>> API
            }

        }
        public async void FillUserData()
        {
            comboBox1.Items.Clear();
            var venues = await ApiHelper.GetAllVenuesForOwner(_username);
            if (venues != null)
            {
                foreach (var venue in venues)
                {
                    comboBox1.Items.Add(venue.Name);
                }
            }
        }

        private void CreateVenue_Click(object sender, EventArgs e)
        {

            // hide
            createBooking1.Hide();
            bookings1.Hide();
            manageVenueItem1.Hide();
            manageVenue1.Hide();
            DateforBooking2.Hide();
            profile1.Hide();

            //show
            createVenue1.Show();
            createVenue1.BringToFront();

            createVenue1._username = _username;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            createBooking1.Hide();
            profile1.Hide();
            bookings1.Hide();
            manageVenue1.Hide();
            createVenue1.Hide();
            manageVenueItem1.Hide();
            DateforBooking2.Hide();



            Vname = comboBox1.Text;
            ManageBookingsbtn.Enabled = true;
            ManageVenuebtn.Enabled = true;
            ManageVenueItemsbtn.Enabled = true;
            Vname = comboBox1.Text;



        }
        private void ManageBookingsbtn_Click(object sender, EventArgs e)
        {
            // hide
            createBooking1.Hide();
            bookings1.Hide();
            profile1.Hide();
            manageVenue1.Hide();
            createVenue1.Hide();
            manageVenueItem1.Hide();


            // reset fields
            DateforBooking2.ResetFields();


            //show
            DateforBooking2.Show();
            DateforBooking2.BringToFront();
            DateforBooking2._username = _username;
            DateforBooking2._venuename = Vname;
<<<<<<< HEAD
            DateforBooking2._password = _pass;
=======
>>>>>>> API
            
                       

        }

        private void ManageVenueItemsbtn_Click(object sender, EventArgs e)
        {

            // hide
            createBooking1.Hide();
            bookings1.Hide();
            profile1.Hide();
            createVenue1.Hide();
            DateforBooking2.Hide();
            manageVenue1.Hide();

            // SHow
            manageVenueItem1.Show();
            manageVenueItem1.BringToFront();
            manageVenueItem1._username = _username;
            manageVenueItem1._venuename = Vname;
            manageVenueItem1.FillVenueItemsGrids(Vname,_username);


        }

        private void ManageVenuebtn_Click(object sender, EventArgs e)
        {
            // hide
            createBooking1.Hide();
            bookings1.Hide();
            profile1.Hide();
            manageVenueItem1.Hide();
            createVenue1.Hide();
            DateforBooking2.Hide();

            // SHow
            manageVenue1.Show();
            manageVenue1.BringToFront();
            manageVenue1._username = _username;
            manageVenue1._venuename = Vname;
            manageVenue1.FillVenueData();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            FillUserData();
        }
<<<<<<< HEAD

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
=======
>>>>>>> API
    }
}
