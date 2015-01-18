using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Configuration.InflateTests
{
	[TestClass]
	public class InflateWithIgnoredPropertiesTests
	{
		class SettingsWithExplititEgnore
		{
			[Fire.Configuration.Ignore]
			public string Value1 { get; set; }

			public string Value2 { get; set; }
		}

		[TestMethod]
		public void Inflate_With_Explicitly_Ingnored_Property()
		{
			var settings = Fire.Configuration.Inflate.Instance<SettingsWithExplititEgnore>(x => "expected");
			
			settings.Value1.Should().Be(default(string));
			settings.Value2.Should().Be("expected");
		}

		class SettingsImplicitIgnore
		{
			public string Value1 {
				get { return string.Empty; }
			}

			public string Value2 { get; set; }
		}

		[TestMethod]
		public void Inflate_With_Implicitly_Ingnored_Property()
		{
			var settings = Fire.Configuration.Inflate.Instance<SettingsImplicitIgnore>(x => "expected");

			settings.Value1.Should().Be(string.Empty);
			settings.Value2.Should().Be("expected");
		}

	}
}
