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
	public static class GuidAssertions
	{
		public static void Empty(this Be<Guid> self, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.IsNotEmpty(self.Target, message);
			else
				self.AssertProvider.IsEmpty(self.Target, message);
		}
	}
}
#endif
