using FluentAssertions;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Web.Driver;
using Trademe.Automation.Web.Tests.PageObjects;

namespace Trademe.Automation.Web.Tests.Steps
{
	[Binding]
	public class UsedCarsCatelogueSteps : BaseSteps
	{
		private readonly AdvancedSearchPage _advancedSearchPage;
		private readonly MortorsPage _mortorsPage;
		public UsedCarsCatelogueSteps(
			IWebDriver webDriver,
			AdvancedSearchPage advancedSearchPage,
			MortorsPage mortorsPage)
			: base(webDriver)
		{
			_advancedSearchPage = advancedSearchPage;
			_mortorsPage = mortorsPage;
		}

		[Given(@"I have navigated to trademe '(.*)' category")]
		public void GivenIHaveNavigatedToTrade_MeCategory(string category)
		{
			WebDriver.Navigate().GoToUrl($"{Settings.Web.BaseUrl}{category}");
			WebDriver.WaitForPageToLoad(Settings.Web.TimeOut);
			_mortorsPage.VerifyPage().Should().Be(true);
		}

		[Given(@"I have opened the advanced search page")]
		public void GivenIHaveOpenedAdvancedSearchPage()
		{
			_mortorsPage.MortorsFilterPanel.GetAdvancedCarSearchPage()
				.VerifyPage().Should().Be(true);
		}

		[When(@"I select the vehicle make drop down menu")]
		public void WhenISelectTheVehicleMakeDropDownMenu()
		{
			_advancedSearchPage.AdvancedSearchPanel.SelectVehicleBrands();
		}

		[Then(@"I am able to see a list of vehicle brands")]
		public void ThenIAmAbleToSeeAListOfVehicleBrands()
		{
			_advancedSearchPage.AdvancedSearchPanel.GetVehicleBrands()
				.Count().Should().BeGreaterThan(0);
		}
	}
}
