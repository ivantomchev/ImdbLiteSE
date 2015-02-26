namespace ImdbLite.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ImdbLite.Data.Models;

    public interface IApplicationDbContext
    {

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
