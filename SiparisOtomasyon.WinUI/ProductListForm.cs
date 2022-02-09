using SiparisOtomasyon.BL.Absract;
using SiparisOtomasyon.BL.Concrete;
using SiparisOtomasyon.DAL.Context;
using SiparisOtomasyon.DAL.VM;
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
    public partial class ProductListForm : Form
    {
        IProductBusiness productBusiness;
        public ProductListForm()
        {
            InitializeComponent();
            productBusiness = new ProductBusiness();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            FillColumnMapping();
            FillGrid();
        }

        private void FillGrid()
        {
            grid.DataSource = null;
            grid.DataSource = productBusiness.GetProductsVM();

        }

        private void FillColumnMapping()
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("ProductName", "ProductName", "Ürün Adı"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("CategoryName", "CategoryName", "Kategori Adı"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("SupplierName", "SupplierName", "Tedarikçi Adı"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("UnitPrice", "UnitPrice", "Ürün Fiyatı"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("UnitsInStock", "UnitsInStock", "Mevcut Stok"));
        }

        

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var Product = (grid.DataSource as List<ProductVM>)[e.RowIndex];
            if (Product!=null)
            {
                var form = new ProductForm();
                form.Dock = DockStyle.Fill;
                form.MdiParent = this.MdiParent;
                form.Tag = Product.ProductID;
                form.FormClosed += Form_FormClosed;
                form.Show(); 
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGrid();
        }
    }
}
