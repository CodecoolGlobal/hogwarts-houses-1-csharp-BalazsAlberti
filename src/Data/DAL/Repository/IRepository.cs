using System.Collections.Generic;
using HogwartsHouses.Models;

namespace HogwartsHouses.Data.DAL.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> ReadAll();
        void Create(T entity);
        T ReadById(int id);
        void Delete(int id);
        void Update(T entity);
    }
}
