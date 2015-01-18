using Enexure.Fire.Configuration;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Configuration.InflateTests
{
	[TestClass]
	public class InflateWithNamedPropertiesTests
	{
		class Settings
		{
			[Named("some-other-name")]
			public string Value { get; set; }
		}

		[TestMethod]
		public void Inflate_With_Valid_Value()
		{
			var settings = Inflate.Instance<Settings>(x => x == "some-other-name" ? "expected" : null );
			
			settings.Value.Should().Be("expected");
		}

	}
}
