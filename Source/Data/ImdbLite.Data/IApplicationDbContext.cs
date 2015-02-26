namespace ImdbLite.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ImdbLite.Data.Models;

    public interface IApplicationDbContext
    {
        IDbSet<Celebrity> Celebrities { get; set; }

        IDbSet<Movie> Movies { get; set; }

        IDbSet<Genre> Genres { get; set; }

        IDbSet<Character> Characters { get; set; }

        IDbSet<CastMember> CastMembers { get; set; }

        IDbSet<CelebrityMainPhoto> CelebrityMainPhotos { get; set; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
