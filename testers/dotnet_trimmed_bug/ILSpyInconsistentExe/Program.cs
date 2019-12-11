using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ILSpyInconsistentExe
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Sleeping for 2 seconds");
            Thread.Sleep(2000);

            var fields = new List<Field>() { new Field("EmployeeName", typeof(string)) };
            dynamic obj = new DynamicClass(fields);

            obj.EmployeeName = "John";

            try
            {
                obj.EmployeeName = 666;   //Exception: Value 666 is not of type String
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Press key to end");
            Console.ReadKey();
        }
    }
}
