namespace SimpleBooking
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Logout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.EditUserbtn = new System.Windows.Forms.Button();
            this.CreateVenue = new System.Windows.Forms.Button();
            this.ManageVenuebtn = new System.Windows.Forms.Button();
            this.ManageVenueItemsbtn = new System.Windows.Forms.Button();
            this.ManageBookingsbtn = new System.Windows.Forms.Button();
            this.YourBookings = new System.Windows.Forms.Button();
            this.Venuebtn = new System.Windows.Forms.Button();
            this.bookings1 = new SimpleBooking.Bookings();
            this.profile1 = new SimpleBooking.Profile();
            this.createBooking1 = new SimpleBooking.CreateBooking();
            this.createVenue1 = new SimpleBooking.CreateVenue();
            this.DateforBooking2 = new SimpleBooking.UpdateBookings();
            this.manageVenue1 = new SimpleBooking.ManageVenue();
            this.manageVenueItem1 = new SimpleBooking.ManageVenueItem();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.Logout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.EditUserbtn);
            this.panel1.Controls.Add(this.CreateVenue);
            this.panel1.Controls.Add(this.ManageVenuebtn);
            this.panel1.Controls.Add(this.ManageVenueItemsbtn);
            this.panel1.Controls.Add(this.ManageBookingsbtn);
            this.panel1.Controls.Add(this.YourBookings);
            this.panel1.Controls.Add(this.Venuebtn);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 493);
            this.panel1.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Location = new System.Drawing.Point(26, 123);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(97, 26);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "SELECT VENUE";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 155);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(43, 437);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 4;
            this.Logout.Text = "Log out";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "SELECT VENUE";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 15);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "NAME";
            // 
            // EditUserbtn
            // 
            this.EditUserbtn.Location = new System.Drawing.Point(43, 403);
            this.EditUserbtn.Name = "EditUserbtn";
            this.EditUserbtn.Size = new System.Drawing.Size(75, 23);
            this.EditUserbtn.TabIndex = 2;
            this.EditUserbtn.Text = "Edit profile";
            this.EditUserbtn.UseVisualStyleBackColor = true;
            this.EditUserbtn.Click += new System.EventHandler(this.EditUserbtn_Click);
            // 
            // CreateVenue
            // 
            this.CreateVenue.Location = new System.Drawing.Point(25, 346);
            this.CreateVenue.Name = "CreateVenue";
            this.CreateVenue.Size = new System.Drawing.Size(106, 48);
            this.CreateVenue.TabIndex = 1;
            this.CreateVenue.Text = "Create Venue";
            this.CreateVenue.UseVisualStyleBackColor = true;
            this.CreateVenue.Click += new System.EventHandler(this.CreateVenue_Click);
            // 
            // ManageVenuebtn
            // 
            this.ManageVenuebtn.Enabled = false;
            this.ManageVenuebtn.Location = new System.Drawing.Point(25, 292);
            this.ManageVenuebtn.Name = "ManageVenuebtn";
            this.ManageVenuebtn.Size = new System.Drawing.Size(106, 48);
            this.ManageVenuebtn.TabIndex = 1;
            this.ManageVenuebtn.Text = "Manage Venue";
            this.ManageVenuebtn.UseVisualStyleBackColor = true;
            this.ManageVenuebtn.Click += new System.EventHandler(this.ManageVenuebtn_Click);
            // 
            // ManageVenueItemsbtn
            // 
            this.ManageVenueItemsbtn.Enabled = false;
            this.ManageVenueItemsbtn.Location = new System.Drawing.Point(25, 238);
            this.ManageVenueItemsbtn.Name = "ManageVenueItemsbtn";
            this.ManageVenueItemsbtn.Size = new System.Drawing.Size(106, 48);
            this.ManageVenueItemsbtn.TabIndex = 1;
            this.ManageVenueItemsbtn.Text = "Manage Venue Items";
            this.ManageVenueItemsbtn.UseVisualStyleBackColor = true;
            this.ManageVenueItemsbtn.Click += new System.EventHandler(this.ManageVenueItemsbtn_Click);
            // 
            // ManageBookingsbtn
            // 
            this.ManageBookingsbtn.Enabled = false;
            this.ManageBookingsbtn.Location = new System.Drawing.Point(25, 184);
            this.ManageBookingsbtn.Name = "ManageBookingsbtn";
            this.ManageBookingsbtn.Size = new System.Drawing.Size(106, 48);
            this.ManageBookingsbtn.TabIndex = 1;
            this.ManageBookingsbtn.Text = "Manage bookings";
            this.ManageBookingsbtn.UseVisualStyleBackColor = true;
            this.ManageBookingsbtn.Click += new System.EventHandler(this.ManageBookingsbtn_Click);
            // 
            // YourBookings
            // 
            this.YourBookings.Location = new System.Drawing.Point(25, 84);
            this.YourBookings.Name = "YourBookings";
            this.YourBookings.Size = new System.Drawing.Size(97, 23);
            this.YourBookings.TabIndex = 0;
            this.YourBookings.Text = "YourBookings";
            this.YourBookings.UseVisualStyleBackColor = true;
            this.YourBookings.Click += new System.EventHandler(this.Bookingsbtn_Click);
            // 
            // Venuebtn
            // 
            this.Venuebtn.Location = new System.Drawing.Point(26, 55);
            this.Venuebtn.Name = "Venuebtn";
            this.Venuebtn.Size = new System.Drawing.Size(97, 23);
            this.Venuebtn.TabIndex = 0;
            this.Venuebtn.Text = "Create booking";
            this.Venuebtn.UseVisualStyleBackColor = true;
            this.Venuebtn.Click += new System.EventHandler(this.Venuebtn_Click);
            // 
            // bookings1
            // 
            this.bookings1.Location = new System.Drawing.Point(164, 1);
            this.bookings1.Name = "bookings1";
            this.bookings1.Size = new System.Drawing.Size(829, 493);
            this.bookings1.TabIndex = 1;
            this.bookings1.Username = null;
            // 
            // profile1
            // 
            this.profile1.Location = new System.Drawing.Point(164, 1);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(763, 460);
            this.profile1.TabIndex = 2;
            // 
            // createBooking1
            // 
            this.createBooking1.Location = new System.Drawing.Point(159, 1);
            this.createBooking1.Name = "createBooking1";
            this.createBooking1.Size = new System.Drawing.Size(815, 493);
            this.createBooking1.TabIndex = 3;
            this.createBooking1.Load += new System.EventHandler(this.createBooking1_Load);
            // 
            // createVenue1
            // 
            this.createVenue1.Location = new System.Drawing.Point(159, 1);
            this.createVenue1.Name = "createVenue1";
            this.createVenue1.Size = new System.Drawing.Size(914, 493);
            this.createVenue1.TabIndex = 4;
            // 
            // DateforBooking2
            // 
            this.DateforBooking2.Location = new System.Drawing.Point(159, 1);
            this.DateforBooking2.Name = "DateforBooking2";
            this.DateforBooking2.Size = new System.Drawing.Size(914, 493);
            this.DateforBooking2.TabIndex = 5;
            // 
            // manageVenue1
            // 
            this.manageVenue1.Location = new System.Drawing.Point(203, 39);
            this.manageVenue1.Name = "manageVenue1";
            this.manageVenue1.Size = new System.Drawing.Size(804, 422);
            this.manageVenue1.TabIndex = 6;
            // 
            // manageVenueItem1
            // 
            this.manageVenueItem1.Location = new System.Drawing.Point(203, 21);
            this.manageVenueItem1.Name = "manageVenueItem1";
            this.manageVenueItem1.Size = new System.Drawing.Size(775, 449);
            this.manageVenueItem1.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 494);
            this.Controls.Add(this.manageVenueItem1);
            this.Controls.Add(this.manageVenue1);
            this.Controls.Add(this.DateforBooking2);
            this.Controls.Add(this.createVenue1);
            this.Controls.Add(this.createBooking1);
            this.Controls.Add(this.bookings1);
            this.Controls.Add(this.profile1);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label labelName;
        private Button EditUserbtn;
        private Button ManageBookingsbtn;
        private Button Venuebtn;
        private Profile profile1;
        private Bookings bookings1;
        private Label label1;
        private CreateBooking createBooking1;
        private Button Logout;
        private ComboBox comboBox1;
        private Button ManageVenuebtn;
        private Button ManageVenueItemsbtn;
        private Button CreateVenue;
        private Button YourBookings;
        private CreateVenue createVenue1;
        private UpdateBookings DateforBooking2;
        private ManageVenue manageVenue1;
        private Button buttonRefresh;
        private ManageVenueItem manageVenueItem1;
    }
}