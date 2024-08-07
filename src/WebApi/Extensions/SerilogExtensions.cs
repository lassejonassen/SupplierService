using Serilog;

namespace SupplierService.WebApi.Extensions;

public static class SerilogExtensions
{
	public const string SectionName = "AppSettings:Serilog";

	public static void AddSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
	{
		hostBuilder.UseSerilog((context, loggerConfig) =>
			loggerConfig.ReadFrom.Configuration(configuration.GetSection(SectionName)));
	}
}
