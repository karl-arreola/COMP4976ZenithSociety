namespace ZenithWebsite.Migrations.ZenithMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "ActivityDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "ActivityDescription", c => c.String());
        }
    }
}
