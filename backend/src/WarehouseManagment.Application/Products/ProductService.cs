using MapsterMapper;
using OneOf;
using OneOf.Types;
using WarehouseManagment.Application.Products.Dtos;
using WarehouseManagment.Common.Errors;
using WarehouseManagment.Common.Exceptions;
using WarehouseManagment.Common.Pagination;
using WarehouseManagment.Core.Products;
using WarehouseManagment.Core.Products.Queries;

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

        public async Task<List<ProductDto>> GetAllList()
        {
            var products = await _productRepository.GetAllList();
            var dtos = _mapper.Map<List<ProductDto>>(products);

            return dtos;
        }

        public async Task<PaginatedResult<ProductDto>> GetAll(GetPaginatedProductListQuery query)
        {
            var paginatedProducts = await _productRepository.GetAll(query);

            return new PaginatedResult<ProductDto>
            {
                Items = _mapper.Map<List<ProductDto>>(paginatedProducts.Items),
                TotalCount = paginatedProducts.TotalCount
            };
        }

        public async Task<OneOf<ProductDto, NotFound>> GetById(long id)
        {
            var productOrNotFound = await _productRepository.GetById(id);

            return productOrNotFound.Match<OneOf<ProductDto, NotFound>>(
                product => _mapper.Map<ProductDto>(product),
                notFound => notFound
                );
        }

        public async Task<OneOf<Yes, ValidationError>> Create(CreateProductDto dto)
        {
            try
            {
                var newProduct = Product.Create(dto.Name, dto.Description, dto.Manufacturer);

                await _productRepository.Add(newProduct);
                await _productRepository.SaveChanges();
                return new Yes();
            }
            catch (ValidationException ex)
            {
                return new ValidationError(ex.Message);
            }
        }

        public async Task<OneOf<long, NotFound, ValidationError>> Update(UpdateProductDto dto)
        {
            var productOrNotFound = await _productRepository.GetById(dto.Id);

            if (productOrNotFound.IsT1)
                return productOrNotFound.AsT1;

            var product = productOrNotFound.AsT0;

            try
            {
                if (!string.IsNullOrEmpty(dto.Name))
                    product.Name = dto.Name;

                if (!string.IsNullOrEmpty(dto.Description))
                    product.Description = dto.Description;

                if (!string.IsNullOrEmpty(dto.Manufacturer))
                    product.Manufacturer = dto.Manufacturer;
            }
            catch (ValidationException e)
            {
                return new ValidationError(e.Message, e.ErrorCode);                
            }
            

            await _productRepository.SaveChanges();
            return product.Id;
        }

        public async Task<OneOf<long, NotFound>> Delete(long id)
        {
            var productOrNotFound = await _productRepository.GetById(id);

            if(productOrNotFound.IsT0)
            {
                var product = productOrNotFound.AsT0;
                product.Delete();
                await _productRepository.SaveChanges();
                return product.Id;
            }

            return productOrNotFound.AsT1;            
        }

    }
}
