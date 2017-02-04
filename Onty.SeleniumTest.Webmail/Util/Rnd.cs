using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onty.SeleniumTest.Webmail.Util
{
	public static class Rnd
	{

		private static Random rnd;

		static Rnd()
		{
			rnd = new Random( (int)DateTime.Now.Millisecond );
		}

		public static Random Random
		{
			get
			{
				return rnd;
			}
		}

	}

}//ns
