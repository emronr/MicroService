using System;
using MicroService.Data.Abstract;
using MicroService.Entities;

namespace MicroService.Data.Concrete.EfCore
{
    public class EfCoreCustomerRepository : EfCoreGenericRepository<Customers, ShopContext>, ICustomerRepository
    {
        public bool Delete(string id)
        {
            try
            {
                using (var context = new ShopContext())
                {
                    var item = context.Customers.Find(id);
                    context.Customers.Remove(item);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool validate(string key)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(key);
                return addr.Address == key;
            }
            catch
            {
                return false;
            }
        }
    }
}
