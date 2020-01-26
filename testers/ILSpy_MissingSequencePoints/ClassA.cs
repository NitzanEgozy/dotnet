using System;
using System.Security;

namespace MissingSequencePoints
{
	public class ClassA
	{
		public void func1()
		{
			try
			{
				throw new Exception();
			}
			catch (Exception)
			{
			}
		}
	}
}
