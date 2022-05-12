namespace CloudBasedFingerIdentificationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departmenttbl",
                c => new
                    {
                        deptcode = c.Int(nullable: false, identity: true),
                        parentdeptcode = c.String(),
                        deptname = c.String(),
                        shortdescription = c.String(),
                        depthead = c.String(),
                        approvedsalary = c.Int(nullable: false),
                        division = c.String(),
                        salarygroup = c.String(),
                        email = c.String(),
                        leaveapprovedlevel = c.String(),
                        primaryreportsto = c.String(),
                        secondaryreportsto = c.String(),
                        employeeid = c.Int(),
                        DivisionCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.deptcode)
                .ForeignKey("dbo.Divisiontbl", t => t.DivisionCode)
                .Index(t => t.DivisionCode);
            
            CreateTable(
                "dbo.Divisiontbl",
                c => new
                    {
                        DivisionCode = c.String(nullable: false, maxLength: 128),
                        DivisionName = c.String(),
                    })
                .PrimaryKey(t => t.DivisionCode);
            
            CreateTable(
                "dbo.Designationtbl",
                c => new
                    {
                        desigcode = c.Int(nullable: false, identity: true),
                        designame = c.String(),
                        rank = c.String(),
                        Reports_to = c.String(),
                        employeeid = c.Int(),
                    })
                .PrimaryKey(t => t.desigcode);
            
            CreateTable(
                "dbo.policytbl",
                c => new
                    {
                        Policyid = c.Int(nullable: false, identity: true),
                        PolicyName = c.String(),
                    })
                .PrimaryKey(t => t.Policyid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departmenttbl", "DivisionCode", "dbo.Divisiontbl");
            DropIndex("dbo.Departmenttbl", new[] { "DivisionCode" });
            DropTable("dbo.policytbl");
            DropTable("dbo.Designationtbl");
            DropTable("dbo.Divisiontbl");
            DropTable("dbo.Departmenttbl");
        }
    }
}
