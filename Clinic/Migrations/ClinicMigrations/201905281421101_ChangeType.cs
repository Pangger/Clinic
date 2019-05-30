namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "CertificationNumber", c => c.String());
            AlterColumn("dbo.Donors", "MedicalCardNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "MedicalCardNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Donors", "CertificationNumber", c => c.Int(nullable: false));
        }
    }
}
