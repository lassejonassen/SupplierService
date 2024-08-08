using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace VendorService.WebApi.SupplierService.WebApi.Middleware;

public class GlobalExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

	public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (NotImplementedException ex)
		{
			_logger.LogError(ex, ex.Message);

			context.Response.StatusCode = StatusCodes.Status500InternalServerError;

			ProblemDetails problem = new() {
				Status = StatusCodes.Status501NotImplemented,
				Type = "Not Implemented",
				Title = "Action not implemented",
				Detail = "The requested action is not implemented",
			};

			string json = JsonSerializer.Serialize(problem);

			context.Response.ContentType = "application/json";

			await context.Response.WriteAsync(json);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);

			context.Response.StatusCode = StatusCodes.Status500InternalServerError;

			ProblemDetails problem = new() {
				Status = StatusCodes.Status500InternalServerError,
				Type = "Server Error",
				Title = "Server Error",
				Detail = "An internal server error occurred",
			};

			string json = JsonSerializer.Serialize(problem);

			context.Response.ContentType = "application/json";

			await context.Response.WriteAsync(json);
		}
	}
}
