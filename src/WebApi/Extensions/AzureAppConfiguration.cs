using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace SupplierService.WebApi.Extensions;

public static class AzureAppConfiguration
{
	public const string SectionName = "AppSettings:ConnectionStrings:AppConfig";
	public const string Label = "SupplierService";

	public static void AddAppConfiguration(this IConfigurationBuilder configurationBuilder, IConfiguration configuration)
	{
		string? appConfigConnectionString = configuration.GetSection(SectionName).Value;

		if (appConfigConnectionString is not null)
		{
			Console.WriteLine("Using Azure App Configuration");
			configurationBuilder.AddAzureAppConfiguration(options => {
				options.Connect(appConfigConnectionString)
					.Select(KeyFilter.Any, LabelFilter.Null)
					.Select(KeyFilter.Any, Label);
			});
		}
	}
}
