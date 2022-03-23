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
    public class OrderRepo : GenericRepository<Orders, int>, IOrderRepo
    {
        public List<OrderVM> GetOrderVM()
        {
            var result = (from t0 in DB.Orders
                          select new OrderVM()
                          {
                              OrderID = t0.OrderID,
                              CargoName=t0.Shippers.CompanyName,
                              CustomerName=t0.Customers.CompanyName,
                              OrderDate=t0.OrderDate,
                              personalName=t0.Employees.FirstName+" "+t0.Employees.LastName,
                              ShipName=t0.ShipName
                          }).ToList();
            return result;
        }
    }
}
