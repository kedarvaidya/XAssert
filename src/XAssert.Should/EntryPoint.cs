using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAssert;

namespace XAssert.Should
{
	public static class EntryPoint
	{
		public static Should<T> Should<T>(this T self, IAssertProvider assertProvider = null)
		{
			return new Should<T>(assertProvider ?? XAssert.Should.Config.DefaultAssertProvider , self, false);
		}
	}
}
