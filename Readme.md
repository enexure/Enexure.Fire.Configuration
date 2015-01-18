<<<<<<< HEAD
Enexure.Sql.Dynamic
===================
[![Build status](https://ci.appveyor.com/api/projects/status/1ev9rhfabj5y4jli/branch/master?svg=true)](https://ci.appveyor.com/project/Daniel45729/enexure-sql-dynamic/branch/master)

Dynamic Sql Generation Library

##How to use 
=======
Enexure.Fire.Configuration
==========================
[![Build status](https://ci.appveyor.com/api/projects/status/8wph5o9niqsadqac/branch/master?svg=true)](https://ci.appveyor.com/project/Daniel45729/enexure-fire-configuration/branch/master)

> PM> Install-Package [Enexure.Fire.Configuration](https://www.nuget.org/packages/Enexure.Fire.Configuration/)

Easily load configuration from any key value source.
>>>>>>> Project restructure with appveyor support

Declare your settings  

 
    <appSettings>
		<add key="AppName" value="Some Software" />
		<add key="MaxRetries" value="10" />
	</appSettings>

Create a class for type safe access  

<<<<<<< HEAD
The entire query api is immutable, which means copying and reusing parts of any query is easy.

	var people = new Table("People").As("p");

	var queryBase = Query.From(people);

	var countQuery = queryBase.Select(Field.All.Count())
	var resultsQuery = queryBase.Select(people.All());

## Providers

Once you've constructed your query you need to use a provider to generate the DbCommand and SQL. 
=======
	class Settings
	{
		public string AppName { get; set; }
		public int MaxRetries { get; set; }
	}
>>>>>>> Project restructure with appveyor support

Load the settings, you can use any `Func<string, string>` as the source.

Inflate an instance.

    var settings = Configuration.Inflate.Instance<Settings>(x => SettingsManager.AppSettings[x]);

<<<<<<< HEAD
	select [a].[Id], [b].*
	from [TableA] [a]
	join [TableB] [b] on [a].[Id] = [b].[Fk]
	where [a].[Id] = @p0
=======
Inflate a static class.

	Configuration.Inflate.Static(typeof(Settings), x => values[x]);
>>>>>>> Project restructure with appveyor support
