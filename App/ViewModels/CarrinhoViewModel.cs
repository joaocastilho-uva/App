using App.Models;

namespace App.ViewModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel()
        {
            this.ItensCarrinho = new List<ItemCarrinho>();
        }

        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal ValorTotal { get; set; }
        public ICollection<ItemCarrinho> ItensCarrinho { get; set; }
    }
}
