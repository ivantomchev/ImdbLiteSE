namespace ImdbLite.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using ImdbLite.Data.Models.Genre;

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
        }

        private static void PopulateGenres(ApplicationDbContext context)
        {
            var genres = new List<Genre>()
            {
                new Genre 
                {
                    Type = "Action"
                },
                new Genre
                {
                    Type = "Adventure"
                },
                new Genre
                {
                    Type = "Animation"
                },
                new Genre
                {
                    Type = "Biography"
                },
                new Genre
                {
                    Type = "Comedy"
                },
                new Genre
                {
                    Type = "Crime"
                },
                new Genre
                {
                    Type = "Documentary"
                },
                new Genre 
                {
                    Type = "Drama"
                },
                new Genre
                {
                    Type = "Family"
                },
                new Genre
                {
                    Type = "Fantasy"
                },
                new Genre
                {
                    Type = "FilmNoir"
                },
                new Genre
                {
                    Type = "Horror"
                },
                new Genre
                {
                    Type = "History"
                },
                new Genre
                {
                    Type = "Music"
                },
                new Genre 
                {
                    Type = "Musical"
                },
                new Genre
                {
                    Type = "Mystery"
                },
                new Genre
                {
                    Type = "Romance"
                },
                new Genre
                {
                    Type = "SciFi"
                },
                new Genre
                {
                    Type = "Short"
                },
                new Genre
                {
                    Type = "Sport"
                },
                new Genre
                {
                    Type = "Thriller"
                },
                new Genre
                {
                    Type = "War"
                },
                new Genre
                {
                    Type = "Western"
                },      
            };

            genres.ForEach(g => context.Genres.AddOrUpdate(p => p.Type, g));
        }
    }
}
