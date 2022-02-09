using SiparisOtomasyon.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Context
{
    public class CustomerRepo : ICustomerRepo
    {
        private NortwindContext DB;
        public CustomerRepo()
        {
            DB= new NortwindContext();
        }
        public void Add(Customers item)
        {
            DB.Customers.Add(item);
            DB.SaveChanges();
        }

        public bool Delete(string id)
        {
            var dbItem = DB.Customers.FirstOrDefault(t0 => t0.CustomerID == id);
            if (dbItem != null)
            {
                DB.Customers.Remove(dbItem);
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Customers> Get()
        {
           return DB.Customers.AsNoTracking().ToList();
        }

        public Customers GetById(string id)
        {
            
            return DB.Customers.AsNoTracking().FirstOrDefault(t0 => t0.CustomerID == id);
            //Nesne takip etmesini AsNoTracking ile önler. Nesne takip etmesi gridin yenilenmesini önler.
        }

        public void Update(Customers item)
        {
            DB.Entry(item).State=System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
