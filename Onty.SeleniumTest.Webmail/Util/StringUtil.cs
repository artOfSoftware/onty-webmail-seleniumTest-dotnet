using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Onty.SeleniumTest.Webmail.Util
{

	public class StringUtil
	{

		public static string IntToBase26( int n )
		{
			StringBuilder sb = new StringBuilder();

			int min = (int)'a';
			int max = (int)'z';

			int diff = max-min+1;

			while ( n > 0 )
			{
				int v = n % diff;
				sb.Insert( 0, (char)( v + min ) );
				n /= diff;
			}

			return sb.ToString();
		}

		public static string MakeRandomString()
		{
			return IntToBase26( Rnd.Random.Next() );
		}


	}

}
