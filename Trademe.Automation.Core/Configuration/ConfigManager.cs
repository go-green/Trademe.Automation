using Microsoft.Extensions.Configuration;
using System.IO;

namespace Trademe.Automation.Core.Configuration
{
	public class ConfigManager
	{
		public string GetSetting(string settingName, string domain)
		{
			return GetFromAppSettings(settingName, domain);
		}

		private string GetFromAppSettings(string settingName, string domain)
		{
			var config = InitializeConfiguration(domain);
			return config[settingName];
		}

		private static IConfigurationRoot InitializeConfiguration(string domain)
		{
			var configBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile($"{domain}.appsettings.json");
			var config = configBuilder.Build();
			return config;
		}
	}
}
