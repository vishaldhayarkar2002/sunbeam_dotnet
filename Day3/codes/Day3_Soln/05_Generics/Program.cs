using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Generics
{
    // Non-Generic class - ObjBox
    // Limitation: code is not type-safe
    //  i.e. type checking is not done at compile time.
    class ObjBox
    {
        private object obj;
        public void SetObj(object obj)
        {
            this.obj = obj;
        }
        public object GetObj()
        {
            return this.obj;
        }
    }

    //we can write non-generic method inside the generic class 
    // Type safe 
    class Box<T>
    {
        private T obj;
        public void Set(T obj)
        {
            this.obj = obj;
        }
        public T GetObj()
        {
            return this.obj;
        }
        public void Display()
        {
            Console.WriteLine($"ele : {obj}");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            ObjBox b1 = new ObjBox();
            b1.SetObj("hello");
            string s1 = (string)b1.GetObj();
            //Console.WriteLine($"s1 = {s1}");

            ObjBox b2 = new ObjBox();
            b2.SetObj(100);
            int i = (int)b2.GetObj();
            //Console.WriteLine($"i  = {i}");

            ObjBox b3 = new ObjBox();
            b3.SetObj("hello");
            //int i2 = (int)b3.GetObj();
            //Console.WriteLine($"i2 = {i2}");

            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add("hello");
            foreach (object ele in list)
            {
                int i2 = (int)ele;
                Console.WriteLine($"ele  = {i2}");
            }
        }

        static void Main2(string[] args)
        {
            Box<int> b1 = new Box<int>();
            b1.Set(100);
            int i = b1.GetObj();
            Console.WriteLine($" i = {i}");
            Box<string> b2 = new Box<string>();
            b2.Set("hello");
            string s = b2.GetObj();
            Console.WriteLine($"s : {s}");
            Box<int> b3 = new Box<int>();
            //b3.Set("Hello"); // Compiler Error : Type checking is done at Compile Time 
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            //list.Add("40"); // Compile Time Error 
            foreach (int ele in list)
            {
                Console.WriteLine($"ele = {ele}");
            }
        }


        //generic method 
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void Main3(string[] args)
        {
            int n1 = 10, n2 = 20;
            //Console.WriteLine($"Before Swap : n1 = {n1} n2 = {n2}");
            //Swap<int>(ref n1, ref n2); // T : int 
            //Console.WriteLine($"After Swap : n1 = {n1} n2 = {n2}");
            double d1 = 11.3, d2 = 12.3;
            //Console.WriteLine($"Before Swap : d1 = {d1} d2 = {d2}");
            //Swap<double>(ref d1, ref d2); // T : double;
            //Console.WriteLine($"After Swap : d1 = {d1} d2 = {d2}");
            string s1 = "A", s2 = "B";
            Console.WriteLine($"Before Swap : s1 = {s1} s2 = {s2}");
            Swap<string>(ref s1, ref s2); // T : string 
            Console.WriteLine($"After Swap : s1 = {s1} s2 = {s2}");
        }

        //non-generic class can contain generic method 
        class Util
        {
            //generic method 
            public void Swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }
        static void Main4(string[] args)
        {
            Util obj = new Util();
            int n1 = 10, n2 = 20;
            Console.WriteLine($"Before Swap : n1 = {n1} n2 = {n2}");
            obj.Swap<int>(ref n1, ref n2);
            Console.WriteLine($"Afer Swap : n1 = {n1} n2 = {n2}");
            double d1 = 11.3, d2 = 12.3;
            Console.WriteLine($"Before Swap : d1 = {d1} d2 = {d2}");
            obj.Swap<double>(ref d1, ref d2);
            Console.WriteLine($"After Swap : d1 = {d1} d2 = {d2}");
        }

        //Emp class - Id , Name , Salary , Equals , ToString() , IComparable<Emp>
        public class Emp : IComparable<Emp>
        {
            public int Id
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
            public double Salary
            {
                get;
                set;
            }
            public override bool Equals(object obj)
            {
                if (obj != null)
                {
                    Emp other = (Emp)obj;
                    return (other.Id == Id);
                }
                return false;
            }
            public override string ToString()
            {
                return $"Id = {Id} , Name = {Name} , Salary = {Salary}";
            }

            public int CompareTo(Emp other)
            {
                return this.Id.CompareTo(other.Id);
            }
        }
        class EmpNameComparer : IComparer<Emp>
        {
            public int Compare(Emp x, Emp y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
        class EmpSalComparerDesc : IComparer<Emp>
        {
            public int Compare(Emp x, Emp y)
            {
                return x.Salary.CompareTo(y.Salary);
            }
        }
        static void Main5(string[] args)
        {
            Emp[] arr = new Emp[5]
            {
                new Emp { Id = 2, Name = "John", Salary = 2000.0 },
                new Emp { Id = 5, Name = "Mark", Salary = 1500.0 },
                new Emp { Id = 1, Name = "Steve", Salary = 3500.0 },
                new Emp { Id = 4, Name = "Peter", Salary = 4000.0 },
                new Emp { Id = 3, Name = "Tony", Salary = 3000.0 }
            };
            Console.WriteLine("Before swap");
            foreach (Emp e in arr)
            {
                Console.WriteLine($"{e}");
            }
            Console.WriteLine("After swap sort on ID");
            Array.Sort(arr);
            foreach (Emp e in arr)
            {
                Console.WriteLine($"{e}");
            }
            Console.WriteLine("Sort On Name");
            Array.Sort(arr, new EmpNameComparer());
            foreach (Emp e in arr)
            {
                Console.WriteLine($"{e}");
            }
            Console.WriteLine("Sort on Salary :");
            Array.Sort(arr, new EmpSalComparerDesc());
            foreach (Emp e in arr)
            {
                Console.WriteLine($"{e}");
            }
        }

        // write a generic method, that will compare given two objects of same type
        // and return max -- comparison is made on basis of IComparable.
        public static T GetMax<T>(T a , T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
                return a;
            return b; 
        }
        //Create Student class ( Name , Roll , Marks) 
        class Student
        {
            public string Name { get; set; }
            public int Roll { get; set; }
            public double Marks { get; set; }
        }

        static void Main6(string[] args)
        {
            string s1 = "A"; 
            string s2 = "B";
            string maxStr = GetMax<string>(s1, s2);
            //Console.WriteLine($"maxStr = {maxStr}");
            Emp e1 = new Emp() { Id = 100, Name = "Amit", Salary = 1000.00 };
            Emp e2 = new Emp() { Id = 50, Name = "Nilesh", Salary = 2000.00 };
            //Emp maxEmp = GetMax<Emp>(e1, e2);
            //Console.WriteLine($"{maxEmp}");
            Student s5 = new Student() { Name = "Amit", Roll = 1, Marks = 50.00 };
            Student s6 = new Student() { Name = "Rahul", Roll = 3, Marks = 150.00 };
            GetMax<Student>(s5, s6); 
        }


        public static T CreateObject<T>( ) where T : class , new( ) 
        {
            return new T(); 
        }
        static void Main(string[] args)
        {
            Student obj = CreateObject<Student>(); 
        }

    }
}
