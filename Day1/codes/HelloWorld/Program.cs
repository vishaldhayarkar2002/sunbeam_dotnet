using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            int num1 = 22, num2 = 7;
            int result; 
            result = num1 + num2;
            //Console.WriteLine("result = " +result);
            //Console.WriteLine("result = {0}",result);
            Console.WriteLine($"result = {result}");
        }
    }
}
