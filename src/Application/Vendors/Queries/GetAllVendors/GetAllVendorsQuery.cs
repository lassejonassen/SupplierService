using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;

namespace VendorService.Application.Vendors.Queries.GetAllVendors;

public sealed record GetAllVendorsQuery : IQuery<IEnumerable<Vendor>>;