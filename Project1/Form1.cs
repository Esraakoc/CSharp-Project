namespace UdemyCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            var productsText = "�r�nler";
            string addToCartButtonText = "Sepete Ekle";
            var cartText = "Sepetiniz";
            var removeFromButtonText = "Sepetten ��kar";

            lblProducts.Text = productsText;
            btnAddToCart.Text= addToCartButtonText;
            lblCart.Text = cartText;
            btnRemoveFromCart.Text = removeFromButtonText;

            string[] products = new string[] { "Laptop","Masa�st� PC", "Klavye"};
            
            //for(int i = 0; i < products.Length; i++)
            //{
            //    lbxProducts.Items.Add(products[i]);
            //}
            foreach(var item in products)
            {
                lbxProducts.Items.Add(item);
            }

            if (lbxCart.Items.Count == 0)
            {
                btnRemoveFromCart.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lbxProducts.SelectedItem!=null)
            {
                lbxCart.Items.Add(lbxProducts.SelectedItem);
                btnRemoveFromCart.Enabled = true;
            }
            else
            {
                MessageBox.Show("�ncelikle bir �r�n se�melisiniz.");
            }
            
        }

        private void lbxCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCart_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(lbxCart.SelectedItem!=null)
            {
                lbxCart.Items.Remove(lbxCart.SelectedItem);
            }
            else
            {
                MessageBox.Show("�ncelikle bir �r�n se�melisiniz");
            }
            if(lbxCart.Items.Count==0)
            {
                btnRemoveFromCart.Enabled = false;
            }
        }
    }
}