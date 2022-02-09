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
    public class ShipperBusiness : IShipperBusiness
    {
        IShipperRepo shipperRepo;
        public void Add(Shippers item)
        {
            shipperRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return shipperRepo.Delete(id);
        }

        public List<Shippers> Get()
        {
            return shipperRepo.Get();
        }

        public Shippers GetById(int id)
        {
            return shipperRepo.GetById(id);
        }

        public void Update(Shippers item)
        {
            shipperRepo.Update(item);
        }
    }
}
