using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAssert
{
	public class AssertException : Exception
	{
		public AssertException(string message)
			: base(message)
		{
		}

		public AssertException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
