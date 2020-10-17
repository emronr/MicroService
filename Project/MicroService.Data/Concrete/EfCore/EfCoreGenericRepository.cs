using System.Collections.Generic;
using MicroService.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace MicroService.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public string Create(T entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Add(entity);
                    context.SaveChanges();


                    return "created";
                }
            }
            catch(Exception)
            {
                return "error";
            }


        }

        public List<T> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(string id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public bool Update(T entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
