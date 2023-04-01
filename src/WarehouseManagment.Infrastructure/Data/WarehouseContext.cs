using Microsoft.EntityFrameworkCore;

namespace WarehouseManagment.Infrastructure.Data
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

    }
}
