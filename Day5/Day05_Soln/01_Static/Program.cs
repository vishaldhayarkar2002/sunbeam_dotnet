using System.Runtime.CompilerServices;
using System.Text;

using static System.Console;
// static members of Console class are accessible directly e.g. WriteLine(), ReadLine(), ...

namespace _01_Static
{

    sealed public class MyClass
    {
        // const field must be initialized at declaration
        // const field cannot be static
        // const increase readbility of the code (like C macros)
        public const double PI = 3.14;

        // readonly fields are one-time initializable (at declaration or in constructor)
        // readonly fields can be static or non-static
        public static readonly int num; // = 123;
        // no access specifier - for static constructor
        // no overloading -- static ctor
        static MyClass()
        {
            double test = PI;
            num = 1234;
            Console.WriteLine("MyClass static ctor is called.");
        }
        // static methods can access static fields
        public static void Display()
        {
            Console.WriteLine("MyClass.Display() called: num = " + num);
        }
    }

    internal class ModuleInit
    {
        // method auto-executed when assembly is loaded in CLR for first time.
        [ModuleInitializer]
        internal static void ModuleInitialize()
        {
            Console.WriteLine("Assembly is Loaded.");
        }
    }

    // extension methods of MyClass
    // rule 1: the first arg must be object of MyClass with "this" keyword
    // rule 2: must be static method of the static class (top-level)
    static public class MyClassExtensions
    {
        static public void ExtDisplay(this MyClass m)
        {
            Console.WriteLine("MyClass ExtDisplay() extension is called.");
        }
    }

    // extension methods of string class e.g. SwapCase()
    public static class StringExtesions
    {
        public static string SwapCase(this string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char ch in s)
            {
                if (char.IsLower(ch))
                    sb.Append(char.ToUpper(ch));
                else if (char.IsUpper(ch))
                    sb.Append(char.ToLower(ch));
                else
                    sb.Append(ch);
            }
            return sb.ToString();
        }
    }

    // interface with abstract static methods ensure that sub-class
    //  must have static method - specially useful to have generic algo
    public interface IAdd<T>
    {
        abstract static T Add(T arg1, T arg2);
    }
    // operator overloading in C# class/struct
    //  - must be static method named as operator(sign).
    //  - number of args must be as per the operator requirement i.e. unary, binary.
    //  - not all operators can be overloaded.
    // operator+(), operator==(), operator!=()
    public class Vector : IAdd<Vector>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public static Vector Add(Vector arg1, Vector arg2)
        {
            Vector res = new Vector();
            res.X = arg1.X + arg2.X;
            res.Y = arg1.Y + arg2.Y;
            res.Z = arg1.Z + arg2.Z;
            return res;
        }
        public static Vector operator+(Vector arg1, Vector arg2)
        {
            Vector res = new Vector();
            res.X = arg1.X + arg2.X;
            res.Y = arg1.Y + arg2.Y;
            res.Z = arg1.Z + arg2.Z;
            return res;
        }
        public static bool operator==(Vector arg1, Vector arg2)
        {
            return arg1.X == arg2.X && arg1.Y == arg2.Y && arg1.Z == arg2.Z;
        }
        public static bool operator!=(Vector arg1, Vector arg2)
        {
            return !(arg1 == arg2);
        }
        public override string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }
    }

    // singleton class
    internal class Program
    {
        static void Main1(string[] args)
        {
            // static imports
            WriteLine("Hello, World!");
            // MyClass static constructor
            MyClass.Display();
        }

        // MyClass & String extensions
        static void Main2(string[] args)
        {
            MyClass obj = new MyClass();
            obj.ExtDisplay();
            // internally calls -- MyClassExtensions.ExtDisplay(obj);

            string str = "SunBeam";
            string res = str.SwapCase();
            Console.WriteLine("SwapCase: " + res);
        }

        // Static abstract methods and operators
        static void Main3(string[] args)
        {
            Vector v1 = new Vector() { X = 1, Y = 2, Z = 3 };
            Vector v2 = new Vector() { X = 2, Y = 4, Z = 6 };
            Vector v3 = Vector.Add(v1, v2);
            Console.WriteLine("v3 = " + v3);
            Vector v4 = v1 + v2; // operator overloading -- more readable
                                 // v4 = Vector.operator+(v1, v2); 
            Console.WriteLine("v4 = " + v4);
            Console.WriteLine("v3 == v4 : " + (v3 == v4));
        }

        // singleton class
        class FileLogger
        {
            // fields
            private string _path = "D:/logfile.txt";
            // methods
            public void Log(string msg)
            {
                string m = DateTime.Now.ToString() + ": " + msg + "\n";
                File.AppendAllText( _path, m ); 
            }
            // To make this class singleton
            //  1. private constructor
            private FileLogger() { 
                // default fields initialization -- can be added here.
            }
            //  2. initialize a static instance of the class -- one time initialize
            public static readonly FileLogger Instance;
            static FileLogger()
            {
                Instance = new FileLogger();
            }
        }
        static void Main(string[] args)
        {
            FileLogger.Instance.Log("Hi, World!");
            FileLogger.Instance.Log("Bye, World!");

        }
    }
}
