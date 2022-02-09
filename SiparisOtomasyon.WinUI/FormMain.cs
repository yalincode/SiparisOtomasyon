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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void newCustomerMenuItem_Click(object sender, EventArgs e)
        {
            
            ShowMidiForm(new CustomerForm());
        }

        private void customerListMenuİtem_Click(object sender, EventArgs e)
        {
            
            ShowMidiForm(new CustomerListForm());
        }

        public void ShowMidiForm(Form form)
        {
            checkOpenForm();

            form.MdiParent = this; //Diğer formları ana formun içinde açmak için.
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void checkOpenForm()
        {
            //Form clouseForm = null;
            //foreach (Form openForm in Application.OpenForms)
            //{
            //    if (openForm.MdiParent != null)
            //    {
            //        clouseForm = openForm;
            //    }
            //}
            //if (clouseForm!=null)
            //{
            //    clouseForm.Close();
            //}

            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].MdiParent != null)
                {
                    Application.OpenForms[i].Close();
                    i--;
                }
            }
            
        }

        private void yeniÜrünToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMidiForm(new ProductForm());
        }

        private void ürünListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMidiForm(new ProductListForm());
        }

        private void yeniSiparişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMidiForm(new OrderForm());
        }

        private void siparişListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMidiForm(new OrderListForm());
        }
    }
}
