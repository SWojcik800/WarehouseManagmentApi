using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Core.Exceptions;
using WarehouseManagment.Core.Products;
using WarehouseManagment.Infrastructure.Data;

namespace WarehouseManagment.Infrastructure.Repositories.Products
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly WarehouseContext _context;

        public ProductRepository(WarehouseContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        {
            var entities = await _context.Products.ToListAsync();
            return entities;
        }

        public async Task<Product> GetById(long id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (entity is null)
                throw new NotFoundException("Product", id);

            return entity;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<int> SaveChanges()
            => await _context.SaveChangesAsync();

        
    }
}
