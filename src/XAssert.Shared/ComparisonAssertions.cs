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
	public static class ComparisonAssertions
	{
		public static void GreaterThan<T>(this Be<T> self, T right, Comparer<T> comparer, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsLessThanOrEqual(self.Target, right, comparer, message);
			else
				self.AssertProvider.IsGreaterThan(self.Target, right, comparer, message);
		}

		public static void GreaterThan<T>(this Be<T> self, T right, string message = null)
		{
			GreaterThan<T>(self, right, Comparer<T>.Default, message);
		}

		public static void LessThan<T>(this Be<T> self, T right, Comparer<T> comparer, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsGreaterThanOrEqual(self.Target, right, comparer, message);
			else
				self.AssertProvider.IsLessThan(self.Target, right, comparer, message);
		}

		public static void LessThan<T>(this Be<T> self, T right, string message = null)
		{
			LessThan<T>(self, right, Comparer<T>.Default, message);
		}

		public static void GreaterThanOrEqualTo<T>(this Be<T> self, T right, Comparer<T> comparer, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsLessThan(self.Target, right, comparer, message);
			else
				self.AssertProvider.IsGreaterThanOrEqual(self.Target, right, comparer, message);
		}

		public static void GreaterThanOrEqualTo<T>(this Be<T> self, T right, string message = null)
		{
			GreaterThanOrEqualTo<T>(self, right, Comparer<T>.Default, message);
		}

		public static void LessThanOrEqualTo<T>(this Be<T> self, T right, Comparer<T> comparer, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsGreaterThan(self.Target, right, comparer, message);
			else
				self.AssertProvider.IsLessThanOrEqual(self.Target, right, comparer, message);
		}

		public static void LessThanOrEqualTo<T>(this Be<T> self, T right, string message = null)
		{
			LessThanOrEqualTo<T>(self, right, Comparer<T>.Default, message);
		}
	}
}
#endif