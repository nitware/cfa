namespace CFA.Data.Core.Migrations
{
    using Setup;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CFA.Data.Core.CFAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Core\Migrations";
        }

        protected override void Seed(CFAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Roles.AddOrUpdate(role => role.Name,
            //    new Role { Key = Guid.NewGuid(), Name = "Admin" },
            //    new Role { Key = Guid.NewGuid(), Name = "Employee" },
            //    new Role { Key = Guid.NewGuid(), Name = "Affiliate" }
            //    );


            DataSeeder.SeedData(context);

        }
    }
}
