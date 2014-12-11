using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAssert;

#if SHOULD || EXPECT
#if SHOULD
namespace XAssert.Should
#elif EXPECT
namespace XAssert.Expect
#endif
{
	public static class TypeAssertions
	{
		public static void OfType(this Be<object> self, Type type, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotOfType(type, self.Target, message);
			else
				self.AssertProvider.IsOfType(type, self.Target, message);
		}

		public static void OfType<T>(this Be<object> self, string message = null)
		{
			OfType(self, typeof(T), message);
		}

		public static void OfTypeAssignableFrom(this Be<object> self, Type type, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotOfTypeAssignableFrom(type, self.Target, message);
			else
				self.AssertProvider.IsOfTypeAssignableFrom(type, self.Target, message);
		}

		public static void OfTypeAssignableFrom<T>(this Be<object> self, string message = null)
		{
			OfTypeAssignableFrom(self, typeof(T), message);
		}

		public static void OfTypeAssignableTo(this Be<object> self, Type type, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotOfTypeAssignableTo(type, self.Target, message);
			else
				self.AssertProvider.IsOfTypeAssignableTo(type, self.Target, message);
		}

		public static void OfTypeAssignableTo<T>(this Be<object> self, string message = null)
		{
			OfTypeAssignableTo(self, typeof(T), message);
		}
	}
}
#endif