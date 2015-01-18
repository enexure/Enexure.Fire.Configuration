using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Fire.Tests.Configuration.InflateTests
{
	[TestClass]
	public class InflateValueTypeTests
	{
		class Settings
		{
			public short Value { get; set; }
		}

		[TestMethod]
		public void Inflate_With_Valid_Value()
		{
			var settings = Fire.Configuration.Inflate.Instance<Settings>(x => short.MaxValue.ToString());
			settings.Value.Should().Be(short.MaxValue);
		}

		[TestMethod]
		public void Inflate_With_Invalid_Value()
		{
			var settings = Fire.Configuration.Inflate.Instance<Settings>(x => "Something invalid");
			settings.Value.Should().Be(default(short));
		}

		[TestMethod]
		public void Inflate_With_Missing_Value()
		{
			var settings = Fire.Configuration.Inflate.Instance<Settings>(x => null);
			settings.Value.Should().Be(default(short));
		}

	}
}
