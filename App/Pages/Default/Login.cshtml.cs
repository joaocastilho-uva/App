using App.Enums;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Default
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await signInManager.PasswordSignInAsync(LoginViewModel.Nome, LoginViewModel.Senha, false, false);

                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToPage("/index");
                }
                else
                {
                    SetViewData(TipoNotificacao.Erro, "Nome ou senha incorreto.");
                    return Page();
                }
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
