using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if SHOULD || EXPECT
#if SHOULD
namespace XAssert.Should
#elif EXPECT
namespace XAssert.Expect
#endif
{
	public static class NullAndDefaultAssertions
	{
		public static void Null<T>(this Be<T> self, string message = null) where T: class
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotNull(self.Target, message);
			else
				self.AssertProvider.IsNull(self.Target, message);
		}

		public static void Null<T>(this Be<Nullable<T>> self, string message = null) where T : struct
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotNull(self.Target, message);
			else
				self.AssertProvider.IsNull(self.Target, message);
		}

		public static void Default<T>(this Be<T> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotDefault(self.Target, message);
			else
				self.AssertProvider.IsDefault(self.Target, message);
		}
	}
}
#endif