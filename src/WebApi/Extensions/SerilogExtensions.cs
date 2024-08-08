using Serilog;
using Serilog.Settings.Configuration;

namespace VendorService.WebApi.Extensions;

public static class SerilogExtensions
{
	public const string SectionName = "AppSettings:Serilog";

	public static void AddSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
	{
		var serilogSettings = configuration.GetSection(SectionName);

		var options = new ConfigurationReaderOptions { SectionName = SectionName };

		hostBuilder.UseSerilog((context, loggerConfig) =>
			loggerConfig.ReadFrom.Configuration(configuration, options));
	}
}
