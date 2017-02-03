using System;
using System.Text;


namespace Onty.SeleniumTest.Webmail
{

	[Serializable]
	public class WrongPageException : Exception
	{

		public WrongPageException() { }

		public WrongPageException( string message ) : base( message ) { }

		public WrongPageException( string message, Exception inner ) : base( message, inner ) { }

		protected WrongPageException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
	}

}//ns

