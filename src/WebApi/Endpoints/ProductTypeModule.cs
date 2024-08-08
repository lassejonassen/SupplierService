using Carter;
using VendorService.Application.ProductTypes.Commands.CreateProductType;
using VendorService.Application.ProductTypes.Commands.DeleteProductType;
using VendorService.Application.ProductTypes.Commands.UpdateProductType;
using VendorService.Application.ProductTypes.Queries.GetAllProductTypes;
using VendorService.Application.ProductTypes.Queries.GetProductTypeById;
using MediatR;

namespace VendorService.WebApi.Endpoints;

public class ProductTypeModule : CarterModule
{

	public ProductTypeModule()
		: base("/api/product-types")
	{
		WithTags("Product Types");
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/", async (CreateProductTypeCommand command, ISender sender) => {
			var result = await sender.Send(command);

			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/", async (ISender sender) => {
			var result = await sender.Send(new GetAllProductTypesQuery());
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new GetProductTypeByIdQuery(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapPatch("/", async (UpdateProductTypeCommand command, ISender sender) => {
			var result = await sender.Send(command);
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok();
		});

		app.MapDelete("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new DeleteProductTypeCommand(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok();
		});
	}
}
