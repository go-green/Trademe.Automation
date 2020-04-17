using System.Threading.Tasks;
using Trademe.Automation.Core.Dtos;

namespace Trademe.Automation.Core.Contracts.Api
{
	public interface ICatelogue
	{
		/// <summary>
		/// Gets a collection of vehicle categories filtered using a
		/// given categoryName
		/// </summary>
		/// <param name="categoryName"></param>
		/// <returns></returns>
		Task<Category> GetCategories(string categoryName);
	}
}
