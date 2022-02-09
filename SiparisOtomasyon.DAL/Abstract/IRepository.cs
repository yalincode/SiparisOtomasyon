using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    public interface IRepository<T,T1>
    {
        void Add(T item);
        void Update(T item);
        bool Delete(T1 id);

        List<T> Get();

        T GetById(T1 id);
    }
}
