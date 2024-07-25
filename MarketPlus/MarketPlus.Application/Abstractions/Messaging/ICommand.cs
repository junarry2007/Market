using MarketPlus.Domain.Abstractions;
using MediatR;

namespace MarketPlus.Application.Abstractions.Messaging
{
    /// <summary>
    /// No return data
    /// </summary>
    public interface ICommand : IRequest<Result>, IBaseCommand
    {

    }
    /// <summary>
    /// Return data (Optional)
    /// </summary>
    /// <typeparam name="TResponse">Data</typeparam>
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }
    /// <summary>
    /// (Optional) Interface or components constraints check
    /// </summary>
    public interface IBaseCommand
    {

    }
}
