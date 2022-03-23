using SiparisOtomasyon.DAL.Abstract;
using SiparisOtomasyon.DAL.Context;
using SiparisOtomasyon.DAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        NortwindContext DB;
        public OrderDetailRepo()
        {
            DB = new NortwindContext();
        }
        public void Add(Order_Details item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Added;
            DB.SaveChanges();
        }

        public bool Delete(int OrderId, int ProductId)
        {
            var orderDetail = DB.Order_Details.FirstOrDefault(t0 => t0.OrderID == OrderId && t0.ProductID == ProductId);
            if (orderDetail != null)
            {
                DB.Entry(orderDetail).State = System.Data.Entity.EntityState.Detached;
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int OrderId)
        {
            var orderDetail = DB.Order_Details.Where(t0 => t0.OrderID == OrderId);
            if (orderDetail!=null)
            {
               
                foreach (var item in orderDetail)
                {
                    DB.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                DB.SaveChanges();
                return true; 
            }
            else
            {
                return false;
            }
        }

        public List<Order_Details> Get(int OrderId)
        {
            return DB.Order_Details.Where(t0 => t0.OrderID == OrderId).ToList();
        }

        

        public Order_Details GetById(int OrderId, int ProductId)
        {
            return DB.Order_Details.FirstOrDefault(t0 => t0.OrderID == OrderId && t0.ProductID == ProductId);
        }

        public List<OrderDetailVM> GetOrderDetailVM(int OrderId)
        {
            var result = (from t0 in DB.Order_Details
                          where t0.OrderID == OrderId
                          select new OrderDetailVM
                          {
                              OrderID = t0.OrderID,
                              Discount = t0.Discount,
                              ProductID = t0.ProductID,
                              ProductName = t0.Products.ProductName,
                              Quantity=t0.Quantity,
                              UnitPrice=t0.UnitPrice,
                          }).ToList();
            return result;
        }

        public void Update(Order_Details item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
