using System;

namespace PagueVeloz.Teste.Domain
{
    public interface IRepository<TEntity> : IDisposable where TEntity : AgregateRoot
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}