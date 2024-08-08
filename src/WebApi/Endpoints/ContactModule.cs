using Carter;
using MediatR;
using VendorService.Application.Contacts.Commands.CreateContact;
using VendorService.Application.Contacts.Commands.DeleteContact;
using VendorService.Application.Contacts.Commands.UpdateContact;
using VendorService.Application.Contacts.Queries.GetAllContacts;
using VendorService.Application.Contacts.Queries.GetContactById;
using VendorService.Application.Contacts.Queries.GetContactBySupplierId;

namespace VendorService.WebApi.Endpoints;

public class ContactModule : CarterModule
{
	public ContactModule()
		: base("/api/contacts")
	{
		WithTags("Contacts");
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/", async (CreateContactCommand command, ISender sender) => {
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
			var result = await sender.Send(new GetAllContactsQuery());
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
			var result = await sender.Send(new GetContactByIdQuery(id));
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
			var result = await sender.Send(new GetContactBySupplierIdQuery(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapPatch("/", async (UpdateContactCommand command, ISender sender) => {
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
			var result = await sender.Send(new DeleteContactCommand(id));
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
