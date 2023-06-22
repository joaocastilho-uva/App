using App.Repositories.Interfaces;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Admin
{
    public class VisualizacaoStandModel : PageModel
    {
        private readonly IStandRepository standRepository;

        public StandViewModel StandViewModel { get; set; }

        public VisualizacaoStandModel(IStandRepository standRepository)
        {
            this.standRepository = standRepository;
        }
        public async Task OnGet(Guid standId)
        {
            var standDb = await standRepository.GetAsync(standId);

            if (standDb != null)
            {
                StandViewModel = new StandViewModel()
                {
                    Id = standDb.Id,
                    Nome = standDb.Nome,
                    Localizacao = standDb.Localizacao,
                    Ativo = standDb.Ativo,
                };
            }
        }
    }
}
