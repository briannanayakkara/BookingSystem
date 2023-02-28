namespace SimpleBooking
{
    partial class ManageVenue
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateVbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EmployeeUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.LimitUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.CVRtxt = new System.Windows.Forms.TextBox();
            this.Typetxt = new System.Windows.Forms.TextBox();
            this.Regiontxt = new System.Windows.Forms.TextBox();
            this.Namevtxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateVbtn
            // 
            this.CreateVbtn.Location = new System.Drawing.Point(329, 294);
            this.CreateVbtn.Name = "CreateVbtn";
            this.CreateVbtn.Size = new System.Drawing.Size(105, 35);
            this.CreateVbtn.TabIndex = 13;
            this.CreateVbtn.Text = "Update Venue";
            this.CreateVbtn.UseVisualStyleBackColor = true;
            this.CreateVbtn.Click += new System.EventHandler(this.CreateVbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Employee amount ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Limit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Update a venue";
            // 
            // EmployeeUpDown2
            // 
            this.EmployeeUpDown2.Location = new System.Drawing.Point(334, 165);
            this.EmployeeUpDown2.Name = "EmployeeUpDown2";
            this.EmployeeUpDown2.Size = new System.Drawing.Size(120, 23);
            this.EmployeeUpDown2.TabIndex = 8;
            // 
            // LimitUpDown1
            // 
            this.LimitUpDown1.Location = new System.Drawing.Point(334, 136);
            this.LimitUpDown1.Name = "LimitUpDown1";
            this.LimitUpDown1.Size = new System.Drawing.Size(120, 23);
            this.LimitUpDown1.TabIndex = 9;
            // 
            // CVRtxt
            // 
            this.CVRtxt.Location = new System.Drawing.Point(334, 252);
            this.CVRtxt.Name = "CVRtxt";
            this.CVRtxt.PlaceholderText = "CVR";
            this.CVRtxt.Size = new System.Drawing.Size(100, 23);
            this.CVRtxt.TabIndex = 4;
            // 
            // Typetxt
            // 
            this.Typetxt.Location = new System.Drawing.Point(334, 223);
            this.Typetxt.Name = "Typetxt";
            this.Typetxt.PlaceholderText = "Type";
            this.Typetxt.Size = new System.Drawing.Size(100, 23);
            this.Typetxt.TabIndex = 5;
            // 
            // Regiontxt
            // 
            this.Regiontxt.Location = new System.Drawing.Point(334, 194);
            this.Regiontxt.Name = "Regiontxt";
            this.Regiontxt.PlaceholderText = "Region";
            this.Regiontxt.Size = new System.Drawing.Size(100, 23);
            this.Regiontxt.TabIndex = 6;
            // 
            // Namevtxt
            // 
            this.Namevtxt.Location = new System.Drawing.Point(334, 107);
            this.Namevtxt.Name = "Namevtxt";
            this.Namevtxt.PlaceholderText = "New Name of the venue";
            this.Namevtxt.Size = new System.Drawing.Size(149, 23);
            this.Namevtxt.TabIndex = 7;
            // 
            // ManageVenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CreateVbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeeUpDown2);
            this.Controls.Add(this.LimitUpDown1);
            this.Controls.Add(this.CVRtxt);
            this.Controls.Add(this.Typetxt);
            this.Controls.Add(this.Regiontxt);
            this.Controls.Add(this.Namevtxt);
            this.Name = "ManageVenue";
            this.Size = new System.Drawing.Size(804, 422);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimitUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CreateVbtn;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown EmployeeUpDown2;
        private NumericUpDown LimitUpDown1;
        private TextBox CVRtxt;
        private TextBox Typetxt;
        private TextBox Regiontxt;
        private TextBox Namevtxt;
    }
}
