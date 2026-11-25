using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _06_Delegates
{
    internal class Program
    {
        delegate void MathOp(int a, int b);
        class MyMath
        {
            public void Subtract(int a, int b)
            {
                Console.WriteLine($"Subtract = {a} - {b} = {a - b}");
            }
        }
        public static void Sum(int a ,int b)
        {
            Console.WriteLine($"Sum = {a} + {b} = {a + b}");
        }
        static void Main1(string[] args)
        {
            MathOp ptr1;
            ptr1 = new MathOp(Program.Sum);
            //ptr1(10, 20); 
            
            MyMath obj = new MyMath();
            MathOp ptr2 = new MathOp(obj.Subtract);
            //ptr2(30, 10); 

            void Multiply(int a, int b)
            {
                Console.WriteLine($"Multiply = {a} * {b} = {a * b}");
            }
            MathOp ptr3 = new MathOp(Multiply);
            //ptr3(10, 10);
            void Divide(int a, int b)
            {
                Console.WriteLine($"Divide = {a}  / {b} = {a / b}");
            }
            MathOp ptr4 = Divide;
            //ptr4(30, 10);

            MathOp ptr5 = delegate (int a, int b)
            {
                Console.WriteLine($"Multiply = {a} * {b} = {a * b}");
            };
            //ptr5(10, 10); 

            MathOp ptr6 = (a,b) => Console.WriteLine($"Subtract = {a}  - {b} = {a - b}");
            //ptr6(30, 10); 

            Console.WriteLine("-------------------");
            // Multicast delegate 
            MathOp ptr = ptr1;
            ptr += ptr2; 
            ptr += ptr3;
            ptr += ptr4;
            ptr += ptr5;
            ptr += (a, b) => Console.WriteLine($"Subtract = {a}  - {b} = {a - b}"); 
            ptr += ptr6;
            ptr(30, 10); 
        }

        delegate int MathOpRet(int a, int b); 
        static void Main(string[] args)
        {
            MathOpRet ptr = (a, b) => (a + b);
            ptr += (a, b) => (a - b);
            ptr += (a, b) => (a / b);

            int r = ptr(30, 10);
            //Console.WriteLine($"r = {r}");
            //Returns the invocation list of this multicast delegate, in invocation order.
            foreach (MathOpRet op in ptr.GetInvocationList())
            {
                int res = op(30, 10);
                Console.WriteLine($"res = {res}");
            }
        }
    }
}
