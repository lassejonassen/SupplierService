namespace SupplierService.Domain.Enums;

public enum SupplierStatus
{
	Active = 1, // Currently active and supplying goods

	Inactive = 2, // Supplier is currently not supplying any goods, but may be reactived in the future

	PendingApproval = 3, // Registered, but is awating approval to start supplying goods

	Approved = 4, // Approved to supply goods

	Rejected = 5, // Supplier did not meet criteria

	Suspended = 6, // Temporarily halted due to non-compliance or other issues

	Blacklisted = 7, // Permanently barred from supplying any goods, due to severe non-compliance or other serious issues.

	UnderReviewed = 8, // Under revied for performance or complaince issues

	OnHold = 9, // On hold possibly due to internal issues or negotiations

	Terminated = 10, // Contract or relationship has been officially ended.

	New = 11, // A newly registered supplier that has not yet supplied any goods.

	Preferred = 12, // The supplier is considered a preferred or strategic partner.

	Conditional = 13, // The supplier is approved under certain conditions that need to be met.

	Deactivated = 14, // Previously active but has been deactivated and cannot supply goods until reactivated.

	Probation = 15, // The supplier is under a probationary period due to previous issues.

	Limited = 16, // The supplier is allowed to supply only certain types or quantities of goods.

	HighRisk = 17, // The supplier is identified as high risk due to various factors like financial instability or past performance issues.
}
