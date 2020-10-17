using System.Collections.Generic;

namespace MicroService.Data.Abstract
{
    public interface IRepository<T>
    {
        string Create(T entity);
        bool Update(T entity);
        List<T> GetAll();
        T GetById(string id);
    }
}