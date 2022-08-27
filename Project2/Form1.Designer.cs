namespace Project2
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
            this.lbxStudentList = new System.Windows.Forms.ListBox();
            this.lblStudentList = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.tbxStudentName = new System.Windows.Forms.TextBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnRemoveStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxStudentList
            // 
            this.lbxStudentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbxStudentList.FormattingEnabled = true;
            this.lbxStudentList.ItemHeight = 25;
            this.lbxStudentList.Location = new System.Drawing.Point(12, 96);
            this.lbxStudentList.Name = "lbxStudentList";
            this.lbxStudentList.Size = new System.Drawing.Size(148, 179);
            this.lbxStudentList.TabIndex = 0;
            // 
            // lblStudentList
            // 
            this.lblStudentList.AutoSize = true;
            this.lblStudentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStudentList.Location = new System.Drawing.Point(12, 40);
            this.lblStudentList.Name = "lblStudentList";
            this.lblStudentList.Size = new System.Drawing.Size(141, 25);
            this.lblStudentList.TabIndex = 1;
            this.lblStudentList.Text = "Öğrenci Listesi";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStudentName.Location = new System.Drawing.Point(179, 96);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(112, 25);
            this.lblStudentName.TabIndex = 2;
            this.lblStudentName.Text = "Öğrenci adı";
            // 
            // tbxStudentName
            // 
            this.tbxStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxStudentName.Location = new System.Drawing.Point(307, 96);
            this.tbxStudentName.Name = "tbxStudentName";
            this.tbxStudentName.Size = new System.Drawing.Size(228, 30);
            this.tbxStudentName.TabIndex = 3;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddStudent.Location = new System.Drawing.Point(470, 145);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(65, 42);
            this.btnAddStudent.TabIndex = 4;
            this.btnAddStudent.Text = "Ekle";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnRemoveStudent
            // 
            this.btnRemoveStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveStudent.Location = new System.Drawing.Point(93, 315);
            this.btnRemoveStudent.Name = "btnRemoveStudent";
            this.btnRemoveStudent.Size = new System.Drawing.Size(67, 40);
            this.btnRemoveStudent.TabIndex = 5;
            this.btnRemoveStudent.Text = "Sil";
            this.btnRemoveStudent.UseVisualStyleBackColor = true;
            this.btnRemoveStudent.Click += new System.EventHandler(this.btnRemoveStudent_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemoveStudent);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.tbxStudentName);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.lblStudentList);
            this.Controls.Add(this.lbxStudentList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbxStudentList;
        private Label lblStudentList;
        private Label lblStudentName;
        private TextBox tbxStudentName;
        private Button btnAddStudent;
        private Button btnRemoveStudent;
    }
}