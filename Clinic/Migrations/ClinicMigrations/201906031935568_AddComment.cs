namespace Clinic.Migrations.ClinicMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bloods", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bloods", "Comment");
        }
    }
}
