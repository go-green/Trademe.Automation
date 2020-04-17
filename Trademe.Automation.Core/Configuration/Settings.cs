using System;

namespace Trademe.Automation.Core.Configuration
{
	public class Settings
	{
		public static class Api
		{
			private const string Domain = "Api";
			public static string BaseUrl => GetConfigManager().GetSetting($"{Domain}:BaseUrl");
			public static string Version => GetConfigManager().GetSetting($"{Domain}:Version");
		}
		public static class Web
		{
			private const string Domain = "Web";
			public static string BaseUrl => GetConfigManager().GetSetting($"{Domain}:BaseUrl");
			public static string TargetBrowser => GetConfigManager().GetSetting($"{Domain}:Target");
			public static TimeSpan TimeOut =>
				new TimeSpan(0, 0, Convert.ToInt16(GetConfigManager().GetSetting($"{Domain}:TimeOut")));
		}

		private static ConfigManager GetConfigManager()
		{
			return new ConfigManager();
		}
	}
}
