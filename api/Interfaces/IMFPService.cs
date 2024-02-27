using api.models;

namespace api.Interfaces
{
    public interface IMFPService
    {
        Task<Stock> FindStockBySymbol(string symbol);
    }
}
