namespace ImdbLite.Data
{
    using ImdbLite.Data.Common.Models;
    using ImdbLite.Data.Migrations;
    using ImdbLite.Data.Models.Actor;
    using ImdbLite.Data.Models.Director;
    using ImdbLite.Data.Models.Genre;
    using ImdbLite.Data.Models.Movie;
    using ImdbLite.Data.Models.Producer;
    using ImdbLite.Data.Models.User;
    using ImdbLite.Data.Models.Writer;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<MoviesComment> MoviesComments { get; set; }

        public IDbSet<MoviesPhoto> MoviesPhotos { get; set; }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<ActorsComment> ActorsComments { get; set; }

        public IDbSet<ActorsPhoto> ActorsPhotos { get; set; }

        public IDbSet<Director> Directors { get; set; }

        public IDbSet<DirectorsComment> DirectorsComments { get; set; }

        public IDbSet<DirectorsPhoto> DirectorsPhotos { get; set; }

        public IDbSet<Producer> Producers { get; set; }

        public IDbSet<ProducersComment> ProducersComments { get; set; }

        public IDbSet<ProducersPhoto> ProducersPhotos { get; set; }

        public IDbSet<Writer> Writers { get; set; }

        public IDbSet<WritersComment> WritersComments { get; set; }

        public IDbSet<WritersPhoto> WritersPhotos { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
