namespace SimpleBooking
{
    partial class CreateVenue
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
            this.Namevtxt = new System.Windows.Forms.TextBox();
            this.LimitUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.EmployeeUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.Regiontxt = new System.Windows.Forms.TextBox();
            this.Typetxt = new System.Windows.Forms.TextBox();
            this.CVRtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateVbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LimitUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // Namevtxt
            // 
            this.Namevtxt.Location = new System.Drawing.Point(302, 133);
            this.Namevtxt.Name = "Namevtxt";
            this.Namevtxt.PlaceholderText = "Name of the venue";
            this.Namevtxt.Size = new System.Drawing.Size(120, 23);
            this.Namevtxt.TabIndex = 0;
            this.Namevtxt.TextChanged += new System.EventHandler(this.Namevtxt_TextChanged);
            // 
            // LimitUpDown1
            // 
            this.LimitUpDown1.Location = new System.Drawing.Point(302, 162);
            this.LimitUpDown1.Name = "LimitUpDown1";
            this.LimitUpDown1.Size = new System.Drawing.Size(120, 23);
            this.LimitUpDown1.TabIndex = 1;
            this.LimitUpDown1.TabIndexChanged += new System.EventHandler(this.Namevtxt_TextChanged);
            // 
            // EmployeeUpDown2
            // 
            this.EmployeeUpDown2.Location = new System.Drawing.Point(302, 191);
            this.EmployeeUpDown2.Name = "EmployeeUpDown2";
            this.EmployeeUpDown2.Size = new System.Drawing.Size(120, 23);
            this.EmployeeUpDown2.TabIndex = 1;
            this.EmployeeUpDown2.TabIndexChanged += new System.EventHandler(this.Namevtxt_TextChanged);
            // 
            // Regiontxt
            // 
            this.Regiontxt.Location = new System.Drawing.Point(302, 220);
            this.Regiontxt.Name = "Regiontxt";
            this.Regiontxt.PlaceholderText = "Region";
            this.Regiontxt.Size = new System.Drawing.Size(100, 23);
            this.Regiontxt.TabIndex = 0;
            this.Regiontxt.TextChanged += new System.EventHandler(this.Namevtxt_TextChanged);
            // 
            // Typetxt
            // 
            this.Typetxt.Location = new System.Drawing.Point(302, 249);
            this.Typetxt.Name = "Typetxt";
            this.Typetxt.PlaceholderText = "Type";
            this.Typetxt.Size = new System.Drawing.Size(100, 23);
            this.Typetxt.TabIndex = 0;
            this.Typetxt.TextChanged += new System.EventHandler(this.Namevtxt_TextChanged);
            // 
            // CVRtxt
            // 
            this.CVRtxt.Location = new System.Drawing.Point(302, 278);
            this.CVRtxt.Name = "CVRtxt";
            this.CVRtxt.PlaceholderText = "CVR";
            this.CVRtxt.Size = new System.Drawing.Size(100, 23);
            this.CVRtxt.TabIndex = 0;
            this.CVRtxt.TextChanged += new System.EventHandler(this.Namevtxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Create a venue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Limit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee amount ";
            // 
            // CreateVbtn
            // 
            this.CreateVbtn.Location = new System.Drawing.Point(297, 320);
            this.CreateVbtn.Name = "CreateVbtn";
            this.CreateVbtn.Size = new System.Drawing.Size(105, 35);
            this.CreateVbtn.TabIndex = 3;
            this.CreateVbtn.Text = "Create Venue";
            this.CreateVbtn.UseVisualStyleBackColor = true;
            this.CreateVbtn.Click += new System.EventHandler(this.CreateVbtn_Click);
            // 
            // CreateVenue
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
            this.Name = "CreateVenue";
            this.Size = new System.Drawing.Size(767, 570);
            ((System.ComponentModel.ISupportInitialize)(this.LimitUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Namevtxt;
        private NumericUpDown LimitUpDown1;
        private NumericUpDown EmployeeUpDown2;
        private TextBox Regiontxt;
        private TextBox Typetxt;
        private TextBox CVRtxt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button CreateVbtn;
    }
}
