using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Site.Areas.w7painel.Models
{
    public class Permissao
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Chave { get; set; }
        public Plugin Plugin { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }

    }
}