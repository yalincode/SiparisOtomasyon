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
    using DAL.Context;
    using BL.Concrete;
    using SiparisOtomasyon.DAL.Abstract;
    using Helper;
    using SiparisOtomasyon.DAL.Concrete;
    using SiparisOtomasyon.DAL.VM;

    public partial class OrderForm : Form
    {
        ICustomerBusiness customerBusiness;
        IEmployeeBusiness employeeBusiness;
        IShipperBusiness shipperBusiness;
        IProductBusiness productBusiness;
        IOrderBusiness orderBusiness;
        IOrderDetailBusiness orderDetailBusiness;
        public OrderForm()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();
            employeeBusiness = new EmployeeBusiness();
            shipperBusiness=new ShipperBusiness();
            productBusiness=new ProductBusiness();
            orderBusiness = new OrderBusiness();
            orderDetailBusiness=new OrderDetailBusiness();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            FillControl();
            FillOrderDetailGridMapping();
            FillDataOrder();
            
        }


        //Sipariş Detayı için kullanılacak
        private void FillDataOrderDetail(int id)
        {
            if (id>0)
            {
                var orderDetail = orderDetailBusiness.GetOrderDetailVM(id);
                gridOrderDetail.DataSource = null;
                gridOrderDetail.DataSource=orderDetail;
            }
        }

        private void FillOrderDetailGridMapping()
        {
            gridOrderDetail.AutoGenerateColumns = false;
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("ProductName", "ProductName", "Ürün Adı"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("UnitPrice", "UnitPrice", "Ürün Fiyatı"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("Quantity", "Quantity", "Adet"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("Discount", "Discount", "İndirim"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridTextBoxColumn("Total", "Total", "Satır Toplamı"));
            gridOrderDetail.Columns["Total"].DefaultCellStyle.Format = "N2";
        }

        Orders selectedOrder = null;
        private void FillDataOrder()
        {
            int id = Convert.ToInt32(this.Tag);
            if (id>0)
            {
                var order = orderBusiness.GetById(id);
                if (order != null)
                {
                    selectedOrder=order;
                    cmbCutomer.SetSelectedValue(order.CustomerID);
                    cmbEmployee.SetSelectedValue(order.EmployeeID);
                    cmbShipVia.SetSelectedValue(order.ShipVia);
                    dtOrderDate.Value= Convert.ToDateTime(order.OrderDate);
                    dtShippendDate.Value = Convert.ToDateTime(order.ShippedDate);
                    nuShipPrice.Value = Convert.ToDecimal(order.Freight);
                    txtShipCountry.Text=order.ShipCountry;
                    txtShipAddres.Text = order.ShipAddress;
                    txtShipPostalCode.Text=order.ShipPostalCode;
                    txtShipRegion.Text=order.ShipRegion;

                    FillDataOrderDetail(id);
                }
            }
        }

        private void FillControl()
        {
            FillCustomer();
            FillPersonal();
            FillShipper();
            FillProduct();
        }

        private void FillProduct()
        {
            var product = productBusiness.Get();
            cmbProduct.SetDataSourceFirstItem<int, Products>(product, "ProductName", "ProductID", "Seçiniz");
        }

        private void FillShipper()
        {
            var shipper = shipperBusiness.Get();
            cmbShipVia.SetDataSourceFirstItem<int, Shippers>(shipper, "CompanyName", "ShipperID", "Seçiniz");
        }

        private void FillPersonal()
        {
            var employee = employeeBusiness.Get();
            cmbEmployee.SetDataSourceFirstItem<int, Employees>(employee, "FirstName", "EmployeeID", "Seçiniz");
        }

        private void FillCustomer()
        {
            cmbCutomer.DataSource = customerBusiness.Get();
            cmbCutomer.DisplayMember = "CompanyName";
            cmbCutomer.ValueMember = "CustomerID";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {

            try
            {
                //validasyonlar yazılmalı orderdetail daki gibi
                if (this.selectedOrder == null)
                {
                    selectedOrder = new Orders();
                }

                selectedOrder.CustomerID = cmbCutomer.SelectedValue.ToString();
                selectedOrder.EmployeeID = cmbEmployee.GetValue<int, Employees>();
                selectedOrder.ShipVia = cmbShipVia.GetValue<int, Shippers>();
                selectedOrder.OrderDate = dtOrderDate.Value;
                selectedOrder.RequiredDate = dtRequiredDate.Value;
                selectedOrder.Freight = nuShipPrice.Value;
                selectedOrder.ShipAddress = txtShipAddres.Text;
                selectedOrder.ShipCity = txtShipCity.Text;
                selectedOrder.ShipCountry = txtShipCountry.Text;
                selectedOrder.ShipPostalCode = txtShipPostalCode.Text;
                selectedOrder.ShipRegion = txtShipRegion.Text;

                if (Convert.ToInt32(this.Tag)>0)
                {
                    orderBusiness.Update(this.selectedOrder);
                }
                else
                {
                    orderBusiness.Add(this.selectedOrder);
                    this.Tag = selectedOrder.OrderID;
                }
                UICoreUtility.SuccessMessage("İşlem başarılı bir şekilde gerçekleşti");
            }
            catch (Exception ex)
            {

                UICoreUtility.ErrorMessage(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.Tag);
            if (id>0)
            {
                var dialog = UICoreUtility.DialogMessage("Kaydı silmek istediğinizden emin misiniz?");
                if (dialog==DialogResult.OK)
                {
                    orderDetailBusiness.Delete(id);
                    orderBusiness.Delete(id);
                    this.Close();
                }
            }
            
        }

        Order_Details selectedOrderDetail;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool isAdded = false;

                if (this.selectedOrder == null)
                {
                    UICoreUtility.ErrorMessage("lÜTFEN ÖNCE SİPARİŞ KAYIT YAPIN SONRA DETAYA GELİN");
                    return;
                }

                if (cmbCutomer.SelectedValue == null)
                {
                    UICoreUtility.ErrorMessage("Lütfen bir ürün seçimi yapınız");
                    cmbProduct.Focus();
                    return;
                }
                if (nuUnitPrice.Value == 0)
                {
                    UICoreUtility.ErrorMessage("Lütfen fiyat gir");
                    nuUnitPrice.Focus();
                    return;

                }
                if (nuQuantity.Value == 0)
                {
                    UICoreUtility.ErrorMessage("Lütfen miktar gir");
                    nuQuantity.Focus();
                    return;
                }

                if (selectedOrderDetail == null)
                {
                    selectedOrderDetail = new Order_Details();
                    isAdded = true;
                }

                selectedOrderDetail.OrderID = selectedOrder.OrderID;
                if(isAdded)
                    selectedOrderDetail.ProductID = cmbProduct.GetValue<int, Products>().Value;
                selectedOrderDetail.UnitPrice = nuUnitPrice.Value;
                selectedOrderDetail.Quantity = (short)nuQuantity.Value;
                selectedOrderDetail.Discount = Convert.ToSingle(nuDiscount.Value);

                if (isAdded)
                {
                    orderDetailBusiness.Add(selectedOrderDetail);
                }
                else
                {
                    orderDetailBusiness.Update(selectedOrderDetail);
                }
                FormDtailClear();
                FillDataOrderDetail(selectedOrder.OrderID);
                UICoreUtility.SuccessMessage("İşlem başarılı şekilde gerçekleşti");
            }
            catch (Exception ex)
            {

                UICoreUtility.ErrorMessage(ex.Message);
            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UICoreUtility.FormClear(this);
            this.selectedOrder = null;
            this.selectedOrderDetail= null;
            this.Tag = 0;
            gridOrderDetail.DataSource = null;
        }

        private void gridOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var orderDetail = ((gridOrderDetail.DataSource as List<OrderDetailVM>)[e.RowIndex]);
            if (orderDetail!=null)
            {
                cmbProduct.SelectedValue = orderDetail.ProductID;
                nuUnitPrice.Value=orderDetail.UnitPrice;
                nuQuantity.Value=orderDetail.Quantity;
                nuDiscount.Value=Convert.ToDecimal(orderDetail.Discount);
                selectedOrderDetail = new Order_Details()
                {
                    OrderID = orderDetail.OrderID,
                    Discount=orderDetail.Discount,
                    ProductID=orderDetail.ProductID,
                    Quantity=orderDetail.Quantity,
                    UnitPrice=orderDetail.UnitPrice
                };
            }
        }

        private void FormDtailClear()
        {
            selectedOrderDetail = null;
            UICoreUtility.FormClear(panel4);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridOrderDetail.SelectedRows.Count > 0)
                {
                    var dialogResult = UICoreUtility.DialogMessage("Seçilen kayıtları silmek istiyor musun?");
                    if (dialogResult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in gridOrderDetail.SelectedRows)
                        {
                            var item = (row.DataBoundItem as OrderDetailVM);

                            orderDetailBusiness.Delete(item.OrderID, item.ProductID);
                        }
                        UICoreUtility.SuccessMessage("İŞLEM BAŞARILI");
                        FillDataOrderDetail(this.selectedOrder.OrderID);
                    }
                }
            }
            catch (Exception EX)
            {

                UICoreUtility.ErrorMessage(EX.Message);
            }
        }

        private void TotalUpdate()
        {
            
            var orderDetails = (gridOrderDetail.DataSource as List<OrderDetailVM>);
            if (orderDetails!=null)
            {
                lblToplam.Text = $"Toplam Tutar = {orderDetails.Sum(t0 => t0.Total).ToString("N2")}";
            }
        }

        private void gridOrderDetail_DataSourceChanged(object sender, EventArgs e)
        {
            TotalUpdate();
        }
    }
}
