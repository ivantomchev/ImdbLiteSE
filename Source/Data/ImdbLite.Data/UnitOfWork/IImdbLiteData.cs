namespace ImdbLite.Data.UnitOfWork
{
    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models.Actor;
    using ImdbLite.Data.Models.Director;
    using ImdbLite.Data.Models.Genre;
    using ImdbLite.Data.Models.Producer;
    using ImdbLite.Data.Models.User;
    using ImdbLite.Data.Models.Writer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IImdbLiteData
    {
        IApplicationDbContext Context { get; }

        IDeletableEntityRepository<User> Users { get; }

        IDeletableEntityRepository<Genre> Genres { get; }

        IDeletableEntityRepository<Actor> Actors { get; }

        IDeletableEntityRepository<Director> Directors { get; }

        IDeletableEntityRepository<Producer> Producers { get; }

        IDeletableEntityRepository<Writer> Writers { get; }

        int SaveChanges();
    }
}
