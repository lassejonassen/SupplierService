using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace VendorService.WebApi.SupplierService.WebApi.Extensions;

public static class AzureAppConfiguration
{
	public const string SectionName = "AppSettings:ConnectionStrings:AppConfig";
	public const string Label = "VendorService";

	public static void AddAppConfiguration(this IConfigurationBuilder configurationBuilder, IConfiguration configuration)
	{
		string? appConfigConnectionString = configuration.GetSection(SectionName).Value;

		if (appConfigConnectionString is not null)
		{
			Console.WriteLine("Using Azure App Configuration");
			configurationBuilder.AddAzureAppConfiguration(options => {
				options.Connect(appConfigConnectionString)
					.Select(KeyFilter.Any, "Shared")
					.Select(KeyFilter.Any, Label);
			});
		}
	}
}
