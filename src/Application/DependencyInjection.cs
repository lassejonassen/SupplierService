using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SupplierService.Application.Abstractions.Behavior;

namespace SupplierService.Application;

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
