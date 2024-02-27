using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context) 
        {
            _context = context;
        }


        async Task<List<Stock>> IStockRepository.GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }

        async Task<Stock?> IStockRepository.GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        async Task<Stock> IStockRepository.CreateAsync(Stock createDto)
        {
            await _context.Stocks.AddAsync(createDto);
            await _context.SaveChangesAsync();
            return createDto;
        }

        async Task<Stock?> IStockRepository.UpdateAsync(UpdateStockRequestDto updateDto, int id)
        {
            var existingStock = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = updateDto.Symbol;
            existingStock.Industry = updateDto.Industry;
            existingStock.Purchase = updateDto.Purchase;
            existingStock.LastDiv = updateDto.LastDiv;
            existingStock.CompanyName = updateDto.CompanyName;
            existingStock.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;
        }

        async Task<Stock?> IStockRepository.DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }

            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return stockModel;
        }
    }
}
