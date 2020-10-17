using System;
using System.Collections.Generic;
using System.Linq;
using MicroService.Data.Abstract;
using MicroService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Data.Concrete.EfCore
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Orders, ShopContext>, IOrderRepository
    {
        public bool changeStatus(string key1, string key2)
        {
            try
            {
                using (var context = new ShopContext())
                {
                    var item = context.Orders.Where(i => i.Id == key1).FirstOrDefault();
                    item.Status = key2;
                    item.UpdatedAt = DateTime.Now;
                    context.Entry(item).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                using (var context = new ShopContext())
                {
                    var item = context.Orders.Find(id);
                    context.Orders.Remove(item);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }


        public List<Orders> GetByCustomer(string userid)
        {
            using (var context = new ShopContext())
            {
                var items = context.Orders.Where(x => x.CustomerId == userid).ToList();
                return items;
            }
        }
    }
}