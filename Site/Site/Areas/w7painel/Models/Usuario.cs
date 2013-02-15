using System.ComponentModel.DataAnnotations;

namespace Site.Areas.w7painel.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }

        public Grupo Grupo { get; set; }
    }
}