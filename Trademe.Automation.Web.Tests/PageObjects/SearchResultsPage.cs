using OpenQA.Selenium;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class SearchResultsPage : BasePage
	{
		public SearchResultsPage(IWebDriver webDriver) : base(webDriver)
		{
			PageTitleText = "Motors search results - Find vehicles on Trade Me Motors";
		}

		public SearchResultsPanel SearchResultsPanel => new SearchResultsPanel(WebDriver);
	}
}
