01_static 
  #  
  - using static -- (Console)
     - 
 
   - 
     // declare the class MyClass (sealed) 
     // const field must be initialized at declaration
     // const field cannot be static
     // const increase readbility of the code (like C macros)
     // eg : PI ( public - static) 

  - // readonly fields are one-time initializable (at declaration or in constructor)
   // readonly fields can be static or non-static
   

     // no access specifier - for static constructor
     // no overloading -- static ctor	
 
  # 
   - // MyClass & String extensions
     // extension methods of MyClass
    // rule 1: the first arg must be object of MyClass with "this" keyword (  ( MyClassExtensions) )  ( ExtDisplay ) 
    // rule 2: must be static method of the static class (top-level)
   // create the object of MyClass obj and call extdisp() method 

   -  // extension methods of string class e.g. SwapCase() (should be public static) 
       

  #  
   -  // interface with abstract static methods ensure that sub-class
      //  must have static method - specially useful to have generic algo	
      

  - // operator overloading in C# class/struct
    //  - must be static method named as operator(sign).
    //  - number of args must be as per the operator requirement i.e. unary, binary.
    //  - not all operators can be overloaded.
    // operator+(), operator==(), operator!=() , ToString() 
  - 

 # 
   Singleton class 
   - FileLogger  ( class ) 
   
   

----------------------------------------------------------------------------------

02_Nullable 

 class Emp
        {
            int empno;
            string ename;
            string job;
            int? mgr; // mgr value may be null
            DateTime hire;
            double sal;
            double? comm; // comm value may be null
            int deptno;
        } 

# 
  - // Nullable "value types" safe access -- HasValue
    // Nullable<type> or type?
     
    // primitive with value ( num1 ) 
   
    // primitive types cannot be null 

    // Nullable<> type can have value or null --
    
    // Nullable<> type can have value or null 

    // GetValueOrDefault() 	


# 
// Nullable reference types
        //  - Reference types can be null (by default).
        //  - Compiler checks (Safety measure) -- The reference may be null.
        //  - If such nullable ref type is used directly, compiler will raise warning.
        // Safe method calls -- ?.

  - strings 
  

#
 
        // Nullable reference types
        //  - Reference types can be null (by default).
        //  - Compiler checks (Safety measure) -- The reference may be null.
        //  - If such nullable ref type is used directly, compiler will raise warning.
        // Safe method calls -- ?. 
   
    
   // Nullable coalesce operator -- ??
           
#
class Emp
        {
            int empno;
            string ename;
            string job;
            int? mgr; // mgr value may be null
            DateTime hire;
            double sal;
            double? comm; // comm value may be null
            int deptno;
        }

------------------------------------------------------------------------------------------------------
03_Linq 

# main1  
- // ERROR: var - only for local variables
    //  not allowed for class fields ( test class) 


-  // var local variables -- statically typed
   // var keyword - data type is inferred by compiler.
      - usig var with int , bool , string , double 
      - // ERROR: var cannot re-assigned to another type ( cannot change ) 

    // var with objects of any class
       - var - list (string) (generic)  , add()  , print using for-each 	
    // var must be initialized at declaration
    // var cannot be initialized to null 

# main2 
   // anonymous type -- 
        // can only hold readonly data (fields) -- typically assigned to "var" ref
         - create the new object using var p1 (for Student (no student class required)) , check the type ( gettype method) 
         // Can access fields (auto-implemented props) on ref
          - print name , roll, marks 
       // ToString(), Equals(), HashCode() - auto-implemented
         
        // you cannot implement any method explicitly in anonymous type.
  
   //collection of anonymous type object ( arr )
       - create the arr from var ( use new Roll , Name)  , allocate some objects ( all elems of array must be of same type) 
       - print using for-each 
  
 
