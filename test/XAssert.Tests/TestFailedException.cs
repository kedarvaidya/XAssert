using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAssert.Tests
{
	[Serializable]
	public class TestFailedException: Exception
	{
		private const string DefaultMessage = "Test Failed";

		public TestFailedException()
			: this(DefaultMessage)
		{
		}

		public TestFailedException(string message): base(message)
		{
		}

		public TestFailedException(Exception innerException)
			: this(DefaultMessage, innerException)
		{
		}

		public TestFailedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
