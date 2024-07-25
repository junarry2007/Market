using MarketPlus.Application.Abstractions.Clock;

namespace MarketPlus.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime currentTime => DateTime.UtcNow;
    }
}
