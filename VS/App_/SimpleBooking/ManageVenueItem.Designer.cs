namespace SimpleBooking
{
    partial class ManageVenueItem
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
            this.UpdateVI = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Createbtn = new System.Windows.Forms.Button();
            this.TableType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TableSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableNumber = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.TableIDCom = new System.Windows.Forms.ComboBox();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.TableTypeUp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TableSizeUp = new System.Windows.Forms.NumericUpDown();
            this.l = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TableNumUp = new System.Windows.Forms.NumericUpDown();
            this.UpdateVI.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableNumber)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableSizeUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableNumUp)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateVI
            // 
            this.UpdateVI.Controls.Add(this.tabPage1);
            this.UpdateVI.Controls.Add(this.tabPage2);
            this.UpdateVI.Location = new System.Drawing.Point(3, 3);
            this.UpdateVI.Name = "UpdateVI";
            this.UpdateVI.SelectedIndex = 0;
            this.UpdateVI.Size = new System.Drawing.Size(772, 443);
            this.UpdateVI.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.Createbtn);
            this.tabPage1.Controls.Add(this.TableType);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TableSize);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tableNumber);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(764, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Venue Item";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(706, 232);
            this.dataGridView1.TabIndex = 4;
            // 
            // Createbtn
            // 
            this.Createbtn.Location = new System.Drawing.Point(541, 61);
            this.Createbtn.Name = "Createbtn";
            this.Createbtn.Size = new System.Drawing.Size(132, 57);
            this.Createbtn.TabIndex = 3;
            this.Createbtn.Text = "Create table";
            this.Createbtn.UseVisualStyleBackColor = true;
            this.Createbtn.Click += new System.EventHandler(this.Createbtn_Click);
            // 
            // TableType
            // 
            this.TableType.Location = new System.Drawing.Point(401, 79);
            this.TableType.Name = "TableType";
            this.TableType.Size = new System.Drawing.Size(100, 23);
            this.TableType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Table Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table Size";
            // 
            // TableSize
            // 
            this.TableSize.Location = new System.Drawing.Point(241, 79);
            this.TableSize.Name = "TableSize";
            this.TableSize.Size = new System.Drawing.Size(120, 23);
            this.TableSize.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table Number ";
            // 
            // tableNumber
            // 
            this.tableNumber.Location = new System.Drawing.Point(101, 79);
            this.tableNumber.Name = "tableNumber";
            this.tableNumber.Size = new System.Drawing.Size(120, 23);
            this.tableNumber.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.TableIDCom);
            this.tabPage2.Controls.Add(this.UpdateBtn);
            this.tabPage2.Controls.Add(this.TableTypeUp);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.TableSizeUp);
            this.tabPage2.Controls.Add(this.l);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TableNumUp);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(764, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update Venue Item";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(22, 115);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(706, 281);
            this.dataGridView2.TabIndex = 12;
            // 
            // TableIDCom
            // 
            this.TableIDCom.FormattingEnabled = true;
            this.TableIDCom.Location = new System.Drawing.Point(19, 56);
            this.TableIDCom.Name = "TableIDCom";
            this.TableIDCom.Size = new System.Drawing.Size(121, 23);
            this.TableIDCom.TabIndex = 11;
            this.TableIDCom.SelectedIndexChanged += new System.EventHandler(this.TableIDCom_SelectedIndexChanged);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(596, 38);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(132, 57);
            this.UpdateBtn.TabIndex = 10;
            this.UpdateBtn.Text = "UpdateTable";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // TableTypeUp
            // 
            this.TableTypeUp.Location = new System.Drawing.Point(463, 56);
            this.TableTypeUp.Name = "TableTypeUp";
            this.TableTypeUp.Size = new System.Drawing.Size(100, 23);
            this.TableTypeUp.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Table Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Table Size";
            // 
            // TableSizeUp
            // 
            this.TableSizeUp.Location = new System.Drawing.Point(303, 56);
            this.TableSizeUp.Name = "TableSizeUp";
            this.TableSizeUp.Size = new System.Drawing.Size(120, 23);
            this.TableSizeUp.TabIndex = 4;
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(42, 28);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(48, 15);
            this.l.TabIndex = 8;
            this.l.Text = "Table ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Table Number ";
            // 
            // TableNumUp
            // 
            this.TableNumUp.Location = new System.Drawing.Point(163, 56);
            this.TableNumUp.Name = "TableNumUp";
            this.TableNumUp.Size = new System.Drawing.Size(120, 23);
            this.TableNumUp.TabIndex = 5;
            // 
            // ManageVenueItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateVI);
            this.Name = "ManageVenueItem";
            this.Size = new System.Drawing.Size(775, 449);
            this.UpdateVI.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableNumber)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableSizeUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableNumUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl UpdateVI;
        private TabPage tabPage1;
        private Button Createbtn;
        private TextBox TableType;
        private Label label3;
        private Label label2;
        private NumericUpDown TableSize;
        private Label label1;
        private NumericUpDown tableNumber;
        private TabPage tabPage2;
        private ComboBox TableIDCom;
        private Button UpdateBtn;
        private TextBox TableTypeUp;
        private Label label4;
        private Label label5;
        private NumericUpDown TableSizeUp;
        private Label l;
        private Label label6;
        private NumericUpDown TableNumUp;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
    }
}
