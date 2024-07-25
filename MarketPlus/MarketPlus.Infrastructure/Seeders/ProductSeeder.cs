using MarketPlus.Domain.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlus.Infrastructure.Seeders
{
    internal class ProductSeeder
    {
        internal ProductSeeder(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasData(
                Product.CreateProduct("Guayos", "Guayos futbol", true, 5, null, DateTime.Now),
                Product.CreateProduct("Camiseta", "Camiseta oficial de colombia", true, 10, null, DateTime.Now),
                Product.CreateProduct("Balon", "Balón copa america", true, 15, null, DateTime.Now)
                );
        }
    }
}
