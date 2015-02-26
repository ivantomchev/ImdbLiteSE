namespace ImdbLite.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models;

    public interface IImdbLiteData
    {
        IApplicationDbContext Context { get; }

        IDeletableEntityRepository<User> Users { get; }

        IDeletableEntityRepository<Celebrity> Celebrities { get; }

        IDeletableEntityRepository<Movie> Movies { get; }

        IDeletableEntityRepository<Character> Characters { get; }

        IDeletableEntityRepository<CastMember> CastMembers { get; }

        IRepository<CelebrityMainPhoto> CelebrityMainPhotos { get; }

        IRepository<MoviePoster> MoviePosters { get; }

        IRepository<Genre> Genres { get; }

        int SaveChanges();
    }
}
