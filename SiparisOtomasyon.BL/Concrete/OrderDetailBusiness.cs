using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    using DAL.Abstract;
    using SiparisOtomasyon.BL.Absract;
    using SiparisOtomasyon.DAL.Concrete;
    using SiparisOtomasyon.DAL.Context;
    using SiparisOtomasyon.DAL.VM;

    public class OrderDetailBusiness : IOrderDetailBusiness
    {
        IOrderDetailRepo orderDetailRepo;
        public OrderDetailBusiness()
        {
            orderDetailRepo = new OrderDetailRepo();
        }

        public void Add(Order_Details item)
        {
            orderDetailRepo.Add(item);
        }

        public bool Delete(int OrderId, int ProductId)
        {
            return orderDetailRepo.Delete(OrderId, ProductId);
        }

        public bool Delete(int OrderId)
        {
            return orderDetailRepo.Delete(OrderId);
        }

        public List<Order_Details> Get(int OrderId)
        {
            return orderDetailRepo.Get(OrderId);
        }

        public Order_Details GetById(int OrderId, int ProductId)
        {
            return orderDetailRepo.GetById(OrderId, ProductId);
        }

        public List<OrderDetailVM> GetOrderDetailVM(int OrderId)
        {
            return orderDetailRepo.GetOrderDetailVM(OrderId);
        }

        public void Update(Order_Details item)
        {
            orderDetailRepo.Update(item);
        }
    }
}
