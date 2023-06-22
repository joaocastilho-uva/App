using App.Models;

namespace App.Repositories.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> GetAsync(Guid userId);
        Task<Carrinho> AddAsync(Carrinho carrinho);
        Task<Carrinho> UpdateAsync(Carrinho carrinho);
    }
}
