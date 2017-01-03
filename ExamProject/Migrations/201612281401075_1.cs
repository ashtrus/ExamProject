namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleComments",
                c => new
                    {
                        RoleCommentId = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        CompanyRole_CompanyRoleId = c.Int(),
                    })
                .PrimaryKey(t => t.RoleCommentId)
                .ForeignKey("dbo.CompanyRoles", t => t.CompanyRole_CompanyRoleId)
                .Index(t => t.CompanyRole_CompanyRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleComments", "CompanyRole_CompanyRoleId", "dbo.CompanyRoles");
            DropIndex("dbo.RoleComments", new[] { "CompanyRole_CompanyRoleId" });
            DropTable("dbo.RoleComments");
        }
    }
}
