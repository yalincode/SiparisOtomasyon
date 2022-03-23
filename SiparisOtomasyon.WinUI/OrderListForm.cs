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
    using BL.Absract;
    using BL.Concrete;
    using DAL.Context;
    using SiparisOtomasyon.DAL.VM;
    using SiparisOtomasyon.WinUI.Helper;

    public partial class OrderListForm : Form
    {
        IOrderBusiness orderBusiness;
        public OrderListForm()
        {
            InitializeComponent();
            orderBusiness=new OrderBusiness();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            FillMapping();
            FillData();
        }

        private void FillData()
        {
            grid.DataSource = null;
            grid.DataSource = orderBusiness.GetOrderVM();
        }

        private void FillMapping()
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("CustomerName", "CustomerName", "Müşteri Adı"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("PersonalName", "PersonalName", "Personel Adı"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("OrderDate", "OrderDate", "Sipariş Tarihi"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("CargoName", "CargoName","Kargo Firması"));
            grid.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("Shipname", "ShipName","Alıcı"));
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var order = (grid.DataSource as List<OrderVM>)[e.RowIndex];

            var form = new OrderForm();
            form.MdiParent = this.MdiParent;
            form.Dock = DockStyle.Fill;
            form.Tag = order.OrderID;
            form.FormClosed += Form_FormClosed;
            form.Show();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillData();
        }
    }
}
