using App.Enums;
using App.Models;
using App.Repositories.Interfaces;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.User
{
    public class AcompanhamentoReservaModel : PageModel
    {
        private readonly IReservaRepository reservaRepository;
        private readonly UserManager<IdentityUser> userManager;

        public List<Reserva> Reservas { get; set; }

        public AcompanhamentoReservaModel(IReservaRepository reservaRepository,
            UserManager<IdentityUser> userManager)
        {
            this.reservaRepository = reservaRepository;
            this.userManager = userManager;
            Reservas = new List<Reserva>();
        }

        public async Task OnGet()
        {
            Reservas = (await reservaRepository.GetAllAsync(await userManager.GetUserAsync(User))).ToList();

            if (Reservas == null && !Reservas.Any())
            {
                SetViewData(TipoNotificacao.Informativa, "Não foram encontrados reservas realizadas.");
            }
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
