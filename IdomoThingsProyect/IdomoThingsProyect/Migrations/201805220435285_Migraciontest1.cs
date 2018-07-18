namespace IdomoThingsProyect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migraciontest1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accions",
                c => new
                    {
                        AccionID = c.Int(nullable: false, identity: true),
                        AccionHecha = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        HubsId = c.String(),
                        hubs_Hubsip = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AccionID)
                .ForeignKey("dbo.Hubs", t => t.hubs_Hubsip)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.hubs_Hubsip);
            
            CreateTable(
                "dbo.Hubs",
                c => new
                    {
                        Hubsip = c.String(nullable: false, maxLength: 128),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Hubsip);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accions", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Accions", "hubs_Hubsip", "dbo.Hubs");
            DropIndex("dbo.Accions", new[] { "hubs_Hubsip" });
            DropIndex("dbo.Accions", new[] { "UsuarioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Hubs");
            DropTable("dbo.Accions");
        }
    }
}
