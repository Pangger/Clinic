namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ClinicConfig : DbMigrationsConfiguration<Clinic.Models.ClinicContext>
    {
        public ClinicConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ClinicMigrations";
        }

        protected override void Seed(Clinic.Models.ClinicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
