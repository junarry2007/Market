namespace MarketPlus.Api.Controllers.Product
{
    public sealed record ProductRequest(
        string Name,
        string Description,
        bool Status,
        int Stock,
        decimal Amount,
        string Currency
    );
}