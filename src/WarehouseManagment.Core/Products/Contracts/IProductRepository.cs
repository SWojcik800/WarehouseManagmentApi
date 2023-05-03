using WarehouseManagment.Core.Products.Queries;

namespace WarehouseManagment.Core.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll(GetPaginatedProductListQuery query);
        Task Add(Product product);
        Task<int> SaveChanges();
        Task<Product> GetById(long id);
    }
}
