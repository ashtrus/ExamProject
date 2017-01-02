namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCExp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SkillExperiences", "SkillCompanyExperience", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SkillExperiences", "SkillCompanyExperience");
        }
    }
}
