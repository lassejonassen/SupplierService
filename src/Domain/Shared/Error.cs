namespace VendorService.Domain.Shared;

public sealed record Error(string Title, string Description)
{
	public static readonly Error None = new(string.Empty, string.Empty);

	public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
}