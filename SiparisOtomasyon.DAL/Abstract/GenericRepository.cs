using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    using DAL.Context;
    using System.Data.Entity;

    //T tipi nesnenin tipi T1 tipi customer tablosu özelinde yazılmış Id için belirtilen tip
    //T tipleri referans tipli olması için kısıtlama yapıldı yoksa DbSet nesnesi çalışmaz.
    public abstract class GenericRepository<T, T1> : IRepository<T, T1> where T : class
    {
        private NortwindContext _DB;
        public NortwindContext DB
        {
            get
            {
                if (_DB==null)
                {
                    _DB = new NortwindContext();
                }
                
                return _DB; 
            }
        }

        //IBAGLANTI DB     NC : IBAGLANTI  DUPPER : IBAGLANTI  ORACLE: IBAGLANTI       hASSET<string> LİST  =  ICOLLECTİON>STRİNG> LİST

        //DbSet<T> queryItem = null; //Customerları çağırırken DbSet üzerinden çağrıldığı için queryler bunun üstünden yürür.

        public GenericRepository()
        {
            
        }
        public virtual void Add(T item)
        {
            DB.Set<T>().Add(item);
            DB.SaveChanges();
        }

        public virtual bool Delete(T1 id)
        {
           
            var dbItem = DB.Set<T>().Find(id);
            if (dbItem != null)
            {
                DB.Set<T>().Remove(dbItem);
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual List<T> Get()
        {
            return DB.Set<T>().AsNoTracking().ToList();
        }

        public virtual T GetById(T1 id)
        {
            return DB.Set<T>().Find(id);//find komutu key değerine göre çalışır.
        }

        public virtual void Update(T item)
        {
            DB.Entry<T>(item).State = EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
