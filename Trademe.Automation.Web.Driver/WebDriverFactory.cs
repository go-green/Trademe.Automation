using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Trademe.Automation.Web.Driver
{
	public class WebDriverFactory
	{
		public IWebDriver Create(string key)
		{
			switch (key)
			{
				case "Chrome":
					return new ChromeDriver(Directory.GetCurrentDirectory());
				default:
					throw new InvalidOperationException($"Target browser {key} is not supported");
			}
		}
	}
}
