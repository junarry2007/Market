namespace MarketPlus.Domain.Products
{
    public record Currency
    {
        public static readonly Currency None = new("");
        public static readonly Currency Usd = new("USD");
        public static readonly Currency Cop = new("COP");
        private Currency(string code) => Code = code;
        public string? Code { get; init; }

        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            Usd,
            Cop
        };
        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ??
                throw new ApplicationException("El tipo de divisa es invalido");
        }
    }
}
