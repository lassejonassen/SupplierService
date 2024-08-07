using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SupplierService.Infrastructure.Persistence;

namespace SupplierService.Migrations;

public partial class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		string? assembly = typeof(Program).Assembly.GetName().Name;
		string connectionString = "";

		Parser.Default.ParseArguments<ContextOptions>(args)
				.WithParsed(o => {
					connectionString = o.Connectionstring;
				});

		Console.WriteLine(connectionString);

		var dbContextBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
		dbContextBuilder.UseNpgsql(connectionString, x =>
				x.MigrationsAssembly(assembly));

		return new ApplicationDbContext(dbContextBuilder.Options);
	}
}