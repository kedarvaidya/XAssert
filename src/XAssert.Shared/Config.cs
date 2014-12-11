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
	public class Config
	{
		public static IAssertProvider DefaultAssertProvider = new DefaultAssertProvider();
	}
}
#endif