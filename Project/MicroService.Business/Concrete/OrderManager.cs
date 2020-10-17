using System.Collections.Generic;
using MicroService.Business.Abstract;
using MicroService.Data.Abstract;
using MicroService.Entities;

namespace MicroService.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderRepository _orderRepo;
        public OrderManager(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public bool changeStatus(string key1, string key2)
        {
            return _orderRepo.changeStatus(key1,key2);
        }

        public string Create(Orders entity)
        {
            return _orderRepo.Create(entity);
        }

        public bool Delete(string id)
        {
            return _orderRepo.Delete(id);
        }

        public List<Orders> GetByCustomer(string userid)
        {
            return _orderRepo.GetByCustomer(userid);
        }


        public bool Update(Orders entity)
        {
            return _orderRepo.Update(entity);
        }

        public List<Orders> GetAll()
        {
            return _orderRepo.GetAll();        }

        public Orders GetById(string id)
        {
            return _orderRepo.GetById(id);
        }
    }
}