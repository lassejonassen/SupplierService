namespace SupplierService.Application.Contacts.Queries.GetContactBySupplierId;

public sealed record GetContactBySupplierIdQuery(Guid SupplierId) : IQuery<IEnumerable<Contact>>;
