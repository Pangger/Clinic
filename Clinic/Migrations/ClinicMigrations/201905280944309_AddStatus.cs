namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bloods", "BloodStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Donors", "DonorStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donors", "DonorStatus");
            DropColumn("dbo.Bloods", "BloodStatus");
        }
    }
}
