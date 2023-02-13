namespace Project3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgrwCustomers = new System.Windows.Forms.DataGridView();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.gbxAdd = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrwCustomers)).BeginInit();
            this.gbxAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrwCustomers
            // 
            this.dgrwCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrwCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgrwCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgrwCustomers.Name = "dgrwCustomers";
            this.dgrwCustomers.RowHeadersWidth = 51;
            this.dgrwCustomers.RowTemplate.Height = 29;
            this.dgrwCustomers.Size = new System.Drawing.Size(800, 188);
            this.dgrwCustomers.TabIndex = 0;
            // 
            // tbxId
            // 
            this.tbxId.Location = new System.Drawing.Point(132, 31);
            this.tbxId.Name = "tbxId";
            this.tbxId.Size = new System.Drawing.Size(125, 34);
            this.tbxId.TabIndex = 1;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Location = new System.Drawing.Point(132, 64);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(125, 34);
            this.tbxFirstName.TabIndex = 2;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Location = new System.Drawing.Point(132, 97);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(125, 34);
            this.tbxLastName.TabIndex = 3;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(132, 130);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(125, 34);
            this.tbxEmail.TabIndex = 4;
            // 
            // tbxCity
            // 
            this.tbxCity.Location = new System.Drawing.Point(132, 163);
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.Size = new System.Drawing.Size(125, 34);
            this.tbxCity.TabIndex = 5;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(39, 38);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(29, 28);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "Id";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(39, 67);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(42, 28);
            this.lblFirstName.TabIndex = 7;
            this.lblFirstName.Text = "Adı";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(39, 100);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(72, 28);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Soyadı";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(39, 137);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 28);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Mail";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(39, 170);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(46, 28);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City";
            // 
            // gbxAdd
            // 
            this.gbxAdd.Controls.Add(this.btnAdd);
            this.gbxAdd.Controls.Add(this.tbxCity);
            this.gbxAdd.Controls.Add(this.lblCity);
            this.gbxAdd.Controls.Add(this.tbxId);
            this.gbxAdd.Controls.Add(this.lblEmail);
            this.gbxAdd.Controls.Add(this.tbxFirstName);
            this.gbxAdd.Controls.Add(this.lblLastName);
            this.gbxAdd.Controls.Add(this.tbxLastName);
            this.gbxAdd.Controls.Add(this.lblFirstName);
            this.gbxAdd.Controls.Add(this.tbxEmail);
            this.gbxAdd.Controls.Add(this.lblId);
            this.gbxAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbxAdd.Location = new System.Drawing.Point(28, 194);
            this.gbxAdd.Name = "gbxAdd";
            this.gbxAdd.Size = new System.Drawing.Size(301, 276);
            this.gbxAdd.TabIndex = 11;
            this.gbxAdd.TabStop = false;
            this.gbxAdd.Text = "Ekle";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(163, 203);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 37);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.gbxAdd);
            this.Controls.Add(this.dgrwCustomers);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrwCustomers)).EndInit();
            this.gbxAdd.ResumeLayout(false);
            this.gbxAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgrwCustomers;
        private TextBox tbxId;
        private TextBox tbxFirstName;
        private TextBox tbxLastName;
        private TextBox tbxEmail;
        private TextBox tbxCity;
        private Label lblId;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;
        private Label lblCity;
        private GroupBox gbxAdd;
        private Button btnAdd;
    }
}