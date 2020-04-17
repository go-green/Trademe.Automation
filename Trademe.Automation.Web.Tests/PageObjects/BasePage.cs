using OpenQA.Selenium;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class BasePage
	{
		protected readonly IWebDriver WebDriver;

		public BasePage(IWebDriver webDriver)
		{
			WebDriver = webDriver;
		}
		public virtual bool VerifyPage()
		{
			return WebDriver.Title.Equals(PageTitleText);
		}
		public string PageTitleText { get; set; }
	}
}
