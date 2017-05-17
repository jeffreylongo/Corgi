namespace Corgi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Article : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoryName = c.String(),
                        Url = c.String(),
                        NewsFeedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsFeeds", t => t.NewsFeedId, cascadeDelete: true)
                .Index(t => t.NewsFeedId);
            
            DropColumn("dbo.NewsFeeds", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsFeeds", "Url", c => c.String());
            DropForeignKey("dbo.Articles", "NewsFeedId", "dbo.NewsFeeds");
            DropIndex("dbo.Articles", new[] { "NewsFeedId" });
            DropTable("dbo.Articles");
        }
    }
}
