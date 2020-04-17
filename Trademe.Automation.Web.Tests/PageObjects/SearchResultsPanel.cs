using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Web.Driver;
using Trademe.Automation.Web.Tests.DataModels;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class SearchResultsPanel : PageComponent
	{
		public SearchResultsPanel(IWebDriver webDriver) : base(webDriver)
		{
		}

		public IEnumerable<SearchResultTile> GetSearchResults()
		{
			WebDriver.WaitUntilElementLoads(_searchResultsPanelContainerSelector, Settings.Web.TimeOut);
			return SearchResultTiles.Select(tile => new SearchResultTile
			{
				Title = tile.FindElement(_searchResultTileSelector).Text
			});
		}

		private readonly By _searchResultsPanelContainerSelector = By.CssSelector("ul.list-view-list");

		private readonly By _searchResultsTileSelector = By.CssSelector("div.tmm-search-card-list-view__card");

		private readonly By _searchResultTileSelector = By.CssSelector("div.tmm-search-card-list-view__title");

		private IWebElement SearchResultsPanelContainer => WebDriver.FindElement(_searchResultsPanelContainerSelector);

		private IEnumerable<IWebElement> SearchResultTiles =>
			SearchResultsPanelContainer.FindElements(_searchResultsTileSelector);
	}
}
