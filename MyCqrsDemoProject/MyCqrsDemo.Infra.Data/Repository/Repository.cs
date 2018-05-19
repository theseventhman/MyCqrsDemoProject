using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCqrsDemo.Domain.Interfaces;
using MyCqrsDemo.Infra.Data.Context;

namespace MyCqrsDemo.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Dispose()
        {
           Db.Dispose();
           GC.SuppressFinalize(this);
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(string id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(string id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}