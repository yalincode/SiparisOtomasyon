using SiparisOtomasyon.BL.Absract;
using SiparisOtomasyon.BL.Concrete;
using SiparisOtomasyon.DAL.Context;
using SiparisOtomasyon.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisOtomasyon.WinUI
{
    public partial class CustomerListForm : Form
    {
        ICustomerBusiness customerBusiness;

        public CustomerListForm()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();

            
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            FillColumnMapping();
            FillGrid();
        }

        private void FillColumnMapping()
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("CompanyName","CompanyName", "Müşteri Adı"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("ContactName", "ContactName", "İlgili Kişi"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("ContactTitle", "ContactTitle", "İlgili Ünvan"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("Phone", "Phone", "Telefon"));

        }

        private void FillGrid()
        {
            grid.DataSource = null;
            grid.DataSource = customerBusiness.Get();
        }

        

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var Customer = (grid.DataSource as List<Customers>)[e.RowIndex];
            var form=new CustomerForm();
            form.Dock= DockStyle.Fill;
            form.MdiParent = this.MdiParent;
            form.Tag = Customer.CustomerID;
            form.FormClosed += Form_FormClosed;
            form.Show();
            
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGrid();
        }
    }
}
