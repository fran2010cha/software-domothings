namespace IdomoThingsProyect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migraciontest2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accions", "hubs_Hubsip", "dbo.Hubs");
            DropIndex("dbo.Accions", new[] { "hubs_Hubsip" });
            DropColumn("dbo.Accions", "HubsId");
            RenameColumn(table: "dbo.Accions", name: "hubs_Hubsip", newName: "HubsId");
            DropPrimaryKey("dbo.Hubs");
            AddColumn("dbo.Hubs", "HubsId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Accions", "HubsId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Hubs", "HubsId");
            CreateIndex("dbo.Accions", "HubsId");
            AddForeignKey("dbo.Accions", "HubsId", "dbo.Hubs", "HubsId");
            DropColumn("dbo.Hubs", "Hubsip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hubs", "Hubsip", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Accions", "HubsId", "dbo.Hubs");
            DropIndex("dbo.Accions", new[] { "HubsId" });
            DropPrimaryKey("dbo.Hubs");
            AlterColumn("dbo.Accions", "HubsId", c => c.String());
            DropColumn("dbo.Hubs", "HubsId");
            AddPrimaryKey("dbo.Hubs", "Hubsip");
            RenameColumn(table: "dbo.Accions", name: "HubsId", newName: "hubs_Hubsip");
            AddColumn("dbo.Accions", "HubsId", c => c.String());
            CreateIndex("dbo.Accions", "hubs_Hubsip");
            AddForeignKey("dbo.Accions", "hubs_Hubsip", "dbo.Hubs", "Hubsip");
        }
    }
}
