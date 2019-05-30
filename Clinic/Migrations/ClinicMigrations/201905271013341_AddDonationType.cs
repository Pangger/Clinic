namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonationType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bloods", "DonationType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bloods", "DonationType");
        }
    }
}
