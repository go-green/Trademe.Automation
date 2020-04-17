using OpenQA.Selenium;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class PageComponent
	{
		protected readonly IWebDriver WebDriver;

		public PageComponent(IWebDriver webDriver)
		{
			WebDriver = webDriver;
		}
	}
}
