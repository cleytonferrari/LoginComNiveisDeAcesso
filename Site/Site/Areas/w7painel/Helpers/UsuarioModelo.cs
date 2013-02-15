using System.ComponentModel.DataAnnotations;

namespace Site.Areas.w7painel.Helpers
{
    public class LoginModelo
    {
        [Required(ErrorMessage = "Insira um usuário válido")]
        [Display(Name = "Nome de Usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Insira uma senha válida")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Pass { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool Relembrar { get; set; }
    }
}