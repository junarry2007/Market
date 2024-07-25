using MarketPlus.Application.Abstractions.Messaging;

namespace MarketPlus.Application.Products.GetProduct
{
    public sealed record GetProductQuery : IQuery<IReadOnlyList<ProductResponse>>;
}
