using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    class Person
    {
        private string name;
        private string address;
        private int age;


        public Person() : this("", "", 0) // ctor chaining 
        {

        }
        public Person(string name, string address, int age)
        {
            this.name = name;
            this.address = address;
            this.age = age;
        }

        public void SetAge(int age)
        {
            if (age < 0 || age > 100)
                throw new Exception("Invalid Age");
            this.age = age;
        }
        public int GetAge()
        {

            return age;
        }

        //( properties) 
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Invalid age");
                this.age = value;
            }
        }

        // Auto-implemented properties -   // internally creates a fields -- hidden
        public int Weight
        {
            get; // default : return this.weight; 
            set; // default : this.weight = value; 
        }
        public void AcceptPerson()
        {
            Console.Write("Name : ");
            name = Console.ReadLine();
            Console.Write("Address : ");
            address = Console.ReadLine();
            Console.Write("Age : ");
            string strage = Console.ReadLine();
            age = int.Parse(strage);
        }
        public void PrintPerson()
        {
            Console.WriteLine("Name : {0} , Address : {1} , age : {2}", name, address, age);
        }
        ~Person()
        {
            Console.WriteLine("Person dead");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.AcceptPerson();
            p.PrintPerson();
            //p.SetAge(50);
            //p.Age = 50;
            //Console.WriteLine("Age : " + p.GetAge( ));
            // Console.WriteLine("Age : " + p.Age);
            p.Weight = 70;
            Console.WriteLine("Weight : " + p.Weight);
        }
    }
}
