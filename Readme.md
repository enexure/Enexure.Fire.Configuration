Enexure.Fire.Configuration
==========================
[![Build status](https://ci.appveyor.com/api/projects/status/8wph5o9niqsadqac/branch/master?svg=true)](https://ci.appveyor.com/project/Daniel45729/enexure-fire-configuration/branch/master)


Easily load configuration from any key value source.

Declare your settings

	<appSettings>
		<add key="AppName" value="Some Software" />
		<add key="MaxRetries" value="10" />
	</appSettings>

Create a class for type safe access

	class Settings
	{
		public string AppName { get; set; }
		public int MaxRetries { get; set; }
	}
	
Load the settings, you can use any `Func<string, string>` as the source.

Inflate an instance.

	var settings = Configuration.Inflate.Instance<Settings>(x => SettingsManager.AppSettings[x]);
	
Inflate a static class.

	Configuration.Inflate.Static(typeof(Settings), x => values[x]);