using SiparisOtomasyon.BL.Absract;
using SiparisOtomasyon.DAL.Abstract;
using SiparisOtomasyon.DAL.Concrete;
using SiparisOtomasyon.DAL.Context;
using SiparisOtomasyon.DAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    public class OrderBusiness : IOrderBusiness
    {
        IOrderRepo orderRepo;
        public OrderBusiness()
        {
            orderRepo =new OrderRepo();
        }
        public void Add(Orders item)
        {
            orderRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return orderRepo.Delete(id);
        }

        public List<Orders> Get()
        {
            return orderRepo.Get();
        }

        public Orders GetById(int id)
        {
            return orderRepo.GetById(id);
        }

        public List<OrderVM> GetOrderVM()
        {
            return orderRepo.GetOrderVM();
        }

        public void Update(Orders item)
        {
            orderRepo.Update(item);
        }
    }
}
