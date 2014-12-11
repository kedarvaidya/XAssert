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
	public static class NumberAssertions
	{
		public static void NaN(this Be<double> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotNaN(self.Target, message);
			else
				self.AssertProvider.IsNaN(self.Target, message);
		}

		public static void PositiveInfinity(this Be<double> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotPositiveInfinity(self.Target, message);
			else
				self.AssertProvider.IsPositiveInfinity(self.Target, message);
		}

		public static void NegativeInfinity(this Be<double> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotNegativeInfinity(self.Target, message);
			else
				self.AssertProvider.IsNegativeInfinity(self.Target, message);
		}
	}
}
#endif