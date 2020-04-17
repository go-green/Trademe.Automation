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
			return VehicleMake.Options.Select(brand => brand.Text);
		}

		public void SelectVehicleBrands()
		{
			WebDriver.WaitUntilElementLoads(VehicleMakeElement, Settings.Web.TimeOut);
			VehicleMakeElement.Click();
		}

		private readonly By _searchPanelContainer = By.CssSelector("#mainContent");

		private readonly By _vehicleMakeSelector = By.CssSelector("#form_make");
		private IWebElement PanelContainer => WebDriver.FindElement(_searchPanelContainer);
		private IWebElement VehicleMakeElement => PanelContainer.FindElement(_vehicleMakeSelector);
		private SelectElement VehicleMake => new SelectElement(VehicleMakeElement);
	}
}
