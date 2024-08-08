namespace VendorService.Application.Vendors.Commands.UpdateVendor;

public sealed record UpdateVendorCommand(Vendor Vendor) : ICommand;
