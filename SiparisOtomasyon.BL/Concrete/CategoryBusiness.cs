using SiparisOtomasyon.BL.Absract;
using SiparisOtomasyon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    using DAL;
    using SiparisOtomasyon.DAL.Abstract;
    using SiparisOtomasyon.DAL.Concrete;

    public class CategoryBusiness : ICategoryBusiness
    {
        ICategoryRepo categoryRepo;
        public CategoryBusiness()
        {
            categoryRepo = new CategoryRepo();
        }
        public void Add(Categories item)
        {
            categoryRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return categoryRepo.Delete(id);
        }

        public List<Categories> Get()
        {
            return categoryRepo.Get().ToList();
        }

        public Categories GetById(int id)
        {
            return categoryRepo.GetById(id);
        }

        public void Update(Categories item)
        {
            categoryRepo.Update(item);
        }
    }
}
