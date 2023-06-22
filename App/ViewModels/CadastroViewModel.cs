using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class CadastroViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}
