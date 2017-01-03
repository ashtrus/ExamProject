namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoleComment1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleComments", "CompanyRole_CompanyRoleId", "dbo.CompanyRoles");
            DropIndex("dbo.RoleComments", new[] { "CompanyRole_CompanyRoleId" });
            RenameColumn(table: "dbo.RoleComments", name: "CompanyRole_CompanyRoleId", newName: "CompanyRoleId");
            AlterColumn("dbo.RoleComments", "CompanyRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.RoleComments", "CompanyRoleId");
            AddForeignKey("dbo.RoleComments", "CompanyRoleId", "dbo.CompanyRoles", "CompanyRoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleComments", "CompanyRoleId", "dbo.CompanyRoles");
            DropIndex("dbo.RoleComments", new[] { "CompanyRoleId" });
            AlterColumn("dbo.RoleComments", "CompanyRoleId", c => c.Int());
            RenameColumn(table: "dbo.RoleComments", name: "CompanyRoleId", newName: "CompanyRole_CompanyRoleId");
            CreateIndex("dbo.RoleComments", "CompanyRole_CompanyRoleId");
            AddForeignKey("dbo.RoleComments", "CompanyRole_CompanyRoleId", "dbo.CompanyRoles", "CompanyRoleId");
        }
    }
}
