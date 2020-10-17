using System.Collections.Generic;
using MicroService.Entities;

namespace MicroService.Business.Abstract
{
    public interface IOrderService
    {
        string Create(Orders entity);
        bool Update(Orders entity);
        List<Orders> GetAll();
        Orders GetById(string id);

        bool Delete(string id);
        List<Orders> GetByCustomer(string userid);
        bool changeStatus(string key1, string key2);
    }
}