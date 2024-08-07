using Microsoft.EntityFrameworkCore;
using SupplierService.Migrations;

var factory = new DbContextFactory();
var db = factory.CreateDbContext(args);
db.Database.SetCommandTimeout(TimeSpan.FromMinutes(2));
if (db.Database.GetMigrations().Any())
{
	try
	{
		Console.WriteLine("Starting Migrations");
		await db.Database.MigrateAsync();
	}
	catch (Exception e)
	{
		Console.WriteLine(e);
		throw;
	}
}
else
{
	Console.WriteLine("No migrations");
}

Console.WriteLine("Migrations done");
return 0;
