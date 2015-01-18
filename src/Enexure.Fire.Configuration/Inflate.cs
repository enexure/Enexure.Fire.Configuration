using System;
using System.Linq;
using System.Reflection;
using Enexure.Fire.Conversion;

namespace Enexure.Fire.Configuration
{
	public static class Inflate
	{
		public static void Static( Type type, Func<string, string> dictionary )
		{
			Fill( null, type, dictionary );
		}

		public static void Instance( object instance, Func<string, string> dictionary )
		{
			Fill( instance, instance.GetType(), dictionary );
		}

		public static object Instance(Type type, Func<string, string> dictionary)
		{
			var result = Activator.CreateInstance(type);

			Fill(result, type, dictionary);
			return result;
		}

		public static T Instance<T>(Func<string, string> dictionary)
		{
			var result = Activator.CreateInstance<T>();

			Fill(result, typeof(T), dictionary);
			return result;
		}

		private static void Fill( object instance, Type type, Func<string, string> dictionary )
		{
			var isStatic = (instance == null);

			var properties = type.GetRuntimeProperties()
				.Where(x =>
					   x.SetMethod != null
					&& x.SetMethod.IsPublic
					&& x.SetMethod.IsStatic == isStatic);

			// Get app settings and convert
			foreach (var property in properties) {
				var attributes = property.GetCustomAttributes( true );
				if (attributes.Any(x => x is Ignore)) {
					continue;
				}

				var named = (Named)attributes.FirstOrDefault(x => x is Named);

				var value = dictionary((named != null)? named.Name : property.Name);

				object result;

				result = value.ToOrDefault(property.PropertyType);
				property.SetValue( instance, result, null );

			}
		}
	}
}
