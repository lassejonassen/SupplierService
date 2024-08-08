using VendorService.Domain.Shared;

namespace VendorService.Domain.Errors;

public static partial class DomainErrors
{
	public static class Vendor
	{
		private static readonly string Base = "Vendor";

		public static readonly Error NameAlreadyExists = new(
			$"{Base}.NameAlreadyExists", "A Vendor with the given name already exists");

		public static readonly Error EmailAlreadyInUse = new(
			$"{Base}.EmaiLAlreadyInUse", "The provided email is already in use by a vendor");

		public static readonly Error NotFound = new(
			$"{Base}.NotFound", "No vendor was found on the given ID");

		public static readonly Error FailedToAdd = new(
			$"{Base}.FailedToAdd", "The vendor was not added from the database");

		public static readonly Error FailedToRemove = new(
			$"{Base}.FailedToRemove", "The vendor was not removed from the database");
	}
}
