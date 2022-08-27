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

            students = new List<string> { "Esra", "Furkan", "Salih" };

            foreach (var student in students)
            {
                lbxStudentList.Items.Add(student);
            }

        }

        private void btnStudent_Click(object sender, EventArgs e)
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
                MessageBox.Show("Öðrenci ismi en az iki karakter olmalýdýr.");
            }
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            //students.Remove(lbxStudentList.SelectedItem.ToString());
            //lbxStudentList.Items.Clear();
            //foreach (var student in students)
            //{
            //    lbxStudentList.Items.Add(student);
            //}

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
                MessageBox.Show("Öncelikle bir isim seçmelisiniz");
            }
            if (lbxStudentList.Items.Count == 0)
            {
                btnRemoveStudent.Enabled = false;
            }
        }
    }
}