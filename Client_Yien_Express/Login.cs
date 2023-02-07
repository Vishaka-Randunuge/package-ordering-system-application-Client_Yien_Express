using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Yien_Express
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public System.Windows.Forms.ComboBox.ObjectCollection Employee { get; private set; }
        public System.Windows.Forms.ComboBox.ObjectCollection Corporate_Client { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-H6ES71O; Initial Catalog = YienDB; TrustServerCertificate=True;Persist Security Info=True;Integrated Security = True"); // making connection   
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM users WHERE userType='" + cmbType.Text + "'AND userName='" + txtName.Text + "' AND Password='" + txtPass.Text + "'", con);
            DataTable dt = new DataTable();   
            sda.Fill(dt);
            int type = -1;
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (cmbType.Text == "Employee")
                    type = 0;

                else if (cmbType.Items == Corporate_Client)
                    type = 1;

                else
                {
                    type = 2;
                }
                ((MainMenu)(Application.OpenForms["MainMenu"])).menuAvailability(true, type);
                this.Close();
            }
            else
                MessageBox.Show("Invalid username or password");
         }

        private void Login_Load(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Maximized;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }
    }
}
