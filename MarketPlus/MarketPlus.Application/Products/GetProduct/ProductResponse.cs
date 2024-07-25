namespace MarketPlus.Application.Products.GetProduct
{
    public class ProductResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public bool? Status { get; init; }
        public string? StatusHomologate { get; set; }
        public int? Stock { get; init; }
        public decimal? Price { get; init; }
        public decimal? Discount { get; init; }
        public decimal? FinalPrice { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public DateTime? DeletedAt { get; init; }
    }
}
