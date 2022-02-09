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
    public class EmployeeBusiness : IEmployeeBusiness
    {
        IEmployeeRepo employeeRepo;
        public EmployeeBusiness()
        {
            employeeRepo = new EmployeeRepo();
        }
        public void Add(Employees item)
        {
            employeeRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return employeeRepo.Delete(id); 
        }

        public List<Employees> Get()
        {
            return employeeRepo.Get();
        }

        public Employees GetById(int id)
        {
            return employeeRepo.GetById(id);
        }

        public void Update(Employees item)
        {
            employeeRepo.Update(item);
        }
    }
}
