using System.Runtime.Intrinsics.X86;

namespace _04_Boxing
{
    internal class Program
    {
     // Java Autoboxing Feature
     //   In Java, primitive types are not objects.
     //   To treat primitive types as objects, Java have wrapper classes.
     //   Till Java 1.4 -- Programmer need explicit casting/coding to convert
     //      primitive type to wrapper types & vice-versa.
     //   Java 5.0 -- Auto-boxing feature
     //      implicit conversion from primitive to wrapper and reverse.
        static void Main1(string[] args)
        {
            // C# Boxing and Unboxing Concept
            //  C# primitive types are implicitly converted to CTS types.
            //      e.g. int <--> Int32
            //  Primitive type variable is also an Object (of Value type).
            int num1 = 123;
            object obj = num1; //Boxing ( int is value type)

            int num2 = (int)obj; // Unboxing  
                                 // object is reference type)
                                 //ref type to value type --Unboxing
            //Console.WriteLine($"num2  = {num2}");
        }

        static void Main(string[] args)
        {
            //use System.Collections.ArrayList
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            list.Add(10); //int -> object => boxing 
            list.Add(20);
            list.Add(30);

            //C# 2.0 generic collections allows value types
            System.Collections.Generic.List<int> list2 = new System.Collections.Generic.List<int>();
            // No boxing/unboxing needed to use collections with primitive types
            // very fast
            list2.Add(10);
            list2.Add(20);  
        }
    }
}
