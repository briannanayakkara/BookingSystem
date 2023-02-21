namespace SimpleBooking
{
    partial class Profile
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
            this.Welcometxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Welcometxt
            // 
            this.Welcometxt.AutoSize = true;
            this.Welcometxt.Location = new System.Drawing.Point(252, 20);
            this.Welcometxt.Name = "Welcometxt";
            this.Welcometxt.Size = new System.Drawing.Size(41, 15);
            this.Welcometxt.TabIndex = 0;
            this.Welcometxt.Text = "Profile";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Welcometxt);
            this.Name = "Profile";
            this.Size = new System.Drawing.Size(598, 409);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Welcometxt;
    }
}
