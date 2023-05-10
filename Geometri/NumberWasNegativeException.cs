using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
	internal class NumberWasNegativeException : Exception
	{
		public NumberWasNegativeException() : base() { }

		public NumberWasNegativeException(string message) : base(message) { }

		public NumberWasNegativeException(string message, Exception innerException) : base(message, innerException) { }



		protected NumberWasNegativeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

	}
}
