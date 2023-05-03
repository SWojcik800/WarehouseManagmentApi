using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WarehouseManagment.Infrastructure.Data
{
    public sealed class WarehouseContextFactory : IDesignTimeDbContextFactory<WarehouseContext>
    {
        public WarehouseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()+ @"\..\WarehouseManagmentApi")
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<WarehouseContext> builder = new DbContextOptionsBuilder<WarehouseContext>();
            builder.UseSqlServer(configuration.GetConnectionString("WarehouseDatabase"));

            return new WarehouseContext(builder.Options);
        }
    }
}
