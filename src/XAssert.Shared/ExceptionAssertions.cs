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
	public static class ExceptionAssertions
	{
		public static void Throw<TException>(
#if SHOULD
			this Should<Action> self
#elif EXPECT
			this To<Action> self
#endif
			, string message = null) where TException : Exception
		{
			if (self.IsNegated)
				self.AssertProvider.DoesNotThrow<TException>(self.Target, message);
			else
				self.AssertProvider.Throws<TException>(self.Target, message);
		}
	}
} 
#endif
