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
	public static class BooleanAssertions
	{
		public static void True(this Be<bool> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsFalse(self.Target, message);
			else
				self.AssertProvider.IsTrue(self.Target, message);
		}

		public static void False(this Be<bool> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsTrue(self.Target, message);
			else
				self.AssertProvider.IsFalse(self.Target, message);
		}
	}
}
#endif