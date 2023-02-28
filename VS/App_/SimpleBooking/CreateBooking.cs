using SimpleBooking.Models;
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

namespace SimpleBooking
{
    public partial class CreateBooking : UserControl
    {
        public string _username;
        public int _userID;

        public CreateBooking()
        {
            InitializeComponent();
            FillUserData();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private async void CreateBooking_Load(object sender, EventArgs e)
        {
            
        }

        public async void FillUserData()
        {
            var venues = await ApiHelper.GetAllVenues();
            if (venues != null)
            {
                foreach (var venue in venues)
                {
                    comboBox1.Items.Add(venue.Name);
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CreateBookingfun();
        }

        public async void CreateBookingfun()
        {

            string dateString = dateTimePicker1.Value.ToString("yyyy-MM-dd") + "T" + HH.Text + ":" + MM.Text + ":00.000Z";
            DateTime date;
            string format = "yyyy-MM-ddTHH:mm:ss.fffZ";

            bool isValid = DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (isValid && date > DateTime.Now)
            {
                // Create a CreateBooking object with the data from the user control
                var booking = new CreateBookings
                {
                    VenueName = comboBox1.SelectedItem.ToString(),
                    Username = _username,
                    DateTime = dateString,
                    Pax = (int)Pax_.Value,
                    Note = Commenttxt.Text
                };

                // Send the request to the API
                var response = await ApiHelper.CreateBooking(booking);

                // Check if the booking was successfully created
                if (response.IsSuccessStatusCode)
                {
                    // Show success message
                    MessageBox.Show("Booking created successfully");
                }
                else
                {
                    // Show error message
                    MessageBox.Show("Failed to create booking");
                }
            }
            else { MessageBox.Show("Date is invalied"); };
        }
    }
}
