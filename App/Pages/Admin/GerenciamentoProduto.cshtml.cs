using App.Enums;
using App.Models;
using App.Repositories.Interfaces;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages.Admin
{
    public class GerenciamentoProdutoModel : PageModel
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IStandRepository standRepository;

        public List<Produto> Produtos { get; set; }

        [BindProperty]
        public Guid StandId { get; set; }

        public GerenciamentoProdutoModel(IProdutoRepository produtoRepository,
            IStandRepository standRepository)
        {
            this.produtoRepository = produtoRepository;
            this.standRepository = standRepository;
        }

        public async Task OnGet(Guid standId)
        {
            GetTempData();

            if (standId != Guid.Empty)
            {
                StandId = standId;
                var stand = await standRepository.GetAsync(standId);

                if (stand != null)

                {
                    if (stand.Produtos.Any())
                    {
                        Produtos = stand.Produtos.ToList();
                    }
                    else
                    {
                        SetViewData(TipoNotificacao.Informativa, "Não foram encontrados produtos cadastrados");
                    }
                }
            }
        }

        public async Task<IActionResult> OnPostDelete(Guid produtoId) 
        {
            try
            {
                ValidateOnPostDelete();

                var excluido = await produtoRepository.DeleteAsync(produtoId);

                if (excluido)
                {
                    var stand = await standRepository.GetAsync(StandId);

                    SetViewData(TipoNotificacao.Sucesso, "Produto excluído com sucesso.");
                }

                return Redirect($"/admin/gerenciamentoproduto/{StandId}");
            }
            catch (Exception ex)
            {
                var notificacao = new NotificacaoViewModel
                {
                    Tipo = TipoNotificacao.Sucesso,
                    Mensagem = $"Não foi possível excluir o produto: {ex.Message}."
                };

                TempData["Notificacao"] = JsonSerializer.Serialize(notificacao);

                return RedirectToPage("/admin/gerenciamentoproduto");
            }
        }

        private void ValidateOnPostDelete()
        {
            
        }

        private void GetTempData()
        {
            var notificaticao = (string)TempData["Notificacao"];

            if (!string.IsNullOrWhiteSpace(notificaticao))
            {
                ViewData["Notificacao"] = JsonSerializer.Deserialize<NotificacaoViewModel>(notificaticao.ToString()); ;
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
