using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Configuration.InflateTests
{
	[TestClass]
	public class InflateStaticTest
	{
		static class Settings
		{
			public static string Aplha { get; set; }
		}

		[TestMethod]
		public void Inflate_Static()
		{
			var values = new Dictionary<string, string>() {
				{ "Aplha", "Value1" },
			};

			Fire.Configuration.Inflate.Static(typeof(Settings), x => values[x]);

			Settings.Aplha.Should().Be("Value1");
		}
	}
}
