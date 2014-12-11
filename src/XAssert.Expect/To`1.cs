using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAssert;

namespace XAssert.Expect
{
	public class To<T>
	{
		public IAssertProvider AssertProvider { get; private set; }

		public T Target { get; private set; }

		public bool IsNegated { get; private set; }

		public To(IAssertProvider assertProvider, T target, bool isNegated)
		{
			if (assertProvider == null)
				throw new ArgumentNullException("assertProvider");

			this.AssertProvider = assertProvider;
			this.Target = target;
			this.IsNegated = isNegated;
		}

		public Be<T> Be 
		{
			get { return new Be<T>(this.AssertProvider, this.Target, IsNegated); }
		}

		public To<T> Not
		{
			get { return new To<T>(this.AssertProvider, this.Target, !this.IsNegated); }
		}
	}
}
