namespace MarketPlus.Application.Abstractions.Clock
{
    public interface IDateTimeProvider
    {
        DateTime currentTime { get; }
    }
}
