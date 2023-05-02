using WarehouseManagment.Application.Products.Dtos;

namespace WarehouseManagment.Application.Products
{
    public interface IProductService
    {
        Task Create(CreateProductDto dto);
        Task Delete(long id);
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> GetById(long id);
        Task Update(UpdateProductDto dto);
    }
}