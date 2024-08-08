using VendorService.Domain.Shared;

namespace VendorService.Domain.Errors;

public static partial class DomainErrors
{
	private static readonly string Base = "ProductType";

	public static class ProductType {

		public static readonly Error TypeAlreadyExists = new(
			$"{Base}.TypeAlreadyExists", "The product type already exists for provided supplier");

		public static readonly Error NotFound = new(
			$"{Base}.NotFound", "No supplier was found on the given ID");

		public static readonly Error FailedToAdd = new(
			$"{Base}.FailedToAdd", "The Supplier was not added from the database");

		public static readonly Error FailedToRemove = new(
			$"{Base}.FailedToRemove", "The Supplier was not removed from the database");
	}
}

