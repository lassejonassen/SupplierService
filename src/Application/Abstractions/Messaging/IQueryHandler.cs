using MediatR;
using SupplierService.Domain.Shared;

namespace SupplierService.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
	: IRequestHandler<TQuery, Result<TResponse>>
	where TQuery : IQuery<TResponse>;
