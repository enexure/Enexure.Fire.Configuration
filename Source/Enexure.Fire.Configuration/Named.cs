using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enexure.Fire.Configuration
{
	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class Named : Attribute
	{
		private readonly string name;

		public Named(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get { return name; }
		}
	}
}
