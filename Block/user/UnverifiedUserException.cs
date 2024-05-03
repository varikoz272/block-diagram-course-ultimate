using System;
using System.Runtime.Serialization;

namespace Block.user
{
	public class UnverifiedUserException : Exception, ISerializable
	{
		public UnverifiedUserException()
		{
			
		}

	 	public UnverifiedUserException(string message) : base(message)
		{
	 		
		}

		public UnverifiedUserException(string message, Exception innerException) : base(message, innerException)
		{
			
		}

		protected UnverifiedUserException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			
		}
	}
}