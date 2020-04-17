using Serilog;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Core.Contracts.Api;

namespace Trademe.Automation.Core.HttpClients
{
	public class HttpClientBase
	{
		protected readonly IRestClientBase RestClientBase;
		protected readonly ILogger Logger;
		protected string Version => Settings.Api.Version;
		protected string Json = "Json";

		public HttpClientBase(
			IRestClientBase restClientBase,
			ILogger logger)
		{
			RestClientBase = restClientBase;
			Logger = logger;
		}
	}
}
