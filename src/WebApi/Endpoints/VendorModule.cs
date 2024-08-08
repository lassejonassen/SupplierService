using Carter;
using MediatR;
using VendorService.Application.Vendors.Commands.CreateVendor;
using VendorService.Application.Vendors.Commands.DeleteVendor;
using VendorService.Application.Vendors.Queries.GetAllVendors;
using VendorService.Application.Vendors.Queries.GetVendorById;

namespace VendorService.WebApi.SupplierService.WebApi.Endpoints;

public class VendorModule : CarterModule
{
	public VendorModule()
		: base("/api/vendors")
	{
		WithTags("vendors");
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/", async (CreateVendorCommand command, ISender sender) => {
			var result = await sender.Send(command);

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/", async (ISender sender) => {
			var result = await sender.Send(new GetAllVendorsQuery());

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new GetVendorByIdQuery(id));

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapDelete("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new DeleteVendorCommand(id));

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok();
		});
	}
}
