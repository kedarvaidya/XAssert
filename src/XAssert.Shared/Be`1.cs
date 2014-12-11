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
	public class Be<T>
	{
		public IAssertProvider AssertProvider { get; private set; }

		public T Target { get; private set; }

		public bool IsNegated { get; private set; }

		public Be(IAssertProvider assertProvider, T target, bool isNegated)
		{
			if (assertProvider == null)
				throw new ArgumentNullException("assertProvider");

			this.AssertProvider = assertProvider;
			this.Target = target;
			this.IsNegated = isNegated;
		}
	}
}
#endif