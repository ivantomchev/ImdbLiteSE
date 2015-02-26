namespace ImdbLite.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using ImdbLite.Data.Models;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            PopulateGenres(context);

            context.SaveChanges();

            base.Seed(context);

            //PopulateCelebrities(context);
            //context.SaveChanges();
            //base.Seed(context);

        }

        private static void PopulateCelebrities(ApplicationDbContext context)
        {
            var celebrities = new List<Celebrity>() 
            {
                new Celebrity
                {
                    FullName = "Robert De Niro",
                    CreatedOn = DateTime.Now
                },
                new Celebrity
                {
                    FullName = "Pamela Anderson",
                    CreatedOn = DateTime.Now
                },
                new Celebrity
                {
                    FullName = "Boris Elcin",
                    CreatedOn = DateTime.Now
                },
                new Celebrity
                {
                    FullName = "Al Pacino",
                    CreatedOn = DateTime.Now
                },
            };

            celebrities.ForEach(g => context.Celebrities.AddOrUpdate(p => p.FullName, g));
        }

        private static void PopulateGenres(ApplicationDbContext context)
        {
            var genres = new List<Genre>()
            {
                new Genre {Name = "Action"},
                new Genre{Name = "Adventure"},
                new Genre{Name = "Animation"},
                new Genre{Name = "Biography"},
                new Genre{Name = "Comedy"},
                new Genre{Name = "Crime"},
                new Genre{Name = "Documentary"},
                new Genre{Name = "Drama"},
                new Genre{Name = "Family"},
                new Genre{Name = "Fantasy"},
                new Genre{Name = "FilmNoir"},
                new Genre{Name = "Horror"},
                new Genre{Name = "History"},
                new Genre{Name = "Music"},
                new Genre{Name = "Musical"},
                new Genre{Name = "Mystery"},
                new Genre{Name = "Romance"},
                new Genre{Name = "SciFi"},
                new Genre{Name = "Short"},
                new Genre{Name = "Sport"},
                new Genre{Name = "Thriller"},
                new Genre{Name = "War"},
                new Genre{Name = "Western"},
       
            };

            genres.ForEach(g => context.Genres.AddOrUpdate(p => p.Name, g));
        }
    }
}
