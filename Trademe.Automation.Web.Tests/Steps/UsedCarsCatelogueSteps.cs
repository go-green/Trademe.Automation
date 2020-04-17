using FluentAssertions;
using OpenQA.Selenium;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Trademe.Automation.Core.Configuration;
using Trademe.Automation.Core.Contracts.Api;
using Trademe.Automation.Web.Driver;
using Trademe.Automation.Web.Tests.ContextObjects;
using Trademe.Automation.Web.Tests.PageObjects;

namespace Trademe.Automation.Web.Tests.Steps
{
	[Binding]
	public class UsedCarsCatelogueSteps : BaseSteps
	{
		private readonly AdvancedSearchPage _advancedSearchPage;
		private readonly MortorsPage _mortorsPage;
		private readonly ICatelogue _catelogueHttpClient;
		private readonly SearchResultsPage _searchResultsPage;
		private readonly ContextObjectInitializer _contextObjectInitializer;

		public UsedCarsCatelogueSteps(
			IWebDriver webDriver,
			ICatelogue catelogueHttpClient,
			AdvancedSearchPage advancedSearchPage,
			MortorsPage mortorsPage,
			SearchResultsPage searchResultsPage,
			ContextObjectInitializer contextObjectInitializer)
			: base(webDriver)
		{
			_advancedSearchPage = advancedSearchPage;
			_mortorsPage = mortorsPage;
			_searchResultsPage = searchResultsPage;
			_contextObjectInitializer = contextObjectInitializer;
			_catelogueHttpClient = catelogueHttpClient;
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
		public async Task ThenIAmAbleToSeeAListOfVehicleBrands()
		{
			var optionsCount = _advancedSearchPage.AdvancedSearchPanel.GetVehicleBrands().Count();
			optionsCount.Should().BeGreaterThan(0);
			(await _catelogueHttpClient.GetCategories("UsedCars"))
				.Subcategories.Count().Should().Be(optionsCount);
		}


		[Given(@"I have entered '(.*)' into the keyword field")]
		public void GivenIHaveEnteredIntoTheKeywordField(string keyWord)
		{
			_advancedSearchPage.AdvancedSearchPanel.EnterKeyWords(keyWord);
			_contextObjectInitializer.Get<ItemUnderTest>().Brand = keyWord;
		}


		[Given(@"I have left all other filter parameters unchanged")]
		public void GivenIHaveLeftAllOtherFilterParametersUnchanged()
		{
			// Do nothing
		}


		[When(@"I search for vehicles")]
		public void WhenISearchForVehicles()
		{
			_advancedSearchPage.AdvancedSearchPanel.Search();
		}


		[Then(@"I am able to see used vehicles according my filter criteria")]
		public void ThenIAmAbleToSeeUsedVehiclesAccordingMyFilterCriteria()
		{
			var brand = _contextObjectInitializer.Get<ItemUnderTest>().Brand;
			_searchResultsPage.SearchResultsPanel.GetSearchResults()
				.All(result => result.Title.Contains(brand)).Should().Be(true);
		}


		[When(@"I attempt to select brand '(.*)' from the vehicle make drop down menu")]
		public void WhenIAttemptToSelectBrandFromTheVehicleMakeDropDownMenu(string brandname)
		{
			_advancedSearchPage.AdvancedSearchPanel.SelectVehicleBrands();
			_contextObjectInitializer.Get<ItemUnderTest>().Brand = brandname;
		}


		[Then(@"I am unable to see that option available")]
		public void ThenIAmUnableToSeeThatOptionAvailable()
		{
			var brandUnderTest = _contextObjectInitializer.Get<ItemUnderTest>().Brand;
			var availableBrands = _advancedSearchPage.AdvancedSearchPanel.GetVehicleBrands();
			availableBrands.Any(brand => brand.Equals(brandUnderTest)).Should().Be(false);
		}
	}
}
