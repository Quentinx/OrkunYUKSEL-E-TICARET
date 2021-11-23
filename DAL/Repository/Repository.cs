using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Repository
{
    public class Repository<T> : Controller where T : class, new()
    {
        protected VTOrkunProje db = new VTOrkunProje();
        public List<T> GetList()
        {
            var list = db.Set<T>().ToList();
            return list;
        }

        public List<A> GetList<A>() where A : class, new()
        {
            return db.Set<A>().ToList();
        }

        public List<A> GetWhere<A>(Func<A, bool> metot) where A : class, new()
        {
            return db.Set<A>().Where(metot).ToList();
        }

        public bool Add(T model)
        {
            try
            {
                db.Set<T>().Add(model);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T GetLastItem()
        {
            return db.Set<T>().ToList().LastOrDefault(); 
        }

        public bool Add<A>(A model) where A : class, new()
        {
            try
            {
                db.Set<A>().Add(model);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(T model)
        {
            try
            {
                db.Set<T>().Remove(model);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T GetById(Func<T, bool> metot)
        {
            return db.Set<T>().FirstOrDefault(metot);
        }
        public A GetById<A>(Func<A, bool> metot) where A : class, new()
        {
            return db.Set<A>().FirstOrDefault(metot);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
