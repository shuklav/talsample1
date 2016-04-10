using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace talsample1
{
    public partial class addSupplier : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=tal;database=tal_v4;persistsecurityinfo=True;logging=True");


        public addSupplier()
        {
            InitializeComponent();
        }

        private void addSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'tal_v4dsListOfSupplierInAddSupplierForm.suppliers' table. You can move, or remove it, as needed.
                this.suppliersTableAdapter.Fill(this.tal_v4dsListOfSupplierInAddSupplierForm.suppliers);
            }
            catch(Exception ex) {MessageBox.Show(ex.Message); }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.suppliersTableAdapter.FillBy(this.tal_v4dsListOfSupplierInAddSupplierForm.suppliers);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {

        }
    }
}
