using VendorService.Domain.Entities;

namespace VendorService.Application.VendorService.Application.Vendors.Queries.GetVendorById;

public sealed record GetVendorByIdQuery(Guid Id) : IQuery<Vendor>;