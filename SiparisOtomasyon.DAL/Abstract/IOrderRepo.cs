using SiparisOtomasyon.DAL.Context;
using SiparisOtomasyon.DAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    public interface IOrderRepo:IRepository<Orders,int>
    {
        List<OrderVM> GetOrderVM();
    }
}
