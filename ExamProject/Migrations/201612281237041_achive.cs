namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class achive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievements", "AchvievementIconPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achievements", "AchvievementIconPath");
        }
    }
}
