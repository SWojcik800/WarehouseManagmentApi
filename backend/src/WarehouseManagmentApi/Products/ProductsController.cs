using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagment.Application.Products;
using WarehouseManagment.Application.Products.Dtos;
using WarehouseManagment.Core.Products.Queries;

namespace WarehouseManagment.Api.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetPaginatedProductListQuery query)
            => Ok(await _productService.GetAll(query));

        [HttpGet("GetAllList")]
        public async Task<IActionResult> GetAllList()
            => Ok(await _productService.GetAllList());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _productService.GetById(id);

            return result.Match<IActionResult>(
                        productDto => Ok(productDto),
                        notFound => NotFound(id)
                        );
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var result = await _productService.Create(dto);

            return result.Match<IActionResult>(
                    yes => Ok(),
                    validationError => ValidationProblem(validationError.errorMessage)
                    );
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            var result = await _productService.Update(dto);

            return result.Match<IActionResult>(
                    id => Ok(id),
                    notFound => NotFound(dto.Id),
                    validationError => ValidationProblem(validationError.errorMessage)
                    );
        }                 

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _productService.Delete(id);

            return result.Match<IActionResult>(
                    id => Ok(id),
                    notFound => NotFound(id)
                    );
        }
        
    }
}
