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
    
    public partial class ManageVenue : UserControl
    {
        public string _username;
        public string _venuename;


        public ManageVenue()
        {
            InitializeComponent();
            
        }

        public async void UpdateV()
        {
            var venue = new UpdateVenue
            {
                VenueName = _venuename,
                Name = Namevtxt.Text,
                Limit = Convert.ToInt32(LimitUpDown1.Text),
                EmployeeQty = Convert.ToInt32(EmployeeUpDown2.Text),
                type = Typetxt.Text,
                cvr = CVRtxt.Text,
                region = Regiontxt.Text,
                username = _username
            };

            var response = await ApiHelper.UpdateVenue(venue);

            if (response != null)
            {
                MessageBox.Show("Venue has been updated");

            }
            else
            {
                MessageBox.Show("Failed to update Venue", response);


            }

        }

        public async void FillVenueData()
        {
            // Retrieve venue data from API
            var venueName = _venuename; // The name of the venue you want to retrieve
            var venue = await ApiHelper.GetVenueByName(venueName);

            // Fill in the form fields with the retrieved data
            Namevtxt.Text = venue.Name;
            LimitUpDown1.Value = venue.Limit;
            EmployeeUpDown2.Value = venue.EmployeeQty;
            Typetxt.Text = venue.Type;
            CVRtxt.Text = venue.CVR;
            Regiontxt.Text = venue.Region;
        }

        private void CreateVbtn_Click(object sender, EventArgs e)
        {
            UpdateV();
        }
    }
}
