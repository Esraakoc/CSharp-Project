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
            this.tbxStudentName = new System.Windows.Forms.TextBox();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxStudentList
            // 
            this.lbxStudentList.FormattingEnabled = true;
            this.lbxStudentList.ItemHeight = 20;
            this.lbxStudentList.Location = new System.Drawing.Point(78, 117);
            this.lbxStudentList.Name = "lbxStudentList";
            this.lbxStudentList.Size = new System.Drawing.Size(150, 204);
            this.lbxStudentList.TabIndex = 0;
            // 
            // lblStudentList
            // 
            this.lblStudentList.AutoSize = true;
            this.lblStudentList.Location = new System.Drawing.Point(79, 74);
            this.lblStudentList.Name = "lblStudentList";
            this.lblStudentList.Size = new System.Drawing.Size(50, 20);
            this.lblStudentList.TabIndex = 1;
            this.lblStudentList.Text = "label1";
            // 
            // tbxStudentName
            // 
            this.tbxStudentName.Location = new System.Drawing.Point(478, 117);
            this.tbxStudentName.Name = "tbxStudentName";
            this.tbxStudentName.Size = new System.Drawing.Size(125, 27);
            this.tbxStudentName.TabIndex = 2;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(366, 117);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(88, 20);
            this.lblStudentName.TabIndex = 3;
            this.lblStudentName.Text = "Öğrenci Adı";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(639, 117);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(94, 29);
            this.btnAddStudent.TabIndex = 4;
            this.btnAddStudent.Text = "Ekle";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(134, 345);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 33);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Öğrenci Sil";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.tbxStudentName);
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
        private TextBox tbxStudentName;
        private Label lblStudentName;
        private Button btnAddStudent;
        private Button btnRemove;
    }
}