using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Absract
{
    public interface IBusiness<T,T2>
    {
        void Add(T item);
        void Update(T item);
        bool Delete(T2 id);
        List<T> Get();
        T GetById(T2 id);
    }
}
