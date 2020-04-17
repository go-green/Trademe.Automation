using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Trademe.Automation.Core.Configuration;
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
			InitializeWebDriver();
			_webDriver.Manage().Window.Maximize();
		}

		private void InitializeWebDriver()
		{
			_webDriver = new WebDriverFactory().Create(Settings.Web.TargetBrowser);
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
