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
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepo productRepo;
        public ProductBusiness()
        {
            productRepo = new ProductRepo();
        }
        public void Add(Products item)
        {
            productRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return productRepo.Delete(id);
        }

        public List<Products> Get()
        {
            return productRepo.Get();
        }

        public Products GetById(int id)
        {
            return productRepo.GetById(id);
        }

        public List<ProductVM> GetProductsVM()
        {
            return productRepo.GetProductVM();
        }

        public void Update(Products item)
        {
            productRepo.Update(item);
        }
    }
}
