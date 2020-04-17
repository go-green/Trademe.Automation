using OpenQA.Selenium;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class AdvancedSearchPage : BasePage
	{
		public AdvancedSearchPage(IWebDriver webDriver) : base(webDriver)
		{
			PageTitleText = "Trade Me - New Zealand Online Auctions and Classifieds";
		}

		public AdvancedSearchPanel AdvancedSearchPanel => new AdvancedSearchPanel(WebDriver);
	}
}
