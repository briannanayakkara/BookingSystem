namespace SimpleBooking
{
    partial class CreateUserF
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
            this.label1 = new System.Windows.Forms.Label();
            this.Fname = new System.Windows.Forms.TextBox();
            this.Sname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Region = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Bday = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.passR = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CreateAccountbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name";
            // 
            // Fname
            // 
            this.Fname.Location = new System.Drawing.Point(351, 26);
            this.Fname.Name = "Fname";
            this.Fname.Size = new System.Drawing.Size(100, 23);
            this.Fname.TabIndex = 1;
            this.Fname.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // Sname
            // 
            this.Sname.Location = new System.Drawing.Point(351, 76);
            this.Sname.Name = "Sname";
            this.Sname.Size = new System.Drawing.Size(100, 23);
            this.Sname.TabIndex = 4;
            this.Sname.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Second name";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(351, 128);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 23);
            this.userName.TabIndex = 6;
            this.userName.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "usernmae";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(351, 188);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(100, 23);
            this.email.TabIndex = 8;
            this.email.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(351, 246);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(100, 23);
            this.phone.TabIndex = 10;
            this.phone.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phone";
            // 
            // Region
            // 
            this.Region.Location = new System.Drawing.Point(351, 300);
            this.Region.Name = "Region";
            this.Region.Size = new System.Drawing.Size(100, 23);
            this.Region.TabIndex = 12;
            this.Region.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Region";
            // 
            // Bday
            // 
            this.Bday.Location = new System.Drawing.Point(351, 354);
            this.Bday.Name = "Bday";
            this.Bday.Size = new System.Drawing.Size(100, 23);
            this.Bday.TabIndex = 14;
            this.Bday.TextAlignChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Bday (yyy-mm-dd)";
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(351, 404);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '*';
            this.pass.Size = new System.Drawing.Size(100, 23);
            this.pass.TabIndex = 16;
            this.pass.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "password";
            // 
            // passR
            // 
            this.passR.Location = new System.Drawing.Point(351, 442);
            this.passR.Name = "passR";
            this.passR.PasswordChar = '*';
            this.passR.Size = new System.Drawing.Size(100, 23);
            this.passR.TabIndex = 18;
            this.passR.TextChanged += new System.EventHandler(this.TextboxChange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 445);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "re password";
            // 
            // CreateAccountbtn
            // 
            this.CreateAccountbtn.Enabled = false;
            this.CreateAccountbtn.Location = new System.Drawing.Point(351, 489);
            this.CreateAccountbtn.Name = "CreateAccountbtn";
            this.CreateAccountbtn.Size = new System.Drawing.Size(100, 36);
            this.CreateAccountbtn.TabIndex = 19;
            this.CreateAccountbtn.Text = "Create Account";
            this.CreateAccountbtn.UseVisualStyleBackColor = true;
            this.CreateAccountbtn.Click += new System.EventHandler(this.CreateAccountbtn_Click);
            // 
            // CreateUserF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 541);
            this.Controls.Add(this.CreateAccountbtn);
            this.Controls.Add(this.passR);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Bday);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Region);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Sname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Fname);
            this.Controls.Add(this.label1);
            this.Name = "CreateUserF";
            this.Text = "CreateUserF";
            this.Load += new System.EventHandler(this.CreateUserF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox Fname;
        private TextBox Sname;
        private Label label2;
        private TextBox userName;
        private Label label3;
        private TextBox email;
        private Label label4;
        private TextBox phone;
        private Label label5;
        private TextBox Region;
        private Label label6;
        private TextBox Bday;
        private Label label7;
        private TextBox pass;
        private Label label8;
        private TextBox passR;
        private Label label9;
        private Button CreateAccountbtn;
    }
}