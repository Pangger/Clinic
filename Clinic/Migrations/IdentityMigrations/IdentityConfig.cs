namespace Clinic.Migrations.IdentityMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class IdentityConfig : DbMigrationsConfiguration<Clinic.Models.ApplicationDbContext>
    {
        public IdentityConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityMigrations";
            ContextKey = "Clinic.Models.ApplicationDbContext";
        }

        protected override void Seed(Clinic.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
