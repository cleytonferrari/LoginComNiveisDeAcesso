using System.Data.Entity;
using Site.Areas.w7painel.Models;

namespace Site.Models
{
    public class SiteContext: DbContext
    {
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<HistoricoLogin> HistoricoLogins { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Plugin> Plugins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}