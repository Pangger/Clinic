namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bloods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        Donor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donors", t => t.Donor_Id)
                .Index(t => t.Donor_Id);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        CertificationNumber = c.Int(nullable: false),
                        BloodType = c.Int(nullable: false),
                        Rhesus = c.Int(nullable: false),
                        DateOfApplication = c.DateTime(nullable: false),
                        Adress = c.String(),
                        MedicalCardNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bloods", "Donor_Id", "dbo.Donors");
            DropIndex("dbo.Bloods", new[] { "Donor_Id" });
            DropTable("dbo.Donors");
            DropTable("dbo.Bloods");
        }
    }
}
