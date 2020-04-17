using Serilog;
using Serilog.Events;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Trademe.Automation.Core.Contracts.Api;
using Trademe.Automation.Core.DataModels;

namespace Trademe.Automation.Core.HttpClients
{
	public class CatalogueHttpClient : HttpClientBase, ICatelogue
	{
		public CatalogueHttpClient(
			IRestClientBase restClientBase,
			ILogger logger)
			: base(restClientBase, logger)
		{
		}

		public async Task<Category> GetCategories(string categoryName)
		{
			var endPoint = $"v{Version}/Categories/{categoryName}.{Json}?with_counts=true";
			return await GetAsync<Category>(endPoint);
		}

		private async Task<T> GetAsync<T>(string endPoint)
		{
			HttpResponseMessage response;
			try
			{
				response = await RestClientBase.GetAsync(endPoint, null);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception e)
			{
				var errorMessage = $"Request to service end point '{endPoint}' failed. \n {e.Message}";
				Logger.Write(LogEventLevel.Error, e.InnerException, errorMessage);
				throw new HttpRequestException(errorMessage, e.InnerException);
			}
			return await response.Content.ReadAsAsync<T>();
		}
	}
}
