using MarketPlus.Application.Abstractions.Messaging;
using MarketPlus.Application.Products.GetProduct;

namespace MarketPlus.Application.Products.SearchProduct
{
    public sealed record SearchProductQuery(Guid id) : IQuery<ProductResponse>;
}
