namespace CamelDev.Musicas.DAO.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMusicInProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MUSIC",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NAME = c.String(nullable: false, maxLength: 100),
                        LYRICS = c.String(),
                        ALB_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ALBUM", t => t.ALB_ID, cascadeDelete: true)
                .Index(t => t.ALB_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MUSIC", "ALB_ID", "dbo.ALBUM");
            DropIndex("dbo.MUSIC", new[] { "ALB_ID" });
            DropTable("dbo.MUSIC");
        }
    }
}
