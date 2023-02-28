using SimpleBooking.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleBooking.Models;

namespace SimpleBooking
{
    public partial class UpdateBookings : UserControl
    {
        public string _username;
        public string _venuename;
        public string _password;
        Dictionary<string, int> statusDict = new Dictionary<string, int>()
            {
                { "Available", 1 },
                { "Booked", 2 },
                { "NO SHOW", 11 },
                { "Arrived", 22 }
            };
        public UpdateBookings()
        {
            InitializeComponent();
            comboBookingID.DropDownStyle = ComboBoxStyle.DropDownList;


            comboStatusaID.DataSource = new List<string>(statusDict.Keys);
            comboStatusaID.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public async void makeVisible()
        {
            string dateString = SelectDate.Value.ToString("yyyy-MM-dd");
            DateTime date;
            string format = "yyyy-MM-dd";

            bool isValid = DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (isValid)
            {
                showBookings(DateTime.Today.ToString("yyyy-MM-dd"));
                comboBookingID.Visible = true;
                comboBookingID.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (comboBookingID.SelectedIndex != null)
            {

                label6.Visible = true;
                NewDate.Visible = true;
                HH1.Visible = true;
                MM1.Visible = true;
                label4.Visible = true;
                PaxPick.Visible = true;
                Commentbox.Visible = true;
                Updatebooking.Visible = true;

            }
            else
            {
                label6.Visible = false;
                NewDate.Visible = false;
                HH1.Visible = false;
                MM1.Visible = false;
                label4.Visible = false;
                PaxPick.Visible = false;
                Commentbox.Visible = false;
                Updatebooking.Visible = false;
            }
            
        }

        public async void FillUserData()
        {
            string dateString = SelectDate.Value.ToString("yyyy-MM-dd");
            DateTime date;
            string format = "yyyy-MM-dd";

            bool isValid = DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (isValid)
            {
                var bookings = await ApiHelper.GetBookingsByDate(_username, _venuename, date.ToString("yyyy-MM-dd"));
                if (bookings != null && bookings.Any())
                {
                    foreach (var booking in bookings)
                    {
                        comboBookingID.Items.Add(booking.ID);
                    }
                    comboBookingID.Visible = true;

                }
            }
        }

        private async void DateforBooking_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private async void showBookings(string dateString)
        {
            //string dateString = DateforBooking.Value.ToString("yyyy-MM-dd");
            DateTime date;
            string format = "yyyy-MM-dd";

            bool isValid = DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (isValid)
            {
                var bookings = await ApiHelper.GetBookingsByDate(_username, _venuename, date.ToString("yyyy-MM-dd"));

                if (bookings != null && bookings.Any())
                {
                    // Bind bookings to data grid view
                    dataV.Visible = true;

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = bookings;
                    dataV.DataSource = bindingSource;

                    // Show fields for selected booking
                    label6.Visible = true;
                    NewDate.Visible = true;
                    HH1.Visible = true;
                    MM1.Visible = true;
                    label4.Visible = true;
                    PaxPick.Visible = true;
                    Commentbox.Visible = true;
                    Statusbtn.Enabled = false;
                    //UpdateBookingbtn.Visible = true;
                }
                else
                {
                    // Clear data grid view and hide fields
                    dataV.DataSource = null;
                    dataV.Visible = false;
                    label3.Visible = false;
                    label6.Visible = false;
                    NewDate.Visible = false;
                    HH1.Visible = false;
                    MM1.Visible = false;
                    label4.Visible = false;
                    PaxPick.Visible = false;
                    Commentbox.Visible = false;
                    Updatebooking.Visible = false;
                    Statusbtn.Enabled = false;
                }
            }
        }

      

        private async void combobookinID_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void UpdateBookings_Load(object sender, EventArgs e)
        {
            combobookinID.Items.Clear();
            showBookings(DateTime.Today.ToString("yyyy-MM-dd"));
            FillUserData();
            SelectDate.Value = DateTime.Today;
        }


        public void ResetFields()
        {
            comboBookingID.Items.Clear();
            dataV.DataSource = null;
            label4.Visible = false;
            label6.Visible = false;
            NewDate.Value = DateTime.Now;
            HH1.Text = "";
            MM1.Text = "";
            PaxPick.Text = "";
            Commentbox.Text = "";
            Updatebooking.Visible = false;
        }


        private async void UpdateBookingbtn_Click(object sender, EventArgs e)
        {
            
        }

        public async void UpdateStatus()
        {
            if (comboBoxUpdateStatus.SelectedItem != null)
            {
                string status = comboBoxUpdateStatus.SelectedItem.ToString();
                int statusId = statusDict[status];
               
            }
        }

        private void SelectDate_ValueChanged(object sender, EventArgs e)
        {
            comboBookingID.Items.Clear();
            NewDate.Value = DateTime.Now;
            HH1.Text = "";
            MM1.Text = "";
            Pax_.Text = "";
            Commenttxt.Text = "";
            showBookings(SelectDate.Value.ToString("yyyy-MM-dd"));
            FillUserData();
        }

        private async void Updatebooking_Click(object sender, EventArgs e)
        {
            string dateString = NewDate.Value.ToString("yyyy-MM-dd") + "T" + HH1.Text + ":" + MM1.Text + ":00.000Z";
            DateTime date;
            string format = "yyyy-MM-ddTHH:mm:ss.fffZ";
            var booking = new UpdateBooking
            {

                ID = int.Parse(comboBookingID.Text),
                Datetime = dateString,               
                Pax = int.Parse(PaxPick.Text),
                Note = Commentbox.Text,
                Username = _username,
                VenueName = _venuename
            };

            var result = await ApiHelper.UpdateBooking(booking);

            if (result != null)
            {
                MessageBox.Show(result);
                showBookings(NewDate.Value.ToString("yyyy-MM-dd"));

            }
            else
            {
                MessageBox.Show("Failed to update booking", result);
                showBookings(SelectDate.Value.ToString("yyyy-MM-dd"));


            }
        }

        private async void comboBookingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBookingID.SelectedItem != null)
            {
                Updatebooking.Visible = true;
                Statusbtn.Enabled = true;

                string bookingId = comboBookingID.SelectedItem.ToString();

                // Get booking details by ID
                var bookings = await ApiHelper.GetBookingByID(bookingId);
                if (bookings != null && bookings.Any())
                {
                    var booking = bookings.First(); // take the first booking from the list
                    NewDate.Value = booking.Time;
                    HH1.Text = booking.Time.Hour.ToString();
                    MM1.Text = booking.Time.Minute.ToString();
                    PaxPick.Text = booking.Pax.ToString();
                    Commentbox.Text = booking.Note;

                    UpdateBookingbtn.Visible = true;

                }
            }

        }

        
        private void comboStatusaID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void Statusbtn_Click(object sender, EventArgs e)
        {
            int bookingID = Convert.ToInt32(comboBookingID.SelectedItem.ToString());
            string statusID = statusDict[comboStatusaID.SelectedItem.ToString()].ToString();

            HttpResponseMessage response = await ApiHelper.UpdateBookingStatus(bookingID, statusID, _username);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Booking status updated successfully.");
                showBookings(SelectDate.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {errorMessage}");
            }
        }

        private async void AllBookingsBtn_Click(object sender, EventArgs e)
        {
            string username = _username;
            string venuename = _venuename;
            string password = _password;

            //MessageBox.Show(username, venuename, password);

            var bookings = await ApiHelper.GetBookingsByVenue(username, venuename, password);

            if (bookings != null)
            {
                // populate gridview with bookings data
                dataV.DataSource = bookings;
            }
            else
            {
                MessageBox.Show("Failed to get bookings data.");
            }
        }
    }
}
