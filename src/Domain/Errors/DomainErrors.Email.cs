using VendorService.Domain.Shared;

namespace VendorService.Domain.Errors;

public static partial class DomainErrors
{
	public static class Email
	{
		private static readonly string Base = "Email";

		public static Error NullOrEmpty => new($"{Base}.NullOrEmpty", "The email is required");

		public static Error LongerThanAllowed => new($"{Base}.LongerThanAllowed", "The email cannot be longer than 256 characters");

		public static Error InvalidFormat => new($"{Base}.InvalidFormat", "The email format is invalid");
	}
}