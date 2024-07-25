using MarketPlus.Application.Abstractions.Messaging;
using MarketPlus.Application.Products.GetProduct;
using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products;

namespace MarketPlus.Application.Products.SearchProduct
{
    internal sealed class SearchProductQueryHandler : IQueryHandler<SearchProductQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductService _productService;
        public SearchProductQueryHandler(IProductRepository productRepository, ProductService productService)
        {
            _productRepository = productRepository;
            _productService = productService;
        }
        public async Task<Result<ProductResponse>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.id, cancellationToken);

            if (product is null)
            {
                return Result.Failure<ProductResponse>(ProductError.NotFound);
            }

            decimal price = product.Price is not null ? product.Price.Amount : 0;
            decimal discountPrice = new Random().Next(1, 101);
            var finalPrice = _productService.FinalPrice(price, discountPrice);
            
            ProductResponse prod = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Status = product.Status,
                Stock = product.Stock,
                Price = price,
                Discount = discountPrice,
                FinalPrice = finalPrice,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                DeletedAt = product.DeletedAt

            };
            return prod;
        }
    }
}
