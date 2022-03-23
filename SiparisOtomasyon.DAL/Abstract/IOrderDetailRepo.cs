using SiparisOtomasyon.DAL.Context;
using SiparisOtomasyon.DAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    public interface IOrderDetailRepo
    {
        void Add(Order_Details item);
        void Update(Order_Details item);
        List<Order_Details> Get(int OrderId);
        Order_Details GetById(int OrderId,int ProductId);
        bool Delete(int OrderId, int ProductId);
        List<OrderDetailVM> GetOrderDetailVM(int OrderId);

        bool Delete(int OrderId);

    }
}
