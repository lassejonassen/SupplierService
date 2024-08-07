using MediatR;
using SupplierService.Domain.Shared;

namespace SupplierService.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;