# main3 
  // LINQ -- SQL like features in C# language
     //  LINQ can be used on Collections, XML, Database, etc.  

   - create the class Emp and Dept ( copy the classes)  
   - Add some emps 
       - LINQ query ( SELECT QUERY) ( var empresult)    (  Query Syntax )  
   - create some List depts  ( add some depts) 
       - LINQ query ( SELECT QUERY) ( var deptresult)   ( Query Syntax ) 

   -  #region Linq Method Syntax -- Basic Linq Operator
       -Console.WriteLine("\nEmps with Sal > 2000:");
	    // SELECT * FROM emps WHERE sal > 2000;
       - 

    -  Console.WriteLine("\nEmps Sorted by Dept & By Job:");
        -   // SELECT * FROM emps ORDER BY deptno, job
        - 

    -  Console.WriteLine("\nEmp Name & Sal");
            // SELECT ename, sal FROM emps; 
            // Select(e => new{})
       - calculate total of salary( use sum() )
           // Avg(), Min(), Max(), Count()

------------

     -  #region Linq Method Syntax vs Query Syntax
            // get all emps with sal > 2000 in sorted order of their name.
            //  SELECT * FROM emps WHERE sal > 2000 ORDER BY ename; ( refer this) 
            Console.WriteLine("\nEmps with Sal > 2000 in Sorted Order of Name: ");

              // use query syntax now 
            -  Console.WriteLine("\nEmps with Sal > 2000 in Sorted Order of Name Desc: ");
	      
 	     - use query Syntax 	
	     - Console.WriteLine("\nNames & Sals of all Emps in Dept 10");
              - // SELECT ename, sal FROM emps WHERE deptno=10;
		


----------------------------------------------------------------------------------------------------------

04_FileIO 

# main1 
 - const string FilePath = "D:/test1.txt";
 - // helper class -- File -- write text in file
    // Take the input from user 
    // using ReadLine() read in variable line 
    // use File.AppendAllText() 

 -   // helper class -- File -- read text from file
     // read into variable text using File.ReadAllText(); 
     // print the data 
     // delete the file 


# main2 
   - 
   - // list all drives drives -- Directory.GetLogicalDrives(); -- return string array 
        // will print drives  , all for-each 
  
   -  // list dir contents
         -string DirPath = @"C:\Users\sunbeam\Desktop\MSDOTNET\Day4\Day04_Soln";
         - Directory.EnumerateFiles() 
         - Directory.EnumerateDirectories()
            

#main3 
   - 
      // create StreamWriter on FileStream

      // write data using StreamWriter

#main4 
   - const string FilePath = @"D:\test2.txt";
   - create FileStream object ( path , FileMode , FileAccess) 
   - streamreader object 
   - read the file using while loop 
   - close both streams 

#main5
   -  
   - create Person Name , age , Age 
   -  [NonSerialized] // can only be applied on fields / not properties

   -  // create obj to serialize

   -   // create BinaryFormatter (deprecated) (check the notes) 
       

	
 
















List<Dept> depts = new List<Dept>
            {
                new Dept { DeptId = 10, Dname = "Accounting", Location = "New York" },
                new Dept { DeptId = 20, Dname = "Research", Location = "Dallas" },
                new Dept { DeptId = 30, Dname = "Sales", Location = "Chicago" },
                new Dept { DeptId = 40, Dname = "Operations", Location = "Boston" }
            };


----------------
var arr = new[]
{
    new {Name = "Aditya" , Marks = 44},
    new {Name = "Aditya" , Marks = 44},
    new {Name = "Aditya" , Marks = 44}
}; 
--------------------

Console.WriteLine("\nEmps with Sal > 2000 in Sorted Order of Name Desc: ");
var res6 = from e
           in emps
           where e.Salary > 2000 orderby e.Ename descending
           select e;  

------------------------------------------------------------------

 var res7 = from e
            in emps
            where e.DeptId == 10 
            select new {Name = e.Ename , Sal = e.Salary};

-----
var emplist = from e in emps select e;