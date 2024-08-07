using SupplierService.Domain.Shared;

namespace SupplierService.Domain.Errors;

public static partial class DomainErrors
{
	public static class Supplier
	{
		private static readonly string Base = "Supplier";

		public static readonly Error NameAlreadyExists = new(
			$"{Base}.NameAlreadyExists", "A Supplier with the given name already exists");

		public static readonly Error EmailAlreadyInUse = new(
			$"{Base}.EmaiLAlreadyInUse", "The provided email is already in use by a supplier");

		public static readonly Error NotFound = new(
			$"{Base}.NotFound", "No supplier was found on the given ID");

		public static readonly Error FailedToAdd = new(
			$"{Base}.FailedToAdd", "The Supplier was not added from the database");

		public static readonly Error FailedToRemove = new(
			$"{Base}.FailedToRemove", "The Supplier was not removed from the database");
	}
}
