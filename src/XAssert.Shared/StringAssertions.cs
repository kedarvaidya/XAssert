using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XAssert;

#if SHOULD || EXPECT
#if SHOULD
namespace XAssert.Should
#elif EXPECT
namespace XAssert.Expect
#endif
{
	public static class StringAssertions
	{
		public static void Contain(
#if SHOULD
			this Should<string> self
#elif EXPECT
			this To<string> self
#endif
			, string part, StringComparison comparison, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.DoesNotContain(self.Target, part, comparison, message);
			else
				self.AssertProvider.Contains(self.Target, part, comparison, message);
		}

		public static void StartWith(
#if SHOULD
			this Should<string> self
#elif EXPECT
			this To<string> self
#endif
			, string part, StringComparison comparison, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.DoesNotStartWith(self.Target, part, comparison, message);
			else
				self.AssertProvider.StartsWith(self.Target, part, comparison, message);
		}

		public static void EndWith(
#if SHOULD
			this Should<string> self
#elif EXPECT
			this To<string> self
#endif
			, string part, StringComparison comparison, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.DoesNotEndWith(self.Target, part, comparison, message);
			else
				self.AssertProvider.EndsWith(self.Target, part, comparison, message);
		}

		public static void Match(
#if SHOULD
			this Should<string> self
#elif EXPECT
			this To<string> self
#endif
			, Regex regex, string message = null)
		{
			if (self.IsNegated)
				self.AssertProvider.DoesNotMatch(self.Target, regex, message);
			else
				self.AssertProvider.Matches(self.Target, regex, message);
		}
	}
}
#endif
