using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MyWebApplication.DAL
{
    public class DBRepository<T> : IDBRepository<T> where T : class
    {

        private MyWebApplicationDBEntities context;

        public DBRepository(IDBEntities context)
        {
            this.context = (MyWebApplicationDBEntities)context;
        }

        public virtual T Get(int id)
        {
            try
            {
                return context.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return context.Set<T>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public T FindSingle(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {
                T query = context.Set<T>().SingleOrDefault(predicate);
                return query;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> query = context.Set<T>().Where(predicate);
                return query;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public int Add(T t)
        {
            try
            {
                context.Set<T>().Add(t);
                return context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string error = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        error += String.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage) + "<br>";
                    }
                }

                Debug.WriteLine(e.Message + "\n" + error);
                return 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\n" + e.StackTrace);
                return 0;
            }
        }

        public bool Update(T t, object key)
        {
            try
            {
                if (t == null)
                    return false;
                T exist = context.Set<T>().Find(key);
                if (exist != null)
                {
                    context.Entry(exist).CurrentValues.SetValues(t);
                    context.SaveChanges();
                }
                return true;
            }
            catch (DbEntityValidationException e)
            {
                string error = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        error += String.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage) + "<br>";
                    }
                }

                Debug.WriteLine(e.Message + "\n" + error);
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            return true;
        }

        public bool Delete(object key)
        {
            try
            {
                T exist = context.Set<T>().Find(key);
                if (exist != null)
                {
                    context.Entry(exist).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\n" + e.StackTrace);
                return false;
            }
        }
    }
}