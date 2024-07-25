using MarketPlus.Domain.Abstractions;

namespace MarketPlus.Domain.Products.Events
{
    public sealed record ProductCreatedDomainEvent(Guid Id) : IDomainEvent;
}
