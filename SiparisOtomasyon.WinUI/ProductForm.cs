using SiparisOtomasyon.BL.Absract;
using SiparisOtomasyon.BL.Concrete;
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
    using DAL.Context;
    using SiparisOtomasyon.WinUI.Helper;
    using Helper;
    using BL.Concrete;

    public partial class ProductForm : Form
    {
        IProductBusiness productBusiness;
        ICategoryBusiness categoryBusiness;
        ISupplierBusiness supplierBusiness;
        public ProductForm()
        {
            InitializeComponent();
            productBusiness = new ProductBusiness();
            categoryBusiness = new CategoryBusiness();
            supplierBusiness = new SupplierBusiness();
        }
        Products selectedProduct;
        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillControl();
            FillData();
        }

        private void FillControl()
        {
            FillCategories();
            FillSuppliers();
        }

        private void FillSuppliers()
        {
            
            var suppliers = supplierBusiness.Get();
            UIExtension.SetDataSourceFirstItem<int, Suppliers>(cmbSupplier, suppliers, "CompanyName", "SupplierID", "Seçiniz");
            //cmbSupplier.DisplayMember = "CompanyName";
            //cmbSupplier.DataSource= suppliers;
            //cmbSupplier.ValueMember = "SupplierID";
        }

        private void FillCategories()
        {
            var categories = categoryBusiness.Get();
            UIExtension.SetDataSourceFirstItem<int, Categories>(cmbCategory, categories, "CategoryName", "CategoryID", "Seçiniz");
            //cmbCategory.DisplayMember = "CategoryName";
            //cmbCategory.DataSource = categories;
            //cmbCategory.ValueMember = "CategoryID";
        }

        private void FillData()
        {
            int id = Convert.ToInt32(this.Tag);
            if (id>0)
            {
                var product = productBusiness.GetById(id);
                if (product!=null)
                {
                    this.selectedProduct = product;
                    txtProductName.Text = product.ProductName;

                    if (product.CategoryID != null)
                    cmbCategory.SelectedValue = product.CategoryID;
                    
                    if (product.SupplierID != null)
                    cmbSupplier.SelectedValue= product.SupplierID;

                    chkDiscontinued.Checked = product.Discontinued;
                    nuReorderLevel.Value=Convert.ToDecimal(product.ReorderLevel);
                    nuUnitPrice.Value=Convert.ToDecimal(product.UnitPrice);
                    nuUnitsOnOrder.Value = Convert.ToDecimal(product.UnitsOnOrder);
                    nuUnitsInStock.Value = Convert.ToDecimal(product.UnitsInStock);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }
        
        private void FormClear()
        {
            this.Tag = null;
            this.selectedProduct = null;
            UICoreUtility.FormClear(this);
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
