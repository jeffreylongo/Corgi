namespace Corgi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class search : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoryName = c.String(),
                        Url = c.String(),
                        NewsFeedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsFeeds", t => t.NewsFeedId)
                .Index(t => t.NewsFeedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotArticles", "NewsFeedId", "dbo.NewsFeeds");
            DropIndex("dbo.HotArticles", new[] { "NewsFeedId" });
            DropTable("dbo.HotArticles");
        }
    }
}
