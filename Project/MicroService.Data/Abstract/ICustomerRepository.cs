using MicroService.Entities;

namespace MicroService.Data.Abstract
{
    public interface ICustomerRepository : IRepository<Customers>
    {
        bool Delete(string id);
        bool validate(string key);
    }
}