using SiparisOtomasyon.DAL.Abstract;
using SiparisOtomasyon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    public class EmployeeRepo:GenericRepository<Employees,int>,IEmployeeRepo
    {

    }
}
