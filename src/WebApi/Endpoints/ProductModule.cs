using Carter;
using MediatR;
using SupplierService.Application.Products.Commands.CreateProduct;
using SupplierService.Application.Products.Commands.DeleteProduct;
using SupplierService.Application.Products.Commands.UpdateProduct;
using SupplierService.Application.Products.Commands.UpdateProductProductType;
using SupplierService.Application.Products.Commands.UpdateProductSKU;
using SupplierService.Application.Products.Commands.UpdateProductSupplier;
using SupplierService.Application.Products.Queries.GetAllProducts;
using SupplierService.Application.Products.Queries.GetProductById;
using SupplierService.Application.Products.Queries.GetProductsByProductTypeId;
using SupplierService.Application.Products.Queries.GetProductsBySupplierId;

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
		app.MapPost("/", async (CreateProductCommand command, ISender sender) => {
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
			var result = await sender.Send(new GetAllProductsQuery());
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
			var result = await sender.Send(new GetProductByIdQuery(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/supplier/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new GetProductsBySupplierIdQuery(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/type/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new GetProductsByProductTypeIdQuery(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapPatch("/", async (UpdateProductCommand command, ISender sender) => {
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

		app.MapPatch("/product-type", async (UpdateProductProductTypeCommand command, ISender sender) => {
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

		app.MapPatch("/sku", async (UpdateProductSKUCommand command, ISender sender) => {
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

		app.MapPatch("/supplier", async (UpdateProductSupplierCommand command, ISender sender) => {
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
			var result = await sender.Send(new DeleteProductCommand(id));
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
