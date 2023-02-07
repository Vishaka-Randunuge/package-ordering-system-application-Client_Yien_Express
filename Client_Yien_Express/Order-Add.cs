using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Yien_Express
{
    public partial class Order_Add : Form
    {
        public Order_Add()
        {
            InitializeComponent();
        }
        public class Order
        {
            public int Id { get; set; }
            public string? packageName { get; set; }
            public int quantity { get; set; }
            public string? cName { get; set; }
            public string? cPhone { get; set; }
            public string? orderDate { get; set; }
            public string? DeliveryDate { get; set; }
            public string? Description { get; set; }
            public string? location { get; set; }
            public string? tracking { get; set; }


        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string uri = "https://localhost:44325/api/Orders";
                WebClient client = new WebClient();
                client.Headers["content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                Order order = new Order();

                order.packageName = txtPackage.Text;
                order.quantity = Convert.ToInt32(txtQuantity.Text);
                order.cName = txtCustomer.Text;
                order.cPhone = txtTel.Text;
                order.orderDate = dtpOrderDate.Value.Date.ToString("O");
                order.DeliveryDate = dtpDeliveryDate.Value.Date.ToString("O");
                order.Description = txtDesc.Text;
                order.location = txtLocation.Text;
                order.tracking = txtTrack.Text;

                String info = (new JavaScriptSerializer().Serialize(order));

                string up = client.UploadString(uri, info);
                MessageBox.Show("Order Placed Successfully, Thank you for using Yien Express");
                txtPackage.Clear();
                txtQuantity.Clear();
                txtCustomer.Clear();
                txtTel.Clear();
                txtDesc.Clear();
                txtLocation.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Order_Add_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
