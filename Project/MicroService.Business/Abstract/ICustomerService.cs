using System.Collections.Generic;
using MicroService.Entities;

namespace MicroService.Business.Abstract
{
    public interface ICustomerService
    {
        string Create(Customers entity);
        bool Update(Customers entity);
        List<Customers> GetAll();
        Customers GetById(string id);

        bool Delete(string id);
        bool validate(string key);
    }
}