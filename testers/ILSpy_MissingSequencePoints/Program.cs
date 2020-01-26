using System;

namespace MissingSequencePoints
{
	class Program
	{
		static void Main(string[] args)
		{
			new ClassA().func1();
			Console.WriteLine("End of test.");
		}
	}
}
