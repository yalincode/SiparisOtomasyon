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
    public partial class CustomerForm : Form
    {
        ICustomerBusiness customerBusiness;
        public CustomerForm()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();
        }
        Customers selectedCustomer=null;
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            FillData(); 
        }

        private void FillData()
        {
            string id = this.Tag?.ToString();//null gelen tagin patlamasını engelliyor.? this.Tag!=null
            if (!string.IsNullOrWhiteSpace(id))
            {
                selectedCustomer = customerBusiness.GetById(id);

                if (selectedCustomer!=null)
                {
                    txtCompanyName.Text = this.selectedCustomer.CompanyName;
                    txtContactName.Text = this.selectedCustomer.ContactName;
                    txtContactTitle.Text = this.selectedCustomer.ContactTitle;
                    txtPostaCode.Text = this.selectedCustomer.PostalCode;
                    txtPhone.Text = this.selectedCustomer.Phone;
                    txtFax.Text = this.selectedCustomer.Fax;
                    txtCountry.Text = this.selectedCustomer.Country;
                    txtRegion.Text = this.selectedCustomer.Region;
                    txtAdress.Text = this.selectedCustomer.Address; 
                }
            }

            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        public void FormClear()
        {
            this.selectedCustomer = null;
            this.Tag=null;
            UICoreUtility.FormClear(this);
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {
                if (this.selectedCustomer == null)
                {
                    this.selectedCustomer = new Customers();
                    this.selectedCustomer.CustomerID= GenerateCustomerCode(5);
                }

                this.selectedCustomer.CompanyName = txtCompanyName.Text;
                this.selectedCustomer.ContactTitle = txtContactTitle.Text;
                this.selectedCustomer.ContactName = txtContactName.Text;
                this.selectedCustomer.PostalCode = txtPostaCode.Text;
                this.selectedCustomer.Phone = txtPhone.Text;
                this.selectedCustomer.Fax = txtFax.Text;
                this.selectedCustomer.Country = txtCountry.Text;
                this.selectedCustomer.City = txtCity.Text;
                this.selectedCustomer.Region = txtRegion.Text;
                this.selectedCustomer.Address = txtAdress.Text;

                string id = this.Tag?.ToString();
                if (!string.IsNullOrWhiteSpace(id))
                    customerBusiness.Update(this.selectedCustomer);
                else
                {
                    customerBusiness.Add(this.selectedCustomer);
                    this.Tag = this.selectedCustomer.CustomerID;
                }
                UICoreUtility.SuccessMessage("İşlem başarılı bir şekilde yapıldı.");
            }
            catch (Exception ex)
            {
                UICoreUtility.ErrorMessage(ex.Message);
            }

        }

        static Random rnd=new Random();
        private string GenerateCustomerCode(int length)
        {
            const string chars = "ABCDEFGLMNOPRSTUVYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(t0 => t0[rnd.Next(t0.Length)]).ToArray());
            //enumarable karakter seti gibi kullanılan metni repeatler. ve chars içinden önce random ile bir hece seçilir. seçilen heceler yanyana sıralanır sonra da toarray şeklinde string dizisi haline getirilir.
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UICoreUtility.DialogMessage("Bu Kaydı Silmek İstiyor musunuz?")==DialogResult.OK)
            {
                try
                {
                    if (customerBusiness.Delete(this.selectedCustomer.CustomerID))
                    {
                        UICoreUtility.SuccessMessage("Silme işlemi başarılı.");
                        this.Close();

                    }
                    else
                    {
                        UICoreUtility.ErrorMessage("Silme işlemi sırasında hata meydana geldi");
                    }
                }
                catch (Exception ex)
                {

                    UICoreUtility.ErrorMessage(ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
