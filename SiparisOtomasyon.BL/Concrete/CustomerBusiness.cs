using SiparisOtomasyon.BL.Absract;
using SiparisOtomasyon.DAL.Abstract;
using SiparisOtomasyon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    public class CustomerBusiness : ICustomerBusiness
    {
        //ms test projesi araştır?
        //EF DBcontext nesnesi araştır?
        private ICustomerRepo customerRepo;
        public CustomerBusiness()
        {
            customerRepo = new CustomerRepo();
        }
        public void Add(Customers item)
        {
            customerRepo.Add(item);
        }

        public bool Delete(string id)
        {
            return customerRepo.Delete(id);
        }

        public List<Customers> Get()
        {
            return customerRepo.Get();
        }

        public Customers GetById(string id)
        {
            return customerRepo.GetById(id);
        }

        public void Update(Customers item)
        {
            customerRepo.Update(item);
        }
    }
}
