namespace CamelDev.Musicas.DAO.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CamelDev_Music",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        YEAR = c.Int(nullable: false),
                        TITLE = c.String(nullable: false),
                        DESCRIPTION = c.String(maxLength: 500),
                        EMAIL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CamelDev_Music");
        }
    }
}
