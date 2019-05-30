namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonorIdToBlood : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bloods", name: "Donor_Id", newName: "DonorId");
            RenameIndex(table: "dbo.Bloods", name: "IX_Donor_Id", newName: "IX_DonorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Bloods", name: "IX_DonorId", newName: "IX_Donor_Id");
            RenameColumn(table: "dbo.Bloods", name: "DonorId", newName: "Donor_Id");
        }
    }
}
