using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagment.Application.Products;
using WarehouseManagment.Application.Products.Dtos;

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
        public async Task<IActionResult> GetAll()
            => Ok(await _productService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
            => Ok(await _productService.GetById(id));

        [HttpPost]
        public async Task Create(CreateProductDto dto)
            => await _productService.Create(dto);        

        [HttpPatch]
        public async Task Update(UpdateProductDto dto)
            => await _productService.Update(dto);        

        [HttpDelete]
        public async Task Delete(long id)
            => await _productService.Delete(id);
        
    }
}
