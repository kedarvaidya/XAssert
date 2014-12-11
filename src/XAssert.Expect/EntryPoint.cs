using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAssert;

namespace XAssert.Expect
{
	public static class EntryPoint
	{
		public static Expect<T> Expect<T>(this object self, T target, IAssertProvider assertProvider = null)
		{
			return Expect(target, assertProvider);
		}

		public static Expect<T> Expect<T>(T target, IAssertProvider assertProvider = null)
		{
			return new Expect<T>(assertProvider ?? XAssert.Expect.Config.DefaultAssertProvider, target);
		}
	}
}
