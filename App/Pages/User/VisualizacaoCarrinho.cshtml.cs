using App.Models;
using App.Repositories.Interfaces;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.User
{
    public class VisualizacaoCarrinhoModel : PageModel
    {
        private readonly ICarrinhoRepository carrinhoRepository;
        private readonly IProdutoRepository produtoRepository;

        public CarrinhoViewModel CarrinhoViewModel { get; set; }
        public List<Produto> Produtos { get; set; }

        public VisualizacaoCarrinhoModel(ICarrinhoRepository carrinhoRepository,
            IProdutoRepository produtoRepository)
        {
            this.carrinhoRepository = carrinhoRepository;
            this.produtoRepository = produtoRepository;

            Produtos = new List<Produto>();
        }

        public async Task OnGet(Guid usuarioId)
        {
            var carrinho = await carrinhoRepository.GetAsync(usuarioId);

            if (carrinho != null)
            {
                CarrinhoViewModel = new CarrinhoViewModel()
                {
                    Id = carrinho.Id,
                    UsuarioId = carrinho.UsuarioId,
                    ValorTotal = carrinho.ValorTotal,
                    ItensCarrinho = carrinho.ItensCarrinho
                };

                if (carrinho.ItensCarrinho.Any())
                {
                    foreach (var item in carrinho.ItensCarrinho)
                    {
                        Produtos.Add(await produtoRepository.GetAsync(item.ProdutoId));
                    }
                }
            }
        }
    }
}
