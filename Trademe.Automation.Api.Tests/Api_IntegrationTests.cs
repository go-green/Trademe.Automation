using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trademe.Automation.Core.Contracts.Api;
using Trademe.Automation.Core.DiContainer;

namespace Tests
{
	public class Api_IntegrationTests
	{
		private IServiceProvider _serviceProvider;
		private ICatelogue _catelogueHttpClient;

		[SetUp]
		public void Setup()
		{
			// Arrange
			_serviceProvider = DependencyInjector.GetServiceProvider();
			_catelogueHttpClient = _serviceProvider.GetService<ICatelogue>();
		}

		[Test]
		public async Task Test_the_count_of_named_brands_of_used_cars()
		{
			// Act
			var usedCars = await _catelogueHttpClient.GetCategories("UsedCars");

			// Assert
			usedCars.Subcategories.Count(cat => !string.IsNullOrEmpty(cat.Name)).Should().Be(76);
		}

		[Test]
		public async Task Test_the_current_count_of_Kia_used_cars()
		{
			// Act
			var usedCars = await _catelogueHttpClient.GetCategories("UsedCars");

			// Assert
			usedCars.Subcategories.FirstOrDefault(cat => cat.Name.Equals("Kia")).Should().NotBe(null);
			usedCars.Subcategories.First(cat => cat.Name.Equals("Kia")).Count.Should().Be(1195);
		}

		[Test]
		public async Task Test_that_brand_Hispano_Suiza_does_not_exist_in_used_cars()
		{
			// Act
			var usedCars = await _catelogueHttpClient.GetCategories("UsedCars");

			// Assert
			usedCars.Subcategories.FirstOrDefault(cat => cat.Name.Equals("Hispano Suiza")).Should().Be(null);
		}


		[TearDown]
		public void TearDown()
		{
		}

		// Only GetAsync was implemented as no other HTTP verbs were required to achieve the given task
		// No attempts were made to implement bearer token acquisition to authenticate the request as its was not required
	}
}