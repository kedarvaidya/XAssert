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
	public static partial class CollectionAssertions
	{
		public static void Empty<T>(this Be<IEnumerable<T>> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotEmpty(self.Target, message);
			else
				self.AssertProvider.IsEmpty(self.Target, message);
		}

		public static void Contain<T>(
#if SHOULD
			this Should<IEnumerable<T>> self
#elif EXPECT
			this To<IEnumerable<T>> self
#endif
			, T item, IEqualityComparer<T> comparer, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.DoesNotContain<T>(self.Target, item, comparer, message);
			else
				self.AssertProvider.Contains<T>(self.Target, item, comparer, message);
		}

		public static void Contain<T>(
#if SHOULD
			this Should<IEnumerable<T>> self
#elif EXPECT
			this To<IEnumerable<T>> self
#endif
			, T item, string message = null)
		{
			Contain<T>(self, item, EqualityComparer<T>.Default, message);
		}
	}
}
#endif
