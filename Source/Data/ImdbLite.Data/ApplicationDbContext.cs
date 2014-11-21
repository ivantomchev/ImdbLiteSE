namespace ImdbLite.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
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
    
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual IDbSet<Movie> Movies { get; set; }
             
        public virtual IDbSet<MoviesComment> MoviesComments { get; set; }
             
        public virtual IDbSet<MoviesPhoto> MoviesPhotos { get; set; }
              
        public virtual IDbSet<Actor> Actors { get; set; }
             
        public virtual IDbSet<ActorsComment> ActorsComments { get; set; }
           
        public virtual IDbSet<ActorsPhoto> ActorsPhotos { get; set; }
               
        public virtual IDbSet<Director> Directors { get; set; }
            
        public virtual IDbSet<DirectorsComment> DirectorsComments { get; set; }
            
        public virtual IDbSet<DirectorsPhoto> DirectorsPhotos { get; set; }
          
        public virtual IDbSet<Producer> Producers { get; set; }
            
        public virtual IDbSet<ProducersComment> ProducersComments { get; set; }
       
        public virtual IDbSet<ProducersPhoto> ProducersPhotos { get; set; }
           
        public virtual IDbSet<Writer> Writers { get; set; }
             
        public virtual IDbSet<WritersComment> WritersComments { get; set; }
          
        public virtual IDbSet<WritersPhoto> WritersPhotos { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        

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


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
