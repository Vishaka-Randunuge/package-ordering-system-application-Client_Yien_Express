using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Yien_Express
{
    public partial class Packages_Stock : Form
    {
        public Packages_Stock()
        {
            InitializeComponent();
        }

        private void Packages_Stock_Load(object sender, EventArgs e)
        {
            LoadData();
            this.WindowState = FormWindowState.Maximized;
        }
        private void LoadData()
        {
            string uri = "https://localhost:44325/api/Packages\r\n";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(uri);
            dgvPackages.DataSource = null;
            dgvPackages.DataSource = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Package>>(json);

        }

        public class Package
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public int ReorderLevel { get; set; }
            public string? Category { get; set; }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string uri = "https://localhost:44325/api/Packages";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            Package package = new Package();
            package.Name = txtName.Text;
            package.Price = Convert.ToDecimal(txtPrice.Text);
            package.Stock = Convert.ToInt32(txtStock.Text);
            package.ReorderLevel = Convert.ToInt32(txtReorder.Text);
            package.Category = txtCategory.Text;
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(package);
            client.UploadString(uri, data);
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string uri = "https://localhost:44325/api/Packages/" + lblID.Text;
            HttpClient client = new HttpClient();

            Package package = new Package();
            package.ID = Convert.ToInt32(lblID.Text);
            package.Name = txtName.Text;
            package.Price = Convert.ToDecimal(txtPrice.Text);
            package.Stock = Convert.ToInt32(txtStock.Text);
            package.ReorderLevel = Convert.ToInt32(txtReorder.Text);
            package.Category = txtCategory.Text;
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(package);
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var response = client.PutAsync(uri, content);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
                LoadData();
            else
                MessageBox.Show("Failed to Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string uri = "https://localhost:44325/api/Packages/" + lblID.Text;
            HttpClient client = new HttpClient();
            var res = client.DeleteAsync(uri);
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                LoadData();
            }
            else
                MessageBox.Show("Fail to Delete");
        }

        private void dgvPackages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;
            if (c == 0)
            {
                DataGridViewRow row = dgvPackages.Rows[r];
                lblID.Text = row.Cells[1].Value.ToString();
                txtName.Text = row.Cells[2].Value.ToString();
                txtPrice.Text = row.Cells[3].Value.ToString();
                txtStock.Text = row.Cells[4].Value.ToString();
                txtReorder.Text = row.Cells[5].Value.ToString();
                txtCategory.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        /* private void Packages_Stock_Load(object sender, EventArgs e)
         {
             LoadData();
         }*/
    }
}
