namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        AchievementId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.AchievementId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Picture = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .Index(t => t.Company_CompanyId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Experience = c.Int(nullable: false),
                        SelectedOn = c.DateTime(nullable: false),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .Index(t => t.Company_CompanyId);
            
            CreateTable(
                "dbo.SkillEmployees",
                c => new
                    {
                        Skill_SkillId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_SkillId, t.Employee_EmployeeId })
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Skill_SkillId)
                .Index(t => t.Employee_EmployeeId);
            
            AddColumn("dbo.Tags", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.Tags", "Role_RoleId");
            AddForeignKey("dbo.Tags", "Role_RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Tags", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Achievements", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Employees", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.SkillEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SkillEmployees", "Skill_SkillId", "dbo.Skills");
            DropIndex("dbo.SkillEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.SkillEmployees", new[] { "Skill_SkillId" });
            DropIndex("dbo.Tags", new[] { "Role_RoleId" });
            DropIndex("dbo.Roles", new[] { "Company_CompanyId" });
            DropIndex("dbo.Employees", new[] { "Company_CompanyId" });
            DropIndex("dbo.Achievements", new[] { "Role_RoleId" });
            DropColumn("dbo.Tags", "Role_RoleId");
            DropTable("dbo.SkillEmployees");
            DropTable("dbo.Roles");
            DropTable("dbo.Skills");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
            DropTable("dbo.Achievements");
        }
    }
}
