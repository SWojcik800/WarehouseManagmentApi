using WarehouseManagment.Application.Products.Dtos;
using WarehouseManagment.Core.Products.Queries;

namespace WarehouseManagment.Application.Products
{
    public interface IProductService
    {
        Task Create(CreateProductDto dto);
        Task Delete(long id);
        Task<List<ProductDto>> GetAll(GetPaginatedProductListQuery query);
        Task<ProductDto> GetById(long id);
        Task Update(UpdateProductDto dto);
    }
}