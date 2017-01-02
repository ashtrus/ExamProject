namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FutureFocus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyRoles", "FirstFutureFocus", c => c.String());
            AddColumn("dbo.CompanyRoles", "SecondFutureFocus", c => c.String());
            AddColumn("dbo.CompanyRoles", "ThirdFutureFocus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyRoles", "ThirdFutureFocus");
            DropColumn("dbo.CompanyRoles", "SecondFutureFocus");
            DropColumn("dbo.CompanyRoles", "FirstFutureFocus");
        }
    }
}
