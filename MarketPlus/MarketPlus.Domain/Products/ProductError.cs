using MarketPlus.Domain.Abstractions;

namespace MarketPlus.Domain.Products
{
    public static class ProductError
    {
        public static Error NotFound = new("Product.Found","No existe un producto con este id");
    }
}
