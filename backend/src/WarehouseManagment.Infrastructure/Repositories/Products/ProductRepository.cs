using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using WarehouseManagment.Common.Extensions;
using WarehouseManagment.Common.Pagination;
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
        public async Task<PaginatedResult<Product>> GetAll(GetPaginatedProductListQuery query)
        {
            var baseQuery = _context.Products
                .AsQueryable()
                .AddFilterIfNotNullOrEmpty(query.Name, p => p.Name.Value.Contains(query.Name))
                .AddFilterIfNotNullOrEmpty(query.Description, p => p.Description.Value.Contains(query.Description))
                .AddFilterIfNotNullOrEmpty(query.ManufacturerName, p => p.Manufacturer.Value.Contains(query.ManufacturerName));

            var entities = await baseQuery
                .Skip(query.Offset)
                .Take(query.Limit)
                .ToListAsync();

            var totalCount = await baseQuery.CountAsync();

            return new PaginatedResult<Product>(entities, totalCount);
        }

        public async Task<List<Product>> GetAllList()
            => await _context.Products.ToListAsync();

        public async Task<OneOf<Product, NotFound>> GetById(long id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (entity is null)
                return new NotFound();

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
