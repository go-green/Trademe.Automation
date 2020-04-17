using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Web.Driver;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class AdvancedSearchPanel : PageComponent
	{
		public AdvancedSearchPanel(IWebDriver webDriver) : base(webDriver)
		{
		}

		public IEnumerable<string> GetVehicleBrands()
		{
			WebDriver.WaitUntilElementLoads(VehicleMakeElement, Settings.Web.TimeOut);
			return VehicleMake.Options
				.Where(brand => !brand.Text.Equals("Any make"))
				.Select(brand => brand.Text);
		}

		public void SelectVehicleBrands()
		{
			WebDriver.WaitUntilElementLoads(VehicleMakeElement, Settings.Web.TimeOut);
			VehicleMakeElement.Click();
		}

		public void SelectOption(string brandname)
		{
			WebDriver.WaitUntilElementLoads(VehicleMakeElement, Settings.Web.TimeOut);
			VehicleMake.SelectByText(brandname);
		}

		public void Search()
		{
			WebDriver.WaitUntilElementLoads(SearchButton, Settings.Web.TimeOut);
			SearchButton.Click();
			WebDriver.WaitForPageToLoad(new SearchResultsPage(WebDriver).PageTitleText, Settings.Web.TimeOut);
		}

		public void EnterKeyWords(string keyWords)
		{
			WebDriver.WaitUntilElementLoads(KeyWordField, Settings.Web.TimeOut);
			KeyWordField.SendKeys(keyWords);
		}

		private readonly By _searchPanelContainer = By.CssSelector("#mainContent");

		private readonly By _vehicleMakeSelector = By.CssSelector("#form_make");

		private readonly By _keyWordSelector = By.CssSelector("#Keyword");

		private readonly By _searchSelector = By.CssSelector("#MotorsAdvancedSearchButton");

		private IWebElement PanelContainer => WebDriver.FindElement(_searchPanelContainer);

		private IWebElement VehicleMakeElement => PanelContainer.FindElement(_vehicleMakeSelector);

		private IWebElement KeyWordField => PanelContainer.FindElement(_keyWordSelector);

		private IWebElement SearchButton => PanelContainer.FindElement(_searchSelector);

		private SelectElement VehicleMake => new SelectElement(VehicleMakeElement);
	}
}
