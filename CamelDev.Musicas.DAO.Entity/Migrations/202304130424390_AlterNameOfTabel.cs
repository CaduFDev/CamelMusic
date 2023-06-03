namespace CamelDev.Musicas.DAO.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterNameOfTabel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CamelDev_Music", newName: "ALBUM");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ALBUM", newName: "CamelDev_Music");
        }
    }
}
