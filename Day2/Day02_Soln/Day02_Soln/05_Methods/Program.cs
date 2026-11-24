using System.Xml.Linq;

namespace _05_Methods
{
    class MyInt
    {
        public int Num
        {
            get;
            set; 
        }
    }
    internal class Program
    {
        public static void swap1(int x , int y)
        {
            int t = x;
            x = y;
            y = t;
            Console.WriteLine($"Inside swap method x = {x} , y = {y}");
        }
        public static void swap2(MyInt x , MyInt y)
        {
            int t = x.Num;
            x.Num = y.Num;
            y.Num = t;
            Console.WriteLine($"Inside swap method x = {x.Num} , y = {y.Num}");
        }
        public static void swap3(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
            Console.WriteLine($"Inside swap method x = {x} , y = {y}");
        }
        static void Main1(string[] args)
        {
            // by default, primitive (value) types are passed by value -- args are "copied"
            // any change in formal args are not reflected in actual args

            //int n1 = 10, n2 = 20;
            //Console.WriteLine($"Before swap method n1 = {n1} , n2 = {n2}");
            //swap1(n1, n2);
            //Console.WriteLine($"After swap method n1 = {n1} , n2 = {n2}");

            // by default, class (ref) types are passed by ref -- args addr are sent
            // any change in formal args are reflected in actual args
            //MyInt n3 = new MyInt() { Num = 10 }; 
            //MyInt n4 = new MyInt() { Num = 20 };
            //Console.WriteLine($"Before swap method n1 = {n3.Num} , n2 = {n4.Num}");
            //swap2(n3, n4);
            //Console.WriteLine($"After swap method n1 = {n3.Num} , n2 = {n4.Num}");


          // primitive (value) types are can be passed by ref using "ref" keyword
          // any change in formal args are reflected in actual args
          //  int n5 = 10, n6 = 20;
          //  Console.WriteLine($"Before swap method n1 = {n5} , n2 = {n6}");
          //  swap3(ref n5, ref n6);
          //  Console.WriteLine($"After swap method n1 = {n5} , n2 = {n6}");
        }

        static void Main2(string[] args)
        {
            int num1 = 22, num2 = 7;
            double res; 
            if(divide(num1 , num2 , out res))
            {
                Console.WriteLine($"res : {res}");
            }
            else
                Console.WriteLine("divide by zero");
        }
        public static bool divide(int num, int den, out double res)
        {
            res = 0;
            if (den == 0)
             return false;
            res = num / den;
            return true; 
        }

        static void Main(string[] args)
        {
            void PrintInfo(string name , int age , string address = "AnyWhere" , string email = "Unknown") 
            {
                Console.WriteLine($"name = {name} , age = {age} , addr = {address} , email = {email}");
            }

            //calling PrintInfo() using positional arg -- as per arg seq
            //PrintInfo("Nilesh", 31, "Pune", "Nilesh@gmail"); 

            // calling PrintInfo() using named arg -
            // arg value associated with name of the arg 
            // arg can be passed in any sequence
            //PrintInfo(name: "Nilesh", age: 31, email: "Nilesh@gmail", address: "Pune"); 

            // first two args are passed positional -- by seq
            // next two args are passed by name
            //PrintInfo("Nilesh", 31, email: "nilesh@gmail", address: "Pune"); 

            // calling PrintInfo() using default args
            // the not passed args will get their default values
            // all default args must be at the end.
            PrintInfo("Nilesh", 31); 
        }
    }
}
