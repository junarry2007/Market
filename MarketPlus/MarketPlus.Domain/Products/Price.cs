namespace MarketPlus.Domain.Products
{
    public record Price(decimal Amount, Currency Currency)
    {
        public static Price operator +(Price primero, Price segundo)
        {
            if (primero.Currency != segundo.Currency)
            {
                throw new InvalidOperationException("El tipo de divisa debe ser el mismo");
            }

            return new Price(primero.Amount + segundo.Amount, primero.Currency);
        }
        public static Price Zero() => new(0, Currency.None);
        public static Price Zero(Currency tipoMoneda) => new(0, tipoMoneda);
        public bool IsZero() => this == Zero(Currency);

    }
}
