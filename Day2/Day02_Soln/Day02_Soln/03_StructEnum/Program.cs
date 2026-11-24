using System.Reflection.Emit;

namespace _03_StructEnum
{
    // struct in C# -- for lightweight user defined types
    //  struct is value type -- local vars created on stack
    struct Point
    {
        int _x;
        int _y; 
        public Point( )
        {
            Console.WriteLine("parameterless ctor called");
        }
        public int X
        {
            get 
            { 
                return _x; 
            }
            set 
            {
                _x = value; 
            }
        }
        public int Y
        {
            get { return _y;  }

            set
            {
                _y = value;
            }
        }
        public void Display( )
        {
            Console.WriteLine($" x = {X} , y = {Y}");
        }
        //dtor not allowed 

    }
    class Person
    {
        private int _age;

        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Invalid age");
                this._age = value;
            }
        }
        // auto-implemented properties (since C# 3.0)
        //  auto creates a hidden field
        public string Name
        {
            get;
            set; 
        }
        public void Display( )
        {
            Console.WriteLine($"Name = {Name} , Age = {Age}") ;
        }
    }
    // enums are readable constants -- can be used in switch case
    // internally stored as "int" -- default type can be changed using inheritance.
    //  e.g. enum Weekday:short { ... }
    // enum ordinal nums start with 0
    enum WeekDays
    {
        SUNDAY,MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY,SATURDAY
    }
    enum Color
    {
        Red = 4, Green, Blue = 2, Yellow, Black, White = -3, Purple
    }
    enum Menu
    {
        EXIT , ADD , MUL , SUB, DIV 
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            // local vars must be initialized before use(pt) 
            //Point pt;
            //pt.Display(); 

            //  local vars of value types gets memory on stack. ( use property) 
            //  pt1 memory is alloced on stack -- in spite of new operator
            //Point pt1 = new Point();
            //pt1.X = 10;
            //pt1.Y = 20;
            //pt1.Display(); 
            //Console.WriteLine($" x = {pt1.X} , y = {pt1.Y}");

            // initialize using Object Initializer
            //  internally first param less ctor / default ctor is called
            //  then properties setters are executed
            //Point pt2 = new Point() { X = 10, Y = 20 };
            //Console.WriteLine($" x = {pt2.X} , y = {pt2.Y}");

            #region Collection Object Initializer  
            List<string> list = new List<string>() {"DAC" , "DMC", "DBDA"};
            //foreach (string ele in list)
            //{
            //    Console.WriteLine($"ele = {ele}");
            //}
            #endregion

            #region Class Objects and Object Initializers
            Person p = new Person() { Name = "ABC", Age = 31 };
            p.Display(); 
            #endregion
        }

        static void Main(string[] args)
        {
            #region Weekday enum (Simple Example)
            WeekDays w1 = new WeekDays();
            //Console.WriteLine($"w1 = {w1} , ordinal = {(int)w1}");

            WeekDays w2 = WeekDays.TUESDAY;
            //Console.WriteLine($"w2 = {w2} , ordinal = {(int)w2}");

            WeekDays w3 = (WeekDays)5;
            //Console.WriteLine($"w3 = {w3} , ordinal = {(int)w3}");

            WeekDays w4 = (WeekDays)10;
            //Console.WriteLine($"w3 = {w4} , ordinal = {(int)w4}");
            #endregion


            #region  Advanced Example - Duplicate values/Negative values  
            Color c1 = new Color();
            //Console.WriteLine($"c1 = {c1} ordinal = {(int)c1}");

            Color c2 = Color.Black;
            //Console.WriteLine($"c2 = {c2} ordinal = {(int)c2}");
            //Red has same value as of Black.
            //In such case the first (left - most) label considered

            Color c3 = Color.Purple;
            //Console.WriteLine($"c3 = {c3} ordinal = {(int)c3}");
            #endregion


            #region How to use Enums practically 
            Array menuvalues = Enum.GetValues(typeof(Menu));
            foreach (Menu m in menuvalues )
            {
                Console.WriteLine((int) m + "." + m);
            }
            Console.WriteLine("Enter the choice ");
            //int choice = int.Parse(Console.ReadLine());
            int choice = Convert.ToInt32(Console.ReadLine()); 
            Menu option = (Menu)choice;
            
            switch(option)
            {
                case Menu.ADD :
                    Console.WriteLine("ADD");
                    break;
                case Menu.SUB:
                    Console.WriteLine("SUB");
                    break;
            }
            #endregion
        }
    }
}
