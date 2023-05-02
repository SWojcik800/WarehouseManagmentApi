using MapsterMapper;
using WarehouseManagment.Application.Products.Dtos;
using WarehouseManagment.Core.Products;

namespace WarehouseManagment.Application.Products
{
    internal sealed class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            //TODO Add filters
            var products = await _productRepository.GetAll();
            var dtos = _mapper.Map<List<ProductDto>>(products);

            return dtos;
        }

        public async Task<ProductDto> GetById(long id)
        {
            var products = await _productRepository.GetById(id);
            var dto = _mapper.Map<ProductDto>(products);

            return dto;
        }

        public async Task Create(CreateProductDto dto)
        {
            var newProduct = Product.Create(dto.Name, dto.Description, dto.Manufacturer);

            await _productRepository.Add(newProduct);
            await _productRepository.SaveChanges();
        }

        public async Task Update(UpdateProductDto dto)
        {
            var product = await _productRepository.GetById(dto.Id);

            if (!string.IsNullOrEmpty(dto.Name))
                product.Name = dto.Name;

            if(!string.IsNullOrEmpty(dto.Description))
                product.Description = dto.Description;

            if (!string.IsNullOrEmpty(dto.Manufacturer))
                product.Manufacturer = dto.Manufacturer;

            await _productRepository.SaveChanges();
        }

        public async Task Delete(long id)
        {
            var product = await _productRepository.GetById(id);
            product.Delete();

            await _productRepository.SaveChanges();
        }

    }
}
