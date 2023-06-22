using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class Stand
    {
        public Stand()
        {
            this.Produtos = new List<Produto>();
            this.Usuarios = new List<IdentityUser>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Localizacao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<IdentityUser> Usuarios { get; set; }
        public ICollection<ItemReserva> ItensReserva { get; set; }
    }
}
