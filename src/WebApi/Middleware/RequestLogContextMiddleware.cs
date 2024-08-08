using Serilog.Context;

namespace VendorService.WebApi.SupplierService.WebApi.Middleware;

public class RequestLogContextMiddleware
{
	private readonly RequestDelegate _next;

	public RequestLogContextMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
		{
			await _next(context);
		}
	}
}
