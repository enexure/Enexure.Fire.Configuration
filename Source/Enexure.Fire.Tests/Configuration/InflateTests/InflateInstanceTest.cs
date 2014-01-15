using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Configuration.InflateTests
{
	[TestClass]
	public class InflateInstance
	{
		class Settings
		{
			public string Aplha { get; set; }
		}

		[TestMethod]
		public void Inflate_Instance()
		{
			var values = new Dictionary<string, string>() {
				{ "Aplha", "Value1" },
			};

			var settings = Fire.Configuration.Inflate.Instance<Settings>(x => values[x]);

			settings.Aplha.Should().Be("Value1");
		}

	}
}
