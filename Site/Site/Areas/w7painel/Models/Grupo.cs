using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Site.Areas.w7painel.Models
{
    public class Grupo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public  ICollection<Permissao> Permissoes { get; set; }
    }
}