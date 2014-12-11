using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAssert;

namespace XAssert.Expect
{
	public class Expect<T>
	{
		public IAssertProvider AssertProvider { get; private set; }

		public T Target { get; private set; }

		public Expect(IAssertProvider assertProvider, T target)
		{
			if (assertProvider == null)
				throw new ArgumentNullException("assertProvider");

			this.AssertProvider = assertProvider;
			this.Target = target;
		}

		public To<T> To
		{
			get { return new To<T>(this.AssertProvider, this.Target, false); }
		}
	}
}
