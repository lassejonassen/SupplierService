﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VendorService.Domain.Repositories;
using VendorService.Infrastructure.SupplierService.Infrastructure.Persistence;
using VendorService.Infrastructure.SupplierService.Infrastructure.Options;
using VendorService.Infrastructure.SupplierService.Infrastructure.Persistence.Repositories;

namespace VendorService.Infrastructure.SupplierService.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddPersistence(configuration);
		return services;
	}

	private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.ConfigureOptions<DatabaseOptionsSetup>();

		services.AddDbContext<ApplicationDbContext>(
			(serviceProvider, dbContextOptionsBuilder) => {
				var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;


				dbContextOptionsBuilder.UseNpgsql(databaseOptions.ConnectionString, action => {
					action.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
					action.CommandTimeout(databaseOptions.CommandTimeout);
				});
				dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
				dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
			});


		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
		services.AddScoped<IVendorRepository, SupplierRepository>();
		services.AddScoped<IContactRepository, ContactRepository>();

		return services;
	}
}
