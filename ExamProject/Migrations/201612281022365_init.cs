namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        Company_CompanyId = c.Int(),
                        CompanyRole_CompanyRoleId = c.Int(),
                    })
                .PrimaryKey(t => t.AchievementId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.CompanyRoles", t => t.CompanyRole_CompanyRoleId)
                .Index(t => t.Company_CompanyId)
                .Index(t => t.CompanyRole_CompanyRoleId);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                        CompanyId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Skill_SkillId = c.Int(),
                        Company_CompanyId = c.Int(),
                        Company_CompanyId1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId1)
                .Index(t => t.CompanyId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Skill_SkillId)
                .Index(t => t.Company_CompanyId)
                .Index(t => t.Company_CompanyId1);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CompanyRoles",
                c => new
                    {
                        CompanyRoleId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        SelectedOn = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyRoleId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.CompanyId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CompanyRole_CompanyRoleId = c.Int(),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.CompanyRoles", t => t.CompanyRole_CompanyRoleId)
                .Index(t => t.CompanyRole_CompanyRoleId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.SkillExperiences",
                c => new
                    {
                        SkillExperienceId = c.Int(nullable: false, identity: true),
                        SkillId = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SkillExperienceId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.SkillId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Picture = c.String(),
                        Skill_SkillId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId)
                .Index(t => t.Skill_SkillId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId1", "dbo.Companies");
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.SkillExperiences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillExperiences", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillExperiences", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.CompanyRoles", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Skills", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompanyRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tags", "CompanyRole_CompanyRoleId", "dbo.CompanyRoles");
            DropForeignKey("dbo.CompanyRoles", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Achievements", "CompanyRole_CompanyRoleId", "dbo.CompanyRoles");
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Achievements", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Employees", new[] { "Skill_SkillId" });
            DropIndex("dbo.SkillExperiences", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SkillExperiences", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.SkillExperiences", new[] { "SkillId" });
            DropIndex("dbo.Skills", new[] { "CompanyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Tags", new[] { "CompanyRole_CompanyRoleId" });
            DropIndex("dbo.CompanyRoles", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.CompanyRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CompanyRoles", new[] { "CompanyId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId1" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId" });
            DropIndex("dbo.AspNetUsers", new[] { "Skill_SkillId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropIndex("dbo.Achievements", new[] { "CompanyRole_CompanyRoleId" });
            DropIndex("dbo.Achievements", new[] { "Company_CompanyId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Employees");
            DropTable("dbo.SkillExperiences");
            DropTable("dbo.Skills");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Tags");
            DropTable("dbo.CompanyRoles");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Companies");
            DropTable("dbo.Achievements");
        }
    }
}
