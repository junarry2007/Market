using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products.Events;

namespace MarketPlus.Domain.Products
{
    public sealed class Product : Entity
    {
        private Product() { }
        private Product
            (
            Guid id,
            string name,
            string description,
            bool status,
            int stock,
            Price price,
            DateTime createdAt
            ) : base(id)
        {
            Name = name;
            Description = description;
            Status = status;
            Stock = stock;
            Price = price;
            CreatedAt = createdAt;
        }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public bool? Status { get; private set; }
        public int? Stock { get; private set; }
        public Price? Price { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public static Product CreateProduct(
            string name,
            string description,
            bool status,
            int stock,
            Price price,
            DateTime createdAt
        )
        {
            var product = new Product(
                Guid.NewGuid(),
                name,
                description,
                status,
                stock,
                price,
                createdAt
            );

            //Publicar evento esperando que a futuro un subscriptor lo capture y dispare algún evento
            product.RaiseDomainEvent(new ProductCreatedDomainEvent(product.Id!)); 

            return product;
        }

        public void UpdateProduct(string name,string description, bool status,int stock, Price price, DateTime updateAt)
        {
            Name = name;
            Description = description;
            Status = status;
            Stock = stock;
            Price = price;
            UpdatedAt = updateAt;
        }
        public void DeleteProduct(DateTime deleteAt)
        {
            DeletedAt = deleteAt;
        }
    }
}
