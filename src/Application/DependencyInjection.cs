using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VendorService.Application.Abstractions.Behavior;

namespace VendorService.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		var assembly = typeof(DependencyInjection).Assembly;

		services.AddMediatR(configuration => {
			configuration.RegisterServicesFromAssembly(assembly);
			configuration.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
		});
		services.AddValidatorsFromAssembly(assembly);

		return services;
	}
}
