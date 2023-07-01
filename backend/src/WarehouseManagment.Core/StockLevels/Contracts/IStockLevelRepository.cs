using OneOf;
using OneOf.Types;
using WarehouseManagment.Common.Pagination;
using WarehouseManagment.Core.StockLevels.Entities;
using WarehouseManagment.Core.StockLevels.Queries;
using WarehouseManagment.Core.StockLevels.ReadModels;

namespace WarehouseManagment.Core.StockLevels.Contracts
{
    public interface IStockLevelRepository
    {
        Task<PaginatedResult<StockLevelReadModel>> GetAllReadModels(GetPaginatedStockLevelListQuery query);
        Task<OneOf<StockLevel, NotFound>> GetByProductId(long id);
        Task<OneOf<StockLevelReadModel, NotFound>> GetReadModelByProductId(long id);
        Task<long> Save(StockLevel stockLevel);
    }
}
