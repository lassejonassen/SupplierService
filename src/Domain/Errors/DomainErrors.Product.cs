using VendorService.Domain.Shared;

namespace VendorService.Domain.Errors;

public static partial class DomainErrors
{
	public static class Product
	{

		private static readonly string Base = "Product";

		public static readonly Error NotFound = new(
			$"{Base}.NotFound", "No contact was found on the given ID");

		public static readonly Error FailedToAdd = new(
			$"{Base}.FailedToAdd", "The contact was not added from the database");

		public static readonly Error FailedToRemove = new(
			$"{Base}.FailedToRemove", "The contact was not removed from the database");
	}
}

