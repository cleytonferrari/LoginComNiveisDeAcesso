namespace Site.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddGrupoNoUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("Usuarios", "Grupo_Id", c => c.Int());
            AddForeignKey("Usuarios", "Grupo_Id", "Grupoes", "Id");
            CreateIndex("Usuarios", "Grupo_Id");
        }
        
        public override void Down()
        {
            DropIndex("Usuarios", new[] { "Grupo_Id" });
            DropForeignKey("Usuarios", "Grupo_Id", "Grupoes");
            DropColumn("Usuarios", "Grupo_Id");
        }
    }
}
