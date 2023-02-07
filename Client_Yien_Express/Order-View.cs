using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Yien_Express
{
    public partial class Order_View : Form
    {
        public Order_View()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string uri = "https://localhost:44325/api/Orders?OrderId" + txtOrderID.Text; ;
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            String json = client.DownloadString(uri);
            dgvOrder.DataSource = (new JavaScriptSerializer().Deserialize<List<Order>>(json));

        }
        private void Order_View_Load(object sender, EventArgs e)
        {
            LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void txtOrderID_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvOrder.DataSource];
            currencyManager.SuspendBinding();
            this.dgvOrder.ClearSelection();
            foreach (DataGridViewRow r in this.dgvOrder.Rows)
            {
                if (r.Cells[3].Value != null)
                {
                    if ((r.Cells[3].Value).ToString().StartsWith(this.txtOrderID.Text.Trim()))
                    {
                        this.dgvOrder.Rows[r.Index].Visible = true;
                    }
                    else
                    {
                        dgvOrder.Rows[r.Index].Visible = false;
                    }
                }
                currencyManager.ResumeBinding();
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

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
