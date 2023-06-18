using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagment.Application.StockLevels;
using WarehouseManagment.Application.StockLevels.Dto;
using WarehouseManagment.Core.StockLevels.Queries;

namespace WarehouseManagment.Api.StockLevel
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLevelController : ControllerBase
    {
        private readonly IStockLevelService _stockLevelService;

        public StockLevelController(IStockLevelService stockLevelService)
        {
            _stockLevelService = stockLevelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetPaginatedStockLevelListQuery query)
            => Ok(await _stockLevelService.GetAll(query));

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(long productId)
        {
            var result = await _stockLevelService.GetByProductId(productId);

            return result.Match<IActionResult>(
                        stockLevelReadModel => Ok(stockLevelReadModel),
                        notFound => NotFound(productId)
                        );
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStockLevelDto dto)
        {
            var result = await _stockLevelService.Create(dto);

            return result.Match<IActionResult>(
                    yes => Ok(),
                    validationError => ValidationProblem(validationError.errorMessage)
                    );
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStockLevelCount(ChangeStockLevelCountDto changeStockLevelCountDto)
        {
            var result = await _stockLevelService.ChangeStockLevelCount(changeStockLevelCountDto);

            return result.Match<IActionResult>(
                    id => Ok(id),
                    notFound => NotFound(changeStockLevelCountDto.ProductId),
                    validationError => ValidationProblem(validationError.errorMessage)
                );
        }
    }
}
