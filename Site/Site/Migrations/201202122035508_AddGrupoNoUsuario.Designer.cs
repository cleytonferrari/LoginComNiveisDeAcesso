// <auto-generated />
namespace Site.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class AddGrupoNoUsuario : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201202122035508_AddGrupoNoUsuario"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
