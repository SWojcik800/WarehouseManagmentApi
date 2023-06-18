using OneOf;
using OneOf.Types;
using WarehouseManagment.Application.StockLevels.Dto;
using WarehouseManagment.Common.Errors;
using WarehouseManagment.Core.StockLevels.Queries;
using WarehouseManagment.Core.StockLevels.ReadModels;

namespace WarehouseManagment.Application.StockLevels
{
    public interface IStockLevelService
    {
        Task<OneOf<long, NotFound, ValidationError>> ChangeStockLevelCount(ChangeStockLevelCountDto changeStockLevelCountDto);
        Task<OneOf<Yes, ValidationError>> Create(CreateStockLevelDto stockLevelDto);
        Task<List<StockLevelReadModel>> GetAll(GetPaginatedStockLevelListQuery query);
        Task<OneOf<StockLevelReadModel, NotFound>> GetByProductId(long productId);
    }
}