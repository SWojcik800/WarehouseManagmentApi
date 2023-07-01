using OneOf;
using OneOf.Types;
using WarehouseManagment.Application.StockLevels.Dto;
using WarehouseManagment.Common.Errors;
using WarehouseManagment.Common.Exceptions;
using WarehouseManagment.Common.Pagination;
using WarehouseManagment.Core.StockLevels.Contracts;
using WarehouseManagment.Core.StockLevels.Entities;
using WarehouseManagment.Core.StockLevels.Queries;
using WarehouseManagment.Core.StockLevels.ReadModels;

namespace WarehouseManagment.Application.StockLevels
{
    internal class StockLevelService : IStockLevelService
    {
        private readonly IStockLevelRepository _stockLevelRepository;

        public StockLevelService(IStockLevelRepository stockLevelRepository)
        {
            _stockLevelRepository = stockLevelRepository;
        }

        public async Task<PaginatedResult<StockLevelReadModel>> GetAll(GetPaginatedStockLevelListQuery query)
            => await _stockLevelRepository.GetAllReadModels(query); 
        
        public async Task<OneOf<StockLevelReadModel, NotFound>> GetByProductId(long productId)        
            => await _stockLevelRepository.GetReadModelByProductId(productId);                    

        public async Task<OneOf<Yes, ValidationError>> Create(CreateStockLevelDto stockLevelDto)
        {
            try
            {
                var stockLevel = StockLevel.Create(stockLevelDto.ProductId, stockLevelDto.Count);
                await _stockLevelRepository.Save(stockLevel);
                return new Yes();
            }
            catch (ValidationException ex)
            {
                return new ValidationError(ex.Message);
            }            
        }

        public async Task<OneOf<long, NotFound, ValidationError>> ChangeStockLevelCount(ChangeStockLevelCountDto changeStockLevelCountDto)
        {
            try
            {
                var stockLevel = await _stockLevelRepository.GetByProductId(changeStockLevelCountDto.ProductId);

                if (stockLevel.IsT1)
                { 
                    var createdStockLevel = StockLevel.Create(changeStockLevelCountDto.ProductId, changeStockLevelCountDto.ProductsInStock);
                    var createdStockLevelId = await _stockLevelRepository.Save(createdStockLevel);
                    return createdStockLevelId;

                }
             
                var updatedStockLevel = stockLevel.AsT0;
                updatedStockLevel.ChangeCount(changeStockLevelCountDto.ProductsInStock);
                var updatedStockLevelId = await _stockLevelRepository.Save(updatedStockLevel);
                return updatedStockLevel.ProductId;                        

            }
            catch (ValidationException ex)
            {

                return new ValidationError(ex.Message);                
            }
        }


    }
}
