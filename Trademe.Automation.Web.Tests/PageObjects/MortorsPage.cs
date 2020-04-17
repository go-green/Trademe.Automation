using OpenQA.Selenium;

namespace Trademe.Automation.Web.Tests.PageObjects
{
	public class MortorsPage : BasePage
	{
		public MortorsPage(IWebDriver webDriver)
			: base(webDriver)
		{
			PageTitleText = "Selling a car or browse Utes, Caravans and more |Trade Me Motors";
		}
		public FilterPanel MortorsFilterPanel => new FilterPanel(WebDriver);
	}
}
