namespace ImdbLite.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ImdbLite.Data.Models;

    public interface IApplicationDbContext
    {
        IDbSet<Actor> Actors { get; set; }
        IDbSet<Director> Directors { get; set; }
        IDbSet<Genre> Genres { get; set; }
        IDbSet<Movie> Movies { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Photo> Photos { get; set; }
        IDbSet<Producer> Producers { get; set; }
        IDbSet<Writer> Writers { get; set; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
