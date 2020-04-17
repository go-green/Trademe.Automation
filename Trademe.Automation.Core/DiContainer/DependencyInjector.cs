using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using System;
using Trademe.Automation.Core.Contracts.Api;
using Trademe.Automation.Core.HttpClients;

namespace Trademe.Automation.Core.DiContainer
{
	/// <summary>
	/// DI Container for API tests
	/// </summary>
	public class DependencyInjector
	{
		public static IServiceProvider GetServiceProvider()
		{
			var logger = InitializeLogger();
			var services = new ServiceCollection();
			services.AddSingleton(typeof(ICatelogue), typeof(CatalogueHttpClient));
			services.AddSingleton(typeof(IRestClientBase), typeof(RestClientBase));
			services.AddSingleton(typeof(ILogger), logger);
			return services.BuildServiceProvider();
		}

		public static ILogger InitializeLogger()
		{
			return new LoggerConfiguration()
				.MinimumLevel.Debug()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.Enrich.FromLogContext()
				.WriteTo.File(new CompactJsonFormatter(), $"logs/log.txt")
				.CreateLogger();
		}
	}
}
