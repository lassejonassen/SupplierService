namespace SupplierService.Application.Contacts.Queries.GetContactById;

public sealed record GetContactByIdQuery(Guid Id) : IQuery<Contact>;
