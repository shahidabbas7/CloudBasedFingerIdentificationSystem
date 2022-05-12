namespace CloudBasedFingerIdentificationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.hosteltbl", "HostelName", c => c.String());
            AlterColumn("dbo.hosteltbl", "Warden", c => c.String());
            AlterColumn("dbo.hosteltbl", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.hosteltbl", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.hosteltbl", "Warden", c => c.Int(nullable: false));
            AlterColumn("dbo.hosteltbl", "HostelName", c => c.Int(nullable: false));
        }
    }
}
