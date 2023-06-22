using App.Enums;
using App.Models;
using App.Repositories.Interfaces;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages.Default
{
    public class ItemCatalogoModel : PageModel
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly ICarrinhoRepository carrinhoRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public ItemCatalogoViewModel ItemCatalogoViewModel { get; set; }
        public Produto Produto { get; set; }
        public List<Produto> ProdutosRelacionados { get; set; }

        public ItemCatalogoModel(IProdutoRepository produtoRepository,
            ICarrinhoRepository carrinhoRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.produtoRepository = produtoRepository;
            this.carrinhoRepository = carrinhoRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task OnGet(Guid id)
        {
            Produto = await produtoRepository.GetAsync(id);
            ProdutosRelacionados = (await produtoRepository.GetAllAsync(Produto.Categoria)).ToList();
        }

        public async Task OnPostReservar()
        {
            if (signInManager.IsSignedIn(User))
            {
                var usuarioId = new Guid(userManager.GetUserId(User));
                var carrinho = await carrinhoRepository.GetAsync(usuarioId);

                if (carrinho == null)
                {
                    carrinho = new Carrinho()
                    {
                        UsuarioId = usuarioId
                    };

                    await carrinhoRepository.AddAsync(carrinho);

                    if (carrinho.Id != Guid.Empty)
                    {
                        var itemCarrinho = new ItemCarrinho()
                        {
                            CarrinhoId = carrinho.Id,
                            ProdutoId = ItemCatalogoViewModel.ProdutoId,
                            Quantidade = ItemCatalogoViewModel.Quantidade,
                            Valor = (ItemCatalogoViewModel.ValorTotal * 0.15m)
                        };

                        carrinho.ItensCarrinho.Add(itemCarrinho);
                        await carrinhoRepository.UpdateAsync(carrinho);
                    }
                }
                else
                {
                    var itemCarrinho = new ItemCarrinho()
                    {
                        CarrinhoId = carrinho.Id,
                        ProdutoId = ItemCatalogoViewModel.ProdutoId,
                        Quantidade = ItemCatalogoViewModel.Quantidade,
                        Valor = (ItemCatalogoViewModel.ValorTotal * 0.15m)
                    };

                    carrinho.ItensCarrinho.Add(itemCarrinho);
                    await carrinhoRepository.UpdateAsync(carrinho);
                }

                RedirectToPage($"/default/itemcatalogo/{ItemCatalogoViewModel.ProdutoId}");
            }
            else
            {
                RedirectToPage("/default/login");
            }
        }

        private void SetTempData(TipoNotificacao tipoNotificacao, string mensagem)
        {
            var notificacao = new NotificacaoViewModel
            {
                Tipo = tipoNotificacao,
                Mensagem = mensagem
            };

            TempData["Notificacao"] = JsonSerializer.Serialize(notificacao);
        }

        private void SetViewData(TipoNotificacao tipoNotificacao, string mensagem)
        {
            var notificacao = new NotificacaoViewModel
            {
                Tipo = tipoNotificacao,
                Mensagem = mensagem
            };

            ViewData["Notificacao"] = notificacao;
        }
    }
}
