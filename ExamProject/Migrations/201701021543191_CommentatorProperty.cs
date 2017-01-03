namespace ExamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentatorProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoleComments", "Commentator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoleComments", "Commentator");
        }
    }
}
