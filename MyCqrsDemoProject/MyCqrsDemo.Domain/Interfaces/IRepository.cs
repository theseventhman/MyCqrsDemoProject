using System;
using System.Linq;

namespace MyCqrsDemo.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(string id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(string id);

        int SaveChanges();
    }
}