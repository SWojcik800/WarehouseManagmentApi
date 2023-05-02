namespace WarehouseManagment.Core.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task Add(Product product);
        Task<int> SaveChanges();
        Task<Product> GetById(long id);
    }
}
