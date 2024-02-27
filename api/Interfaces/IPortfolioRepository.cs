using api.models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Portfolio>> GetUserPortfolio(AppUser user);
        Task<Portfolio> CreateAsync(Portfolio portfolio);

        Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol);
    }
}
