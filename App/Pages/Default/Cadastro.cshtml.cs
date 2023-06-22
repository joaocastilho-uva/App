using App.Enums;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Default
{
    public class CadastroModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public CadastroViewModel CadastroViewModel { get; set; }

        public CadastroModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = CadastroViewModel.Nome,
                    Email = CadastroViewModel.Email
                };

                var identityResult = await userManager.CreateAsync(user, CadastroViewModel.Senha);

                if (identityResult.Succeeded)
                {
                    var addRolesResult = await userManager.AddToRoleAsync(user, "User");

                    if (addRolesResult.Succeeded)
                    {
                        SetViewData(TipoNotificacao.Sucesso, "Usuário cadastrado com sucesso.");

                        return Page();
                    }
                }

                SetViewData(TipoNotificacao.Erro, "Não foi possível cadastrar o usuário.");

                return Page();
            }
            else
            {
                return Page();
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
