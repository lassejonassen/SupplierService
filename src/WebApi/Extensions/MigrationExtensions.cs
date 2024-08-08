using Microsoft.EntityFrameworkCore;
using VendorService.Infrastructure.SupplierService.Infrastructure.Persistence;

namespace VendorService.WebApi.SupplierService.WebApi.Extensions;

public static class MigrationExtensions
{
	// Extension method can be used to apply any migrations to the database, should docker compose not be used.
	public static void ApplyMigrations(this IApplicationBuilder app)
	{
		using IServiceScope scope = app.ApplicationServices.CreateScope();

		using ApplicationDbContext dbContext
			= scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

		dbContext.Database.Migrate();
	}
}
