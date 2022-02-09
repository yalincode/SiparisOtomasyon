using SiparisOtomasyon.BL.Absract;
using SiparisOtomasyon.DAL.Abstract;
using SiparisOtomasyon.DAL.Concrete;
using SiparisOtomasyon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    public class SupplierBusiness : ISupplierBusiness
    {
        ISupplierRepo supplierRepo;
        public SupplierBusiness()
        {
            supplierRepo = new SupplierRepo();
        }
        public void Add(Suppliers item)
        {
            supplierRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return supplierRepo.Delete(id);
        }

        public List<Suppliers> Get()
        {
            return supplierRepo.Get().ToList();
        }

        public Suppliers GetById(int id)
        {
            return supplierRepo.GetById(id);
        }

        public void Update(Suppliers item)
        {
            supplierRepo.Update(item);
        }
    }
}
