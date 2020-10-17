using System.Collections.Generic;
using MicroService.Business.Abstract;
using MicroService.Entities;
using MicroService.Data.Abstract;

namespace MicroService.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerRepository _customerRepo;
        public CustomerManager(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public string Create(Customers entity)
        {
            return _customerRepo.Create(entity);
        }

        public bool Delete(string id)
        {
            return _customerRepo.Delete(id);
        }

        public List<Customers> GetAll()
        {
            return _customerRepo.GetAll();
        }

        public Customers GetById(string id)
        {
            return _customerRepo.GetById(id);
        }

        public bool Update(Customers entity)
        {
           return _customerRepo.Update(entity);
        }

        public bool validate(string key)
        {
            return _customerRepo.validate(key);
        }
    }
}