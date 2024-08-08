using Carter;

namespace SupplierService.WebApi.Endpoints;

public class ProductModule : CarterModule
{
	public ProductModule()
		: base("/api/products")
	{
		WithTags("Products");
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
	}
}
