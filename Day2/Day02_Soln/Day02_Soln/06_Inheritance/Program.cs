using System.Xml.Linq;

namespace _06_Inheritance
{
    class Person
    {
        public string Name
        {
            get;
            set; 
        }
        public int Age
        {
            get;
            set; 
        }
        public Person( )
        {
            this.Name = "";
            this.Age = 0; 
        }
        public Person(string name , int age )
        {
            this.Name = name;
            this.Age = age; 
        }
        public void DisplayPerson( )
        {
            Console.WriteLine($"Name = {Name} , Age = {Age}");
        }
    }
    class Emp : Person
    {
        public int ID
        {
            get;
            set; 
        }
        public double salary
        {
            get;
            set; 
        }
        public  Emp()
        {
            this.ID = 0;
            this.salary = 0.0; 
        }
        public Emp(string name , int age , int id , double salary) : base(name,age)
        {
            this.ID = id;
            this.salary = salary; 
        }
        public void DisplayEmp( )
        {
            base.DisplayPerson(); 
            Console.WriteLine($"Id = {ID} , Salary = {salary}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Name = "Nilesh", Age = 31 };
            //p.DisplayPerson(); 

            Emp e = new Emp() { Name = "Nilesh", Age = 31, ID = 1, salary = 1000.00 };
            //e.DisplayEmp(); 

            //upcasting 
            //Person p1 = new Emp() { Name = "Nilesh", Age = 31, ID = 1, salary = 1000.00 };
            //p1.DisplayPerson(); 
            //p1.DisplayEmp(); 
            //Emp e2 = (Emp)p1;
            //e2.DisplayEmp(); 

            Person p2 = new Emp() { Name = "Nilesh", Age = 31, ID = 1, salary = 1000.00 };
            if (p2 is Emp)
            {
                //Emp e3 = (Emp)p2;
                //e3.DisplayEmp(); 
            }
            Emp e3 = p2 as Emp;
            if(e3!=null)
            {
                e3.DisplayEmp(); 
            }
        }
    }
}
