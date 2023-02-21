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
            this.labelName = new System.Windows.Forms.Label();
            this.EditUserbtn = new System.Windows.Forms.Button();
            this.Bookingsbtn = new System.Windows.Forms.Button();
            this.Venuebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profile1 = new SimpleBooking.Profile();
            this.bookings1 = new SimpleBooking.Bookings();
            this.venues1 = new SimpleBooking.Venues();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.EditUserbtn);
            this.panel1.Controls.Add(this.Bookingsbtn);
            this.panel1.Controls.Add(this.Venuebtn);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 451);
            this.panel1.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(58, 21);
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
            // Bookingsbtn
            // 
            this.Bookingsbtn.Location = new System.Drawing.Point(26, 84);
            this.Bookingsbtn.Name = "Bookingsbtn";
            this.Bookingsbtn.Size = new System.Drawing.Size(106, 23);
            this.Bookingsbtn.TabIndex = 1;
            this.Bookingsbtn.Text = "Your bookings";
            this.Bookingsbtn.UseVisualStyleBackColor = true;
            this.Bookingsbtn.Click += new System.EventHandler(this.Bookingsbtn_Click);
            // 
            // Venuebtn
            // 
            this.Venuebtn.Location = new System.Drawing.Point(43, 55);
            this.Venuebtn.Name = "Venuebtn";
            this.Venuebtn.Size = new System.Drawing.Size(75, 23);
            this.Venuebtn.TabIndex = 0;
            this.Venuebtn.Text = "Venues";
            this.Venuebtn.UseVisualStyleBackColor = true;
            this.Venuebtn.Click += new System.EventHandler(this.Venuebtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.profile1);
            this.panel2.Controls.Add(this.bookings1);
            this.panel2.Controls.Add(this.venues1);
            this.panel2.Location = new System.Drawing.Point(157, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(646, 451);
            this.panel2.TabIndex = 1;
            // 
            // profile1
            // 
            this.profile1.Location = new System.Drawing.Point(7, 3);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(636, 448);
            this.profile1.TabIndex = 2;
            // 
            // bookings1
            // 
            this.bookings1.Location = new System.Drawing.Point(7, 0);
            this.bookings1.Name = "bookings1";
            this.bookings1.Size = new System.Drawing.Size(636, 451);
            this.bookings1.TabIndex = 1;
            // 
            // venues1
            // 
            this.venues1.Location = new System.Drawing.Point(0, 0);
            this.venues1.Name = "venues1";
            this.venues1.Size = new System.Drawing.Size(643, 451);
            this.venues1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label labelName;
        private Button EditUserbtn;
        private Button Bookingsbtn;
        private Button Venuebtn;
        private Panel panel2;
        private Profile profile1;
        private Bookings bookings1;
        private Venues venues1;
    }
}