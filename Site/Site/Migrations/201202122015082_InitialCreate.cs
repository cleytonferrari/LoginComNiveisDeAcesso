namespace Site.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Grupoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Permissaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Chave = c.String(),
                        Plugin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Plugins", t => t.Plugin_Id)
                .Index(t => t.Plugin_Id);
            
            CreateTable(
                "Plugins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Versao = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "HistoricoLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Login = c.String(),
                        Pass = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PermissaoGrupoes",
                c => new
                    {
                        Permissao_Id = c.Int(nullable: false),
                        Grupo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Permissao_Id, t.Grupo_Id })
                .ForeignKey("Permissaos", t => t.Permissao_Id, cascadeDelete: true)
                .ForeignKey("Grupoes", t => t.Grupo_Id, cascadeDelete: true)
                .Index(t => t.Permissao_Id)
                .Index(t => t.Grupo_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("PermissaoGrupoes", new[] { "Grupo_Id" });
            DropIndex("PermissaoGrupoes", new[] { "Permissao_Id" });
            DropIndex("HistoricoLogins", new[] { "Usuario_Id" });
            DropIndex("Permissaos", new[] { "Plugin_Id" });
            DropForeignKey("PermissaoGrupoes", "Grupo_Id", "Grupoes");
            DropForeignKey("PermissaoGrupoes", "Permissao_Id", "Permissaos");
            DropForeignKey("HistoricoLogins", "Usuario_Id", "Usuarios");
            DropForeignKey("Permissaos", "Plugin_Id", "Plugins");
            DropTable("PermissaoGrupoes");
            DropTable("Usuarios");
            DropTable("HistoricoLogins");
            DropTable("Plugins");
            DropTable("Permissaos");
            DropTable("Grupoes");
        }
    }
}
