using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        public class User
        {
            public int Id { get; set; }
            public string? userType { get; set; }
            public string? userName { get; set; }
            public string? Password { get; set; }

        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string uri = "https://localhost:44325/api/Users";
                WebClient client = new WebClient();
                client.Headers["content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                User user = new User();

                user.userType = cmbType.Text;
                user.userName = txtName.Text;
                user.Password = txtPass.Text;

                String info = (new JavaScriptSerializer().Serialize(user));

                string up = client.UploadString(uri, info);
                MessageBox.Show("Registered Successfully!");
                
                txtName.Clear();
                txtPass.Clear();

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

        private void Registration_Load(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Maximized;
        }
    }
}
