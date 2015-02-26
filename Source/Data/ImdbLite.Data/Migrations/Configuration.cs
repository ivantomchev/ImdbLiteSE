namespace ImdbLite.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using ImdbLite.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //PopulateGenres(context);

            //context.SaveChanges();

            //base.Seed(context);
        }
    }
}
