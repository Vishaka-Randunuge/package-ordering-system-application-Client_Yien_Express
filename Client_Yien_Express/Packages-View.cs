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
    public partial class Packages_View : Form
    {
        public Packages_View()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            string uri = "https://localhost:44325/api/Packages";
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            String json = client.DownloadString(uri);
            dgvPackage.DataSource = (new JavaScriptSerializer().Deserialize<List<Package>>(json));

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

        private void Packages_View_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
