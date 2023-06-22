using App.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Repositories.Interfaces
{
    public interface IStandRepository
    {
        Task<Stand> AddAsync(Stand stand);
        Task<Stand> GetAsync(Guid id);
        Task<IEnumerable<Stand>> GetAllAsync(IdentityUser identityUser);
        Task<IEnumerable<Stand>> GetAllAsync();
        Task<Stand> UpdateAsync(Stand stand);
    }
}
