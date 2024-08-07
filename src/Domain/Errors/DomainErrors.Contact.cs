
using SupplierService.Domain.Shared;

namespace SupplierService.Domain.Errors;

public static partial class DomainErrors
{
	public static class Contact {

		private static readonly string Base = "Contact";

		public static readonly Error EmailAlreadyInUse = new(
				$"{Base}.EmaiLAlreadyInUse", "The provided email is already in use by a contact");

		public static readonly Error NotFound = new(
			$"{Base}.NotFound", "No contact was found on the given ID");

		public static readonly Error FailedToAdd = new(
			$"{Base}.FailedToAdd", "The contact was not added from the database");

		public static readonly Error FailedToRemove = new(
			$"{Base}.FailedToRemove", "The contact was not removed from the database");
	}
}
