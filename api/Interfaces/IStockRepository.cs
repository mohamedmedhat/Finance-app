using api.Dtos.Stock;
using api.models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);

        Task<Stock> CreateAsync(Stock createDto);

        Task<Stock?> UpdateAsync(UpdateStockRequestDto updateDto,int id);

        Task<Stock?> DeleteAsync(int id);
    }
}
