using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
// Concepts:
//  1. Object slicing
//  2. Method hiding -- new keyword
//  3. virtual function and override
//  4. Polymorphism
namespace _01_OopInheritance
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
        //by default methods in c# are not virtual 
        // "virtual" method indicate that the method can be overridden
        //  in derived class, if derived class needs different/extended
        //  behavior

        public virtual void Display( )
        {
            Console.WriteLine($"Name = {Name} , Age = {Age}");
        }
    }
    class Student : Person
    {
        public int Roll
        {
            get;
            set; 
        }
        public double Marks
        {
            get;
            set; 
        }


        // this method is "new" method i.e. it is not related to base class
        //  method even though signature is same.
        // writing "new" is optional -- it is default behavior.
        //  recommended to write to improve readability
        /*
        public new void Display()
        {
            base.Display();
            Console.WriteLine($"Roll : {Roll} , Marks : {Marks}");
        }*/

        // "override" overrides method in derived class with same signature
        public override void Display()
        {
            base.Display();  
            Console.WriteLine($"Roll : {Roll} , Marks : {Marks}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Name = "Nilesh", Age = 31 };
            //p.Display(); 

            // Display() is called depending on type of Object 
            // Student class Display method is called 
            // "override" keyword -- overrided method is called  
             
            Person p2 = new Student() { Name = "Nilesh", Age = 31, Marks = 78, Roll = 5 };
            p2.Display(); 
        }
    }
}
