using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;

namespace VendorService.Application.Vendors.Queries.GetVendorById;

public sealed record GetVendorByIdQuery(Guid Id) : IQuery<Vendor>;