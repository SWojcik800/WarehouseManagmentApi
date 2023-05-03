using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Common.Extensions;
using WarehouseManagment.Core.Exceptions;
using WarehouseManagment.Core.Products;
using WarehouseManagment.Core.Products.Queries;
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
        public async Task<List<Product>> GetAll(GetPaginatedProductListQuery query)
        {
            var entities = await _context.Products
                .AsQueryable()
                .AddFilterIfNotNullOrEmpty(query.Name, p => p.Name.Value.Contains(query.Name))
                .AddFilterIfNotNullOrEmpty(query.Description, p => p.Description.Value.Contains(query.Description))
                .AddFilterIfNotNullOrEmpty(query.ManufacturerName, p => p.Manufacturer.Value.Contains(query.ManufacturerName))
                .Skip(query.Offset)
                .Take(query.Limit)
                .ToListAsync();

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
