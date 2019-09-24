using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleILOffset
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				reThrowException();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public static void throwException()
		{
			throw new Exception();
		}
		private static void reThrowException()
		{
			try
			{
				throwException();
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
