using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace talsample1
{
    public partial class purchaseOrderForm : Form
    {
        public purchaseOrderForm()
        {
            InitializeComponent();
        }

        private void purchaseOrderForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tal_v4dsSupplierDetails.suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.tal_v4dsSupplierDetails.suppliers);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.suppliersTableAdapter.FillBy(this.tal_v4dsSupplierDetails.suppliers);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            addSupplier ads = new addSupplier();
            ads.Show();
            
        }

        
    }
}
