using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;

namespace VendorService.Application.Contacts.Queries.GetContactBySupplierId;

public sealed record GetContactBySupplierIdQuery(Guid SupplierId) : IQuery<IEnumerable<Contact>>;
