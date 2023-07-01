using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using WarehouseManagment.Common.Extensions;
using WarehouseManagment.Common.Pagination;
using WarehouseManagment.Core.StockLevels.Contracts;
using WarehouseManagment.Core.StockLevels.Entities;
using WarehouseManagment.Core.StockLevels.Queries;
using WarehouseManagment.Core.StockLevels.ReadModels;
using WarehouseManagment.Infrastructure.Data;

namespace WarehouseManagment.Infrastructure.Repositories.StockLevels
{
    internal class StockLevelRepository : IStockLevelRepository
    {
        private readonly WarehouseContext _context;

        public StockLevelRepository(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<StockLevelReadModel>> GetAllReadModels(GetPaginatedStockLevelListQuery query)
        {
            var baseQuery = _context.StockLevelReadModels
                .AddFilterIfNotNullOrEmpty(query.ProductName, p => p.ProductName.Contains(query.ProductName))
                .AddFilterIfNotNullOrEmpty(query.ProductManufacturer, p => p.ProductManufacturer.Contains(query.ProductManufacturer));

            var stockLevels = await baseQuery
                .Skip(query.Offset)
                .Take(query.Limit)
                .ToListAsync();

            var totalCount = await baseQuery.CountAsync();

            return new PaginatedResult<StockLevelReadModel>(stockLevels, totalCount);
        }

        public async Task<OneOf<StockLevelReadModel, NotFound>> GetReadModelByProductId(long productId)
        {
            var readModel = await _context.StockLevelReadModels.FirstOrDefaultAsync(r => r.ProductId == productId);

            if(readModel is null)
                return new NotFound();

            return readModel;
        }

        public async Task<long> Save(StockLevel stockLevel)
        {
            var stockLevelExists = await _context.StockLevels.AnyAsync(x => x.Id == stockLevel.Id);

            if(stockLevelExists)
                _context.StockLevels.Update(stockLevel);
            else
                _context.StockLevels.Add(stockLevel);

            await _context.SaveChangesAsync();
            return stockLevel.Id;
        }

        public async Task<OneOf<StockLevel, NotFound>> GetByProductId(long productId)
        {
            var stockLevel = await _context.StockLevels.FirstOrDefaultAsync(x => x.ProductId == productId);

            if(stockLevel is null)
                return new NotFound();

            return stockLevel;
        }
        
    }
}
