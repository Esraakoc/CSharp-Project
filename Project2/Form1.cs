namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> students;
        private void Form1_Load(object sender, EventArgs e)
        {
            lblStudentList.Text = "��renci Listesi";
            students = new List<string>() { "Esra Ko�", "Arzu Ko�", "Ay�e Y�lmaz" };
            foreach (var student in students)
            {
                lbxStudentList.Items.Add(student);
            }

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (tbxStudentName.Text.Length >= 2)
            {
                students.Add(tbxStudentName.Text);
                lbxStudentList.Items.Clear();
                foreach (var student in students)
                {
                    lbxStudentList.Items.Add(student);
                }
            }

            else
            {
                MessageBox.Show("��renci ismi en az iki karakter olmal�d�r.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxStudentList.SelectedItem != null)
            {
                students.Remove(lbxStudentList.SelectedItem.ToString());
                lbxStudentList.Items.Clear();
                foreach (var student in students)
                {
                    lbxStudentList.Items.Add(student);
                }
            }
            else
            {
                MessageBox.Show("Bir ��renci se�melisiniz.");
            }

        }
    }
}