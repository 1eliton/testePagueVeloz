using System;
using Microsoft.EntityFrameworkCore;
using PagueVeloz.Teste.Domain;

namespace PagueVeloz.Teste.Infra.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : AgregateRoot
    {
        protected readonly PagueVelozContext Db;
        protected readonly DbSet<TEntity> Set;

        public Repository(PagueVelozContext context)
        {
            Db = context;
            Set = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            Set.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return Set.Find(id);
        }


        public virtual void Update(TEntity obj)
        {
            Set.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            Set.Remove(Set.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}