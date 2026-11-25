
# 01_OopInheritance 
// Concepts:
//  1. Object slicing
//  2. Method hiding -- new keyword
//  3. virtual function and override
//  4. Polymorphism

// class Person
//      - Name, Age ( get , set ) 
//      - Display()     // by default method is not virtual
// class Student
//      - Roll, Marks
//      - Display()

 // "virtual" method indicate that the method can be overridden
        //  in derived class, if derived class needs different/extended
        //  behavior

 // this method is "new" method i.e. it is not related to base class
        //  method even though signature is same.
        // writing "new" is optional -- it is default behavior.
        //  recommended to write to improve readability


 // "override" overrides method in derived class with same signature
 
 // Person object 
 // Student object 
 // upcasting 

-- Runtime polymorphism defination -- refer imag (debugging ) 

****************************************************************************************
// abstract method must be overridden in derived class.
        // if class has at least one abstract method, then class must be abstract class.
    
# 02_OopInheritance 
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

// separate utility class for all emp mgmt utilities
    // C# static class -- all members must be static -- helper/utility class
    // cannot create object of such class.


Emp[] emps = new Emp[5]
{
new Manager() { Id=1, Salary=10000.0, Bonus=2000.0},
new Clerk() { Id=2, Salary=3000.0},
new Salesman() { Id=3, Salary=4000.0, Commission=1000.0},
new HRManager() { Id=4, Salary=9000.0, Bonus=1000.0},
new Labor() { Id=5, Hours=100, Rate=20.0}
};

***********************************************************************
// Error: C# interfaces cannot have fields or constructors or other methods
        // by default each method in interface is abstract and public
03_OopInterfaces
// interface ISpellChecker
//      bool CheckSpelling(word);
// class EnglishSpellChecker
// class FrenchSpellChecker
// class SpanishSpellChecker
// class Editor
//      - _spellChecker
//      - Open()
//      - Validate()
//      - Save()


**********************************************************************
04_OopInterfaces
// interface IBackendDeveloper
//      void Develop(); , DbCoding() 
// interface IFrontendDeveloper
//      void Develop(); , UiCoding() 
// class FresherFullStackDeveloper
//      void Develop() -- Develops both
 // Implicit interface implementation
        // if multiple base interfaces have same method signature, the common
        //      implementation given in derived class.



// class ExperiencedFullStackDeveloper
//      void Develop() -- Expert in Backend & Frontend ??

// Need separate implementation for IBackendDev.Develop() and IFrontendDev.Develop()
        // explicit interface implmentation


#region FresherFullStackDev - Implicit Interface Impl - Calls 
#region ExperiencedFullStackDeveloper - Explicit Interface Impl - Calls 

*************************************************************************** 
05_generic
#main 
// Non-Genric class - ObjBox
//      - obj
//      - Get(), Set()  ( string , int) 
//        // Limitation: code is not type-safe
            //  i.e. type checking is not done at compile time.
// string - string , string - int ( class cast ) 
//use non-generic ArrayList()  , Add() , for-each() , (casting error in for-each) (// Casting error while get) 

#main2 
// Generic class - Box<T>
//      - obj
//      - Get(), Set() -- Generic methods
//      - Display() -- Non-generic method (okay) (print obj)
//	// int , string example 
// 	List<> add and print using for-each  


#main3
// static Generic method (ref keyword) 
//      - Swap<T>()
// int , double , string 

#main4 
// Non-Generic class - Util
//      - Swap<T>() - Generic method -- allowed ( above method ) 
//      - generic non-static method
//	-  int , double , string ( create Util object and call) 


// using Generic Interfaces
//      Emp class - Id , Name , Salary , Equals , ToString() , IComparable<Emp>
//      - IComparable & IComparer
            // Conventionally, CompareTo() compares two objects on the basis of
            //  identity of the object i.e. fields defining equality of the object.
		// if this is same as other, return 0
                // if this is greater than other, return +ve
                // if this is smaller than other, return -ve

//      - Emp array sorting
Emp[] arr = new Emp[5]
{
                new Emp { Id = 2, Name = "John", Salary = 2000.0 },
                new Emp { Id = 5, Name = "Mark", Salary = 1500.0 },
                new Emp { Id = 1, Name = "Steve", Salary = 3500.0 },
                new Emp { Id = 4, Name = "Peter", Salary = 4000.0 },
                new Emp { Id = 3, Name = "Tony", Salary = 3000.0 }
};
//Sort on ID using Comparable 

- IComparer
   - EmpNameComparer (sort on Name) 
   - EmpSalComparerDesc 



#main5
	// write a generic method, that will compare given two objects of same type
        // and return max -- comparison is made on basis of IComparable.
// Generic constraints

#main6 
//Create Student class ( Name , Roll , Marks) 
// Generic constraints
//      static T CreateObj<T>(){} 

*******************************************************************************
06_Delegates
// MathOp Delegate




**************************************************
