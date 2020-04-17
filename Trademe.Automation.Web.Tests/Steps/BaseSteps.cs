using OpenQA.Selenium;

namespace Trademe.Automation.Web.Tests.Steps
{
	public class BaseSteps : TechTalk.SpecFlow.Steps
	{
		protected readonly IWebDriver WebDriver;
		public BaseSteps(IWebDriver webDriver)
		{
			WebDriver = webDriver;
		}
	}
}
