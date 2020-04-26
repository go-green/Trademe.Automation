using BoDi;
using OpenQA.Selenium;
using Serilog;
using TechTalk.SpecFlow;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Core.Contracts.Api;
using Trademe.Automation.Core.DiContainer;
using Trademe.Automation.Core.HttpClients;
using Trademe.Automation.Web.Driver;

namespace Trademe.Automation.Web.Tests.Hooks
{
	[Binding]
	public class BeforeAfterScenario
	{
		private IWebDriver _webDriver;
		private readonly IObjectContainer _objectContainer;

		public BeforeAfterScenario(IObjectContainer objectContainer)
		{
			_objectContainer = objectContainer;
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			RegisterWebDriver();
			RegisterApiClients();
			_webDriver.Manage().Window.Maximize();
		}

		private void RegisterApiClients()
		{
			_objectContainer.RegisterTypeAs<CatalogueHttpClient, ICatelogue>();
			_objectContainer.RegisterTypeAs<RestClientBase, IRestClientBase>();
			_objectContainer.RegisterInstanceAs<ILogger>(DependencyInjector.InitializeLogger());
		}

		private void RegisterWebDriver()
		{
			_webDriver = new WebDriverFactory().Create(Settings.Web.TargetBrowser, Settings.Web.SeleniumGrid);
			_objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
		}

		[AfterScenario]
		public void AfterScenario()
		{
			_webDriver.Quit();
			_webDriver.Dispose();
		}
	}
}
