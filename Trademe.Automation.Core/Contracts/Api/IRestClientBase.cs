using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Trademe.Automation.Core.Contracts.Api
{
	public interface IRestClientBase
	{
		Task<HttpResponseMessage> GetAsync(string endpoint, IDictionary<string, string> headers);
		Task<HttpResponseMessage> PostAsync(string endpoint, IDictionary<string, string> headers);
		Task<HttpResponseMessage> DeleteAsync(string endpoint, IDictionary<string, string> headers);
		Task<HttpResponseMessage> PutAsync(string endpoint, IDictionary<string, string> headers);
	}
}
