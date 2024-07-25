﻿using MarketPlus.Domain.Abstractions;
using MediatR;

namespace MarketPlus.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery,TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    {

    }
}
