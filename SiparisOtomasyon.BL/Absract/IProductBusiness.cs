using SiparisOtomasyon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Absract
{
    using DAL.VM;
    public interface IProductBusiness:IBusiness<Products,int>
    {
        List<ProductVM> GetProductsVM();
    }
}
