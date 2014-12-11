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
	public static class SamenessAssertions
	{
		public static void SameAs<T>(this Be<T> self, T value, string message = null) where T : class
		{
			if (self.IsNegated)
				self.AssertProvider.AreNotSame(value, self.Target, message);
			else
				self.AssertProvider.AreSame(value, self.Target, message);
		}
	}
}
#endif
