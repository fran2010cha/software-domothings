namespace IdomoThingsProyect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migraciontest4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Accions", new[] { "HubsId" });
            CreateIndex("dbo.Accions", "HubsID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accions", new[] { "HubsID" });
            CreateIndex("dbo.Accions", "HubsId");
        }
    }
}
