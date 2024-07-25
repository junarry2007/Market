using MarketPlus.Domain.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlus.Infrastructure.Configurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.ToTable("products");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name)
                .HasComment("Product name")
                .HasMaxLength(500)
                .IsRequired();
            entityBuilder.Property(x => x.Description)
                .HasComment("Product description");
            entityBuilder.Property(x => x.Status)
                .HasComment("Product status with default value in true")
                .HasDefaultValue(true)
                .IsRequired();
            entityBuilder.Property(x => x.Stock)
                .HasComment("Produc quantity")
                .IsRequired();
            entityBuilder.OwnsOne(x => x.Price, priceBuilder => {
                priceBuilder.Property(y => y.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code!))
                .HasMaxLength(10);
            });
            entityBuilder.Property(x => x.CreatedAt)
                .HasComment("Creation audit");
            entityBuilder.Property(x => x.UpdatedAt)
                .HasComment("Update audit");
            entityBuilder.Property(x => x.DeletedAt)
                .HasComment("Delete audit");

            //Filter to always get non-deleted records
            entityBuilder.HasQueryFilter(x => x.DeletedAt == null);
        }
    }
}
