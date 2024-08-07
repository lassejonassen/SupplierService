using CommandLine;

namespace SupplierService.Migrations;

public partial class DbContextFactory
{
	public class ContextOptions
	{
		[Option('c', "connectionstring", Required = false, HelpText = "Full connection string.")]
		public string Connectionstring { get; set; } =
				"Host=supplierservice.database;Port=5432;Database=supplierdb;Username=postgres;Password=postgres;Include Error Detail=true";
	}
}