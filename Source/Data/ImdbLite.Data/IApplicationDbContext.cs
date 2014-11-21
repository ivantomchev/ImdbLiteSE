namespace ImdbLite.Data
{
    using ImdbLite.Data.Models.Actor;
    using ImdbLite.Data.Models.Director;
    using ImdbLite.Data.Models.Genre;
    using ImdbLite.Data.Models.Movie;
    using ImdbLite.Data.Models.Producer;
    using ImdbLite.Data.Models.Writer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext
    {
        IDbSet<Actor> Actors { get; set; }
        IDbSet<ActorsComment> ActorsComments { get; set; }
        IDbSet<ActorsPhoto> ActorsPhotos { get; set; }
        IDbSet<Director> Directors { get; set; }
        IDbSet<DirectorsComment> DirectorsComments { get; set; }
        IDbSet<DirectorsPhoto> DirectorsPhotos { get; set; }
        IDbSet<Genre> Genres { get; set; }
        IDbSet<Movie> Movies { get; set; }
        IDbSet<MoviesComment> MoviesComments { get; set; }
        IDbSet<MoviesPhoto> MoviesPhotos { get; set; }
        IDbSet<Producer> Producers { get; set; }
        IDbSet<ProducersComment> ProducersComments { get; set; }
        IDbSet<ProducersPhoto> ProducersPhotos { get; set; }       
        IDbSet<Writer> Writers { get; set; }
        IDbSet<WritersComment> WritersComments { get; set; }
        IDbSet<WritersPhoto> WritersPhotos { get; set; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
