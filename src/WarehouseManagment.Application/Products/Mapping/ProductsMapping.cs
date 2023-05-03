using Mapster;
using WarehouseManagment.Application.Products.Dtos;
using WarehouseManagment.Core.Products;

namespace WarehouseManagment.Application.Products.Mapping
{
    internal class ProductsMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDto>()
                .Map(dest => dest.Name, src => src.Name.Value)
                .Map(dest => dest.Description, src => src.Description.Value)
                .Map(dest => dest.Manufacturer, src => src.Manufacturer.Value);
        }
    }
}
