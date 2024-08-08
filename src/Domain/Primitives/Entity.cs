namespace VendorService.Domain.Primitives;


/// <summary>
/// Represents the base class that all entities derive from.
/// </summary>
public abstract record Entity
{
	public required Guid Id { get; set; }
	public required DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset? UpdatedAt { get; set; }
	public required Guid CorrelationId { get; set; }
}
