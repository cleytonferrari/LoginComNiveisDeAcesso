using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Site.Areas.w7painel.Models
{
    public class Plugin
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Versao { get; set; }
        public string Descricao { get; set; }

        public ICollection<Permissao> Permissoes { get; set; }
    }
}