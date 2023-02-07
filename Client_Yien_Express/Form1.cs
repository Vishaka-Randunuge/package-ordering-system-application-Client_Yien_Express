namespace Client_Yien_Express
{
    public partial class MainMenu : Form
    {
        public static MainMenu obj;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            menuAvailability(false, -1);
        }
        public void menuAvailability(bool access, int type)
        {
            if (type == 0)
            {
                stockPackagesToolStripMenuItem.Visible = access;
                viewOrdersToolStripMenuItem.Visible = access;
                customersToolStripMenuItem.Visible = access;
                logOutToolStripMenuItem.Visible = access;   

            }

            else if (type == 1)
            {
                viewOrdersToolStripMenuItem1.Visible = access;
                //addToolStripMenuItem.Visible = access;
                //viewOrdersToolStripMenuItem.Visible = access;
                viewPackagesToolStripMenuItem.Visible = access;
                logOutToolStripMenuItem.Visible = access;
            }

            else if (type == 2)
            {
                viewOrdersToolStripMenuItem1.Visible = access;
                //addToolStripMenuItem.Visible = access;
                //viewOrdersToolStripMenuItem.Visible = access;
                viewPackagesToolStripMenuItem.Visible = access;
                logOutToolStripMenuItem.Visible = access;
            }

            else
            {
                stockPackagesToolStripMenuItem.Visible = access;
                viewOrdersToolStripMenuItem.Visible = access;
                customersToolStripMenuItem.Visible = access;
                viewOrdersToolStripMenuItem1.Visible = access;
                //addToolStripMenuItem.Visible = access;
                //viewOrdersToolStripMenuItem.Visible = access;
                viewPackagesToolStripMenuItem.Visible = access;
                logOutToolStripMenuItem.Visible = access;
                obj = this;

            }



        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Registration reg = new Registration();
                reg.ShowDialog();
            }
            catch (Exception x)
            {

            }
            Cursor.Current = Cursors.Default;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Login log = new Login();
                log.ShowDialog();
            }
            catch (Exception x)
            {

            }
            Cursor.Current = Cursors.Default;
        }

        private void stockPackagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packages_Stock stock = new Packages_Stock();
            stock.MdiParent = this;
            stock.Dock = DockStyle.Fill;
            stock.WindowState = FormWindowState.Maximized;
            stock.Show();
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order_Update updateOrders = new Order_Update();
            updateOrders.MdiParent = this;
            updateOrders.Dock = DockStyle.Fill;
            updateOrders.WindowState = FormWindowState.Maximized;
            updateOrders.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.MdiParent = this;
            customers.Dock = DockStyle.Fill;
            customers.WindowState = FormWindowState.Maximized;
            customers.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order_Add addOrders = new Order_Add();
            addOrders.MdiParent = this;
            addOrders.Dock = DockStyle.Fill;
            addOrders.WindowState = FormWindowState.Maximized;
            addOrders.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order_View viewOrders = new Order_View();
            viewOrders.MdiParent = this;
            viewOrders.Dock = DockStyle.Fill;
            viewOrders.WindowState = FormWindowState.Maximized;
            viewOrders.Show();
        }

        private void viewPackagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packages_View viewPackages = new Packages_View();
            viewPackages.MdiParent = this;
            viewPackages.Dock = DockStyle.Fill;
            viewPackages.WindowState = FormWindowState.Maximized;
            viewPackages.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewOrdersToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}