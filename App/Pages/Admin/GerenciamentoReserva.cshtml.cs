using App.Enums;
using App.Models;
using App.Repositories.Interfaces;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages.Admin
{
    public class GerenciamentoReservaModel : PageModel
    {
        private readonly IReservaRepository reservaRepository;
        private readonly IStandRepository standRepository;

        public List<ItemReserva> ItensReserva { get; set; }

        [BindProperty]
        public Guid StandId { get; set; }

        public GerenciamentoReservaModel(IReservaRepository reservaRepository,
            IStandRepository standRepository)
        {
            this.reservaRepository = reservaRepository;
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
                    if (stand.ItensReserva.Any())
                    {
                        ItensReserva = stand.ItensReserva.ToList();
                    }
                    else
                    {
                        SetViewData(TipoNotificacao.Informativa, "Não foram encontradas reservas realizadas.");
                    }
                }
            }
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
