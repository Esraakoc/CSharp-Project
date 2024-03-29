namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string productsText = "�r�nler";
            var addToCartButtonText = "Sepete Ekle";
            var cartText = "Sepetiniz";
            var removeFromCartButtonText = "Sepetten ��kar";

            lblProducts.Text = productsText;
            lblCart.Text = cartText;
            btnAddToCart.Text = addToCartButtonText;
            btnRemoveFromCart.Text = removeFromCartButtonText;

            string[] products = new string[] { "Laptop", "Klavye", "Masa�st� PC" };

            //for(int i = 0; i < products.Length; i++)
            //{
            //    lbxProducts.Items.Add(products[i]);
            //}
            foreach (var product in products)
            {
                lbxProducts.Items.Add(product);
            }
            //lbxProducts.Items.Add("Laptop");
            //lbxProducts.Items.Add("Klavye");
            //lbxProducts.Items.Add("Masa�st� PC");
            if (lbxCart.Items.Count == 0)
            {
                btnRemoveFromCart.Enabled = false;
            }

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (lbxProducts.SelectedItem != null)
            {
                lbxCart.Items.Add(lbxProducts.SelectedItem);
                btnRemoveFromCart.Enabled = true;
            }
            else
            {
                MessageBox.Show("�ncelikle bir �r�n se�melisiniz...");
            }

        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (lbxCart.SelectedItem != null)
            {
                lbxCart.Items.Remove(lbxCart.SelectedItem);
            }
            else
            {
                MessageBox.Show("�ncelikle sepetten bir �r�n se�melisiniz...");
            }

            if (lbxCart.Items.Count == 0)
            {
                btnRemoveFromCart.Enabled = false;
            }

        }
    }
}