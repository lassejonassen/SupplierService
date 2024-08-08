using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace VendorService.Infrastructure.Options;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
	private const string ConfigurationSectionName = "AppSettings:DatabaseOptions";
	private const string ConnectionStringSectionName = "AppSettings:ConnectionStrings:Database";
	private readonly IConfiguration _configuration;

	public DatabaseOptionsSetup(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public void Configure(DatabaseOptions options)
	{
		string connectionString = _configuration.GetSection(ConnectionStringSectionName).Value
			?? throw new Exception("Database connection string is missing from configuration.");

		options.ConnectionString = connectionString;

		_configuration.GetSection(ConfigurationSectionName).Bind(options);
	}
}