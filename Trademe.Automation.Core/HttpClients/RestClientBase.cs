using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Core.Contracts.Api;

namespace Trademe.Automation.Core.HttpClients
{
	public class RestClientBase : IRestClientBase
	{
		private readonly HttpClient _httpClient;

		public RestClientBase()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(Settings.Api.BaseUrl)
			};
		}

		public async Task<HttpResponseMessage> GetAsync(string endpoint, IDictionary<string, string> headers)
		{
			var message = new HttpRequestMessage(HttpMethod.Get,
				$"{_httpClient.BaseAddress.AbsoluteUri}{endpoint}");
			AddHeaderToMessage(message, headers);
			var response = await SendAsync(message);
			return response;
		}

		public Task<HttpResponseMessage> PostAsync(string endpoint, IDictionary<string, string> headers)
		{
			throw new NotImplementedException();
		}

		public Task<HttpResponseMessage> DeleteAsync(string endpoint, IDictionary<string, string> headers)
		{
			throw new NotImplementedException();
		}

		public Task<HttpResponseMessage> PutAsync(string endpoint, IDictionary<string, string> headers)
		{
			throw new NotImplementedException();
		}

		private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
		{
			ClearHeader();
			var httpResult = await _httpClient.SendAsync(request);
			return httpResult;
		}

		private static void AddHeaderToMessage(HttpRequestMessage message, IDictionary<string, string> headers)
		{
			if (headers == null)
				return;
			foreach (var keyValuePair in headers)
				message.Headers.Add(keyValuePair.Key, keyValuePair.Value);
		}

		private void ClearHeader()
		{
			_httpClient.DefaultRequestHeaders.Clear();
		}
	}
}
