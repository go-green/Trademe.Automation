using OpenQA.Selenium;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Web.Driver;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class FilterPanel : PageComponent
	{
		public FilterPanel(IWebDriver webDriver) : base(webDriver)
		{
		}

		public AdvancedSearchPage GetAdvancedCarSearchPage()
		{
			WebDriver.WaitUntilElementLoads(AdvancedCarSearch, Settings.Web.TimeOut);
			AdvancedCarSearch.Click();
			var searchPage = new AdvancedSearchPage(WebDriver);
			WebDriver.WaitForPageToLoad(searchPage.PageTitleText, Settings.Web.TimeOut);
			return searchPage;
		}

		private readonly By _panelContainerLocater = By.CssSelector("div.attribute-search-motors");

		private readonly By _advancedCarSearchLocater = By.CssSelector("#AdvancedCarSearchLink");
		private IWebElement PanelContainer => WebDriver.FindElement(_panelContainerLocater);
		private IWebElement AdvancedCarSearch => PanelContainer.FindElement(_advancedCarSearchLocater);
	}
}
