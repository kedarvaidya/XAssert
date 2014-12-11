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
	public static class EqualityAssertions
	{
		public static void EqualTo<T>(this Be<T> self, T right, IEqualityComparer<T> comparer, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.AreNotEqual(right, self.Target, comparer, message);
			else
				self.AssertProvider.AreEqual(right, self.Target, comparer, message);
		}

		public static void EqualTo<T>(this Be<T> self, T right, string message = null)
		{
			EqualTo<T>(self, right, EqualityComparer<T>.Default, message);
		}
	}
}
#endif
