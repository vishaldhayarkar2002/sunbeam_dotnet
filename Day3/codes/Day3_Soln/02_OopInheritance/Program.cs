using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Emp Hierarchy implementation
//  Emp class -- abstract
//      - Id, Salary
//      - CalcIncome() -- virtual
//      - DoWork() -- abstract
//  Labor class
//      - _hours, _rate
//      - Properties (Hours , Rate) -- Salary = Hours * Rate
//      - DoWork() -- Physical Work -- override
//  Manager class
//      - Bonus
//      - CalcIncome() = Salary + Bonus -- override sealed
//          - Fixed for all Managers
//      - DoWork() -- Management Work -- override
//  SalesManager class
//      - CalcIncome() -- Error
//      - DoWork() -- Not required ? // may override DoWork()
//  HRManager class
//      - DoWork() -- Not required ?
//  Salesman class
//      - Commission ( double) 
//      - CalcIncome() -- Salary + Commission -- override -- 
//      - DoWork() -- Sales Work -- override
//  Clerk class -- sealed
//      - No grading/classification for Clerk
//      - DoWork() -- Clerical Work -- override
//  IntelligentClerk -- cannot extend Sealed Class 

// Error: Multiple class inheritance is not supported in C#.
// class SpecialManager : HRManager, SalesManager
//{
//}
//  EmpUtil class -- static
//      - CalcTotalExpenses(Emp[] emps) -- static
//  
namespace _02_OopInheritance
{
    abstract class Emp
    {
        public int Id
        {
            get;
            set; 
        }
        public double Salary
        {
            get;
            set; 
        }
        public virtual double CalcIncome()
        {
            return Salary; 
        }
        public abstract void DoWork(); 
    }
    class Labor : Emp
    {
        private int _hours;
        private double _rate; 

        public int Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                _hours = value;
                Salary = Hours * Rate; 
            }
        }
        public double Rate
        {
            get
            {
                return _rate; 
            }
            set
            {
                _rate = value;
                Salary = Hours * Rate; 
            }
        }

        public override void DoWork()
        {
            Console.WriteLine("Labour Work");
        }
    }
    class Manager : Emp
    {
        public double Bonus
        {
            get;
            set; 
        
        }
        //sealed method cannot be override inside the derived class 
        public sealed override double CalcIncome()
        {
            return Bonus + Salary; 
        }
        public  override void DoWork()
        {
            Console.WriteLine("Manager work");
        }
    }
    class SalesManager : Manager
    {
        /*
        public override double CalcIncome()
        {
            return Bonus + Salary;
        }*/
        public override void DoWork()
        {
            Console.WriteLine("SalesManager WorK");
        }
    }
    class HRManager : Manager
    {
        /* // NOT OK 
        public override double CalcIncome()
        {
            return Bonus + Salary;
        }*/
        public override void DoWork()
        {
            Console.WriteLine("HRManager WorK");
        }
    }
    class Salesman : Emp
    {
        public double Commission;
        public override double CalcIncome()
        {
            return Salary + Commission; 
        }

        public override void DoWork()
        {
            Console.WriteLine("Salesman Work");
        }
    }
    //we cannot extend which sealed class 
    sealed class Clerk : Emp
    {
        public override void DoWork()
        {
            Console.WriteLine("Clerical Work");
        }
    }
    /*
    class IntelligentClerk : Clerk
    {

    }*/ 
    /*
     Multiple Inheritance is not Supported in C#
    class SpecialManager : HRManager , SalesManager
    {

    }*/ 
    class EmpUtil
    {
        public static double CalculateTotalExpenses(Emp[] emps)
        {
            double total = 0.0;
            foreach (Emp e in emps)
            {
                total = total + e.CalcIncome(); 
            }
            return total; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Emp emp = new Emp(); // NOT OK ( cannot create object of abstract class 
            Emp[] emps = new Emp[5]
            {
                    new Manager() { Id=1, Salary=10000.0, Bonus=2000.0},
                    new Clerk() { Id=2, Salary=3000.0},
                    new Salesman() { Id=3, Salary=4000.0, Commission=1000.0},
                    new HRManager() { Id=4, Salary=9000.0, Bonus=1000.0},
                    new Labor() { Id=5, Hours=100, Rate=20.0}
            };
            double totalExp = EmpUtil.CalculateTotalExpenses(emps);
            Console.WriteLine($"Total : {totalExp}");
        }
    }
}
