using OneOf;
using OneOf.Types;
using WarehouseManagment.Application.Products.Dtos;
using WarehouseManagment.Common.Errors;
using WarehouseManagment.Common.Pagination;
using WarehouseManagment.Core.Products.Queries;

namespace WarehouseManagment.Application.Products
{
    public interface IProductService
    {
        Task<OneOf<Yes, ValidationError>> Create(CreateProductDto dto);
        Task<OneOf<long, NotFound>> Delete(long id);
        Task<PaginatedResult<ProductDto>> GetAll(GetPaginatedProductListQuery query);
        Task<OneOf<ProductDto, NotFound>> GetById(long id);
        Task<OneOf<long, NotFound, ValidationError>> Update(UpdateProductDto dto);
        Task<List<ProductDto>> GetAllList();
    }
}