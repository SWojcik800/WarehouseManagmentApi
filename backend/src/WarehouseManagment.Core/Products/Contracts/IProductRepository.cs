using OneOf;
using OneOf.Types;
using WarehouseManagment.Common.Pagination;
using WarehouseManagment.Core.Products.Queries;

namespace WarehouseManagment.Core.Products
{
    public interface IProductRepository
    {
        Task<PaginatedResult<Product>> GetAll(GetPaginatedProductListQuery query);
        Task<List<Product>> GetAllList();
        Task Add(Product product);
        Task<int> SaveChanges();
        Task<OneOf<Product, NotFound>> GetById(long id);
    }
}
