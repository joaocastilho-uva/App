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
    public class CatalogoModel : PageModel
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly ICarrinhoRepository carrinhoRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public List<Produto> Produtos { get; set; }
        [BindProperty]
        public Categoria Categoria { get; set; }

        public CatalogoModel(IProdutoRepository produtoRepository,
            ICarrinhoRepository carrinhoRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            this.produtoRepository = produtoRepository;
            this.carrinhoRepository = carrinhoRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnGet(Categoria categoria)
        {
            Categoria = categoria;
            Produtos = (await produtoRepository.GetAllAsync(categoria)).ToList();

            if (!Produtos.Any())
            {
                SetViewData(TipoNotificacao.Erro, "Nenhum produto encontrado.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCarrinho(Guid produtoId)
        {
            try
            {
                if (signInManager.IsSignedIn(User))
                {
                    var produto = await produtoRepository.GetAsync(produtoId);

                    if (produto != null && produto.Id != Guid.Empty)
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

                            if (carrinho != null && carrinho.Id != Guid.Empty)
                            {
                                var itemCarrinho = new ItemCarrinho()
                                {
                                    CarrinhoId = carrinho.Id,
                                    ProdutoId = produto.Id,
                                    Quantidade = 1,
                                    Valor = (produto.ValorAtual * 0.15m)
                                };

                                carrinho.ValorTotal += itemCarrinho.Valor;
                                carrinho.ItensCarrinho.Add(itemCarrinho);
                                await carrinhoRepository.UpdateAsync(carrinho);

                                AtualizarQuantidadeDisponivel(produto, itemCarrinho.Quantidade);
                            }
                        }
                        else
                        {
                            var itemCarrinho = new ItemCarrinho()
                            {
                                CarrinhoId = carrinho.Id,
                                ProdutoId = produto.Id,
                                Quantidade = 1,
                                Valor = (produto.ValorAtual * 0.15m)
                            };

                            carrinho.ItensCarrinho.Add(itemCarrinho);
                            await carrinhoRepository.UpdateAsync(carrinho);

                            await AtualizarQuantidadeDisponivel(produto, itemCarrinho.Quantidade);
                        }
                    }
                }

                return Redirect($"/default/catalogo/{(int)Categoria}");
            }
            catch (Exception ex)
            {
                SetViewData(TipoNotificacao.Erro, $"Não foi possível incluir o produto no carrinho: {ex.Message}");
                return Redirect($"/default/catalogo/{(int)Categoria}");
            }
        }

        private async Task AtualizarQuantidadeDisponivel(Produto produto, int quantidadeReservada)
        {
            produto.QuantidadeDisponivel -= quantidadeReservada;
            await produtoRepository.UpdateAsync(produto);
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
