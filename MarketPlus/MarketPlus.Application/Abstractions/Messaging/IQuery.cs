using MarketPlus.Domain.Abstractions;
using MediatR;

namespace MarketPlus.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
