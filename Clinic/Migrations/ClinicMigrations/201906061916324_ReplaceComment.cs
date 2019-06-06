namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donors", "Comment", c => c.String());
            DropColumn("dbo.Bloods", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bloods", "Comment", c => c.String());
            DropColumn("dbo.Donors", "Comment");
        }
    }
}
