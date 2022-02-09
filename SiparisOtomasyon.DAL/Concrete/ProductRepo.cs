using SiparisOtomasyon.DAL.Abstract;
using SiparisOtomasyon.DAL.Context;
using SiparisOtomasyon.DAL.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    public class ProductRepo : IProductRepo
    {
        NortwindContext DB;
        public ProductRepo()
        {
            DB = new NortwindContext();
        }
        public void Add(Products item)
        {
            DB.Products.Add(item);
            DB.SaveChanges();
        }

        public bool Delete(int id)
        {
            var dbItem=DB.Products.FirstOrDefault(t0=>t0.ProductID==id);
            if (dbItem != null)
            {
                DB.Products.Remove(dbItem);
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Products> Get()
        {
            return DB.Products.AsNoTracking().ToList();
        }

        public Products GetById(int id)
        {
            return DB.Products.AsNoTracking().FirstOrDefault(t0=>t0.ProductID==id);
        }

        public List<ProductVM> GetProductVM()
        {
            var Products = (from t0 in DB.Products
                            select new ProductVM
                            {
                                ProductID = t0.ProductID,
                                CategoryName=t0.Categories.CategoryName,
                                ProductName=t0.ProductName,
                                SupplierName=t0.Suppliers.CompanyName,
                                UnitPrice=t0.UnitPrice,
                                UnitsInStock=t0.UnitsInStock,

                            }).ToList();
            return Products;
        }

        public void Update(Products item)
        {
            DB.Entry(item).State = EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
