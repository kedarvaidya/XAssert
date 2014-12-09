using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAssert.Tests
{
	public class TestHelper
	{
		public static void FailIfExceptionIsThrown<TException>(Action action) where TException: Exception
		{
			try
			{
				action();
			}
			catch (TException ex)
			{
				throw new TestFailedException(ex);
			}
		}

		public static void FailIfExceptionIsNotThrown<TException>(Action action) where TException : Exception
		{
			bool thrown = false;
			try
			{
				action();
			}
			catch (TException)
			{
				thrown = true;
			}

			if (!thrown)
				throw new TestFailedException();
		}

		public class Base { }

		public class Derived: Base { }
	}
}
