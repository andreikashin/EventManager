using System.Collections.Generic;
using EventManager.Models;

namespace EventManager.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Locations.AddOrUpdate(
                l => l.Id,
                new Location {Address = "Street 1", Capacity = 10},
                new Location {Address = "Street 2", Capacity = 20},
                new Location {Address = "Street 3", Capacity = 30}
            );
        }
    }
}
