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

        IDeletableEntityRepository<Genre> Genres { get; }

        IDeletableEntityRepository<Actor> Actors { get; }

        IDeletableEntityRepository<Director> Directors { get; }

        IDeletableEntityRepository<Producer> Producers { get; }

        IDeletableEntityRepository<Writer> Writers { get; }

        int SaveChanges();
    }
}
