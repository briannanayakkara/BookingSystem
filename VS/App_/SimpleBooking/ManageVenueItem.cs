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
    public partial class ManageVenueItem : UserControl
    {

        public string _username;
        public string _venuename;
        public ManageVenueItem()
        {
            InitializeComponent();
            TableIDCom.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public async void FillVenueItemsGrids(string vn, string un)
        {
            // Make the API call to get the venue items
            var venueItems = await ApiHelper.GetVenueItemsByVenueName(vn, un);
            TableIDCom.Items.Clear();
            if (venueItems == null)
            {
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                return;
            }
            foreach (var item in venueItems)
            {
                TableIDCom.Items.Add(item.TableID);
            }
            // Populate the gridviews with the data
            var data = venueItems.Select(v => new { v.TableID, v.TableNr, v.Pax, v.TableType }).ToList();
            dataGridView1.DataSource = data;
            dataGridView2.DataSource = data;

        }

        public async void CreateVenueItem()
        {
            var venueItem = new CreateVenueItem
            {
                VenueName = _venuename,
                TableNr = Convert.ToInt32(tableNumber.Text),
                Pax = Convert.ToInt32(TableSize.Text),
                TableType = TableType.Text,
                Username = _username
            };

            HttpResponseMessage response = await ApiHelper.CreateVenueItem(venueItem);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Venue item created successfully.");
                FillVenueItemsGrids(_venuename, _username);
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {errorMessage}");
            }
            ClearForm();
        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
            CreateVenueItem();

        }

        private void ClearForm()
        {
            tableNumber.Text = string.Empty;
            TableType.Text = string.Empty;
            TableSize.Value = 0;
        }

        public async void updateVI()
        {  // Get the input data from the UI controls
            int tableID = Convert.ToInt32(TableIDCom.Text);
            int tableNr = Convert.ToInt32(TableNumUp.Text);
            int pax = Convert.ToInt32(TableSizeUp.Text);
            string tableType = TableTypeUp.Text;

            // Create an UpdateVenueItem object with the input data
            var venueItem = new UpdateVenueItem
            {
                VenueName = _venuename,
                TableID = tableID,
                TableNr = tableNr,
                Pax = pax,
                TableType = tableType,
                Username = _username
            };

            // Make the API call to update the venue item
            var response = await ApiHelper.UpdateVenueItem(venueItem);

            // Check the response to see if the update was successful
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Venue item updated successfully.");
                FillVenueItemsGrids(_venuename, _username);
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {errorMessage}");
            }
            ClearForm();
        }

        private async void TableIDCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected table ID
            int tableID = int.Parse(TableIDCom.Text);

            // Call the API to get the details of the selected table
            var venueItems = await ApiHelper.GetVenueItemsByVenueName(_venuename, _username);
            var venueItem = venueItems.FirstOrDefault(vi => vi.TableID == tableID);

            if (venueItem != null)
            {
                // Set the values of the TableNumUp, TableSizeUp, and TableTypeUp controls based on the returned venueItem
                TableNumUp.Value = venueItem.TableNr;
                TableSizeUp.Value = venueItem.Pax;
                TableTypeUp.Text = venueItem.TableType;
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            updateVI();
        }
    }
}
