using VendorService.Application.Abstractions.Messaging;

namespace VendorService.Application.VendorService.Application.Vendors.Commands.DeleteVendor;

public sealed record DeleteVendorCommand(Guid Id) : ICommand;