namespace Corgi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeHerdId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NewsFeeds", "HerdId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsFeeds", "HerdId", c => c.Int(nullable: false));
        }
    }
}
