using System.Collections.Generic;
using MicroService.Entities;

namespace MicroService.Data.Abstract
{
    public interface IOrderRepository : IRepository<Orders>
    {
        bool Delete(string id);
        List<Orders> GetByCustomer(string userid);
        bool changeStatus(string key1, string key2);

    }
}