namespace SimpleBooking
{
    partial class CreateBooking
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.HH = new System.Windows.Forms.TextBox();
            this.Pax_ = new System.Windows.Forms.NumericUpDown();
            this.Commenttxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.MM = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pax_)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(325, 120);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // HH
            // 
            this.HH.Location = new System.Drawing.Point(361, 149);
            this.HH.Name = "HH";
            this.HH.PlaceholderText = "HH";
            this.HH.Size = new System.Drawing.Size(34, 23);
            this.HH.TabIndex = 6;
            // 
            // Pax_
            // 
            this.Pax_.Location = new System.Drawing.Point(596, 120);
            this.Pax_.Name = "Pax_";
            this.Pax_.Size = new System.Drawing.Size(120, 23);
            this.Pax_.TabIndex = 7;
            // 
            // Commenttxt
            // 
            this.Commenttxt.Location = new System.Drawing.Point(285, 247);
            this.Commenttxt.Multiline = true;
            this.Commenttxt.Name = "Commenttxt";
            this.Commenttxt.PlaceholderText = "Comment";
            this.Commenttxt.Size = new System.Drawing.Size(296, 151);
            this.Commenttxt.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select Venue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Date and time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(596, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Amount";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 61);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create booking";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MM
            // 
            this.MM.Location = new System.Drawing.Point(401, 149);
            this.MM.Name = "MM";
            this.MM.PlaceholderText = "MM";
            this.MM.Size = new System.Drawing.Size(34, 23);
            this.MM.TabIndex = 11;
            // 
            // CreateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MM);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Commenttxt);
            this.Controls.Add(this.Pax_);
            this.Controls.Add(this.HH);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox1);
            this.Name = "CreateBooking";
            this.Size = new System.Drawing.Size(929, 568);
            this.Load += new System.EventHandler(this.CreateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pax_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox HH;
        private NumericUpDown Pax_;
        private TextBox Commenttxt;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox MM;
    }
}
