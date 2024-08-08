using VendorService.Domain.Entities;

namespace VendorService.Application.VendorService.Application.Vendors.Queries.GetAllVendors;

public sealed record GetAllVendorsQuery : IQuery<IEnumerable<Vendor>>;