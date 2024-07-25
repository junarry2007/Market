using MarketPlus.Application.Abstractions.Messaging;
using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products;

namespace MarketPlus.Application.Products.GetProduct
{
    internal sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, IReadOnlyList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<IReadOnlyList<ProductResponse>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAll(cancellationToken);

            if (product is null)
            {
                return Result.Failure<IReadOnlyList<ProductResponse>>(ProductError.NotFound);
            }

            return product.Select(x => new ProductResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status,
                Stock = x.Stock,
                Price = x.Price is not null ? x.Price.Amount : 0,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList();
        }
    }
}
