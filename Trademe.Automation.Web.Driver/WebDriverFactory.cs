using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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
				case "Remote":
					return new RemoteWebDriver(new Uri("http://seleniumhub:4444/wd/hub"),
						new ChromeOptions().ToCapabilities());
				default:
					throw new InvalidOperationException($"Target browser {key} is not supported");
			}
		}
	}
}
