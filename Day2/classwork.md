
Day02_Soln

#Hello world ( top-level statments) 


#02_Namespace

- ListSpace(Node- empty) , ListSpace( List - Add () )  , TreeSpace ( node() - empty , Tree( add) ) ( global using) 

-  // NamespaceName.ClassName
   
   // Tree & Node accessed directly because,
            // using TreeSpace is written on the top.


// /*
"global using" statement
    - Must be on the top -- like all other "using" statements.
    - The namespace need not to be imported in each file of the project.
        - It is globally imported in C# project.

*/

 - //  No need to import explicitly if "global using" done in other file.

 - using Gen = System.Collections.Generic; ( use list ) 
// Namespace alias -- Shorthand name for the namespace.


/*
+ Namespaces are logical containers (for types - classes, interfaces, ...).
    - Better code organization.
    - Namespaces are hierarchial (nested).
        - System
            |- System.Data
                  |- System.Data.SqlClient
                  |- System.Data.Oledb
    - Avoid name conflics
        - Can keep two classes with same name in different namespace.
            - e.g. Node class in ListSpace and TreeSpace.
    - To access namespace members
        - NamespaceName.ClassName
    - "using" statement will import the namespace,
        so that members can be accessed directly.

+ For each project by default one namespace created by Visual Studio.
    - One project (assembly) may contain multiple namespace.
    - Namespace can be split in the same file or across the files.
    - Namespace can also split across the assemblies.
*/
- //using TreeSpace;
//  No need to import explicitly if "global using" done in other file.


---------------------------------------------------------------------------------------
03_Datatypes  (refer notes ) (all) 

#  Type Conversion using Parse() (region)  
    // Convert string to int using Parse().
    // System.FormatException if string is not valid.

 - Type Conversion using Convert class (use method toInt32) (region) 
   // Convert string to int using Convert class.
   // System.FormatException if string is not valid.

#  main2 
   - // int divided by int -- yields int
   - // double divided by int -- yields double
   //   double / int --> double / double
   //  internally int is promoted to double
   // when double is assigned to float -- by default : Error
   //  data type is not auto demoted.
   //  need explicit casting for that.

# main3 
 - // short type range -- -32768 to +32767
        use unchecked (default behaviour) 
       // type overflow
       // accidental overflow may produce in wrong results
       // overflow will change the sign (roll over)

  - // type overflow ( checked) 
    // overflow is detected at runtime and will
    //  raise OverflowExcpetion.

 Note : In C# all exceptions are unchecked exceptions (Compared to java) 
  "Checked" & "unchecked" keywords are not exception types - They are for overflow check 

------------------------------------------------------------------------------------------------
04_StructEnum ( refer ppt) ( daigrams) 

 - // struct in C# -- for lightweight user defined types
    //  struct is value type -- local vars created on stack
- Struct Point ( _x , _y) , ctor , X and Y with get and Set , Display() , dtor not allowed 

- Region Struct Properties, Objects & Object Initializer
     -// local vars must be initialized before use(pt) 
     -  // struct is value type.
        //  local vars of value types gets memory on stack. ( use property) 
        //  pt1 memory is alloced on stack -- in spite of new operator
     - // initialized later using properties (pt2) 
     -   // initialize using Object Initializer
         //  internally first param less ctor / default ctor is called
         //  then properties setters are executed
     - #region Collection Object Initializer  using List<String> and printing using for-each 

- class Person(_age) , Age( get , set ( validation) ) , display() 
  Name -- >  get , set 
  // auto-implemented properties (since C# 3.0)
  //  auto creates a hidden field
  //  + creates oneliner getters/setters (no validation) 

-  Region Collection Object Initializer 
     -  // Initialize collection using Object Initializer ( use list (string), use for-each) 
-  Region Class Objects and Object Initializers

- main2 - Enum (At last for revison refer screesht) 
// enums are readable constants -- can be used in switch case
    // internally stored as "int" -- default type can be changed using inheritance.
    //  e.g. enum Weekday:short { ... }
    // enum ordinal nums start with 0
    

 -     #region Weekday enum (Simple Example)
       enum WeekDay  --  Region -- Weekday enum (Simple Example)
      
  - enum color 
 
     - region Color enum (Advanced Example - Duplicate values/Negative values)
       (Advanced Example - Duplicate values/Negative values)
 

   - #region How to use Enums practically 
     enum Menu (create enum Menu) 

----------------------------------------------------------------------------------------------
05_Boxing (refer notes) (refer ppt) 
#main1 
// Java Autoboxing Feature
            //   In Java, primitive types are not objects.
            //   To treat primitive types as objects, Java have wrapper classes.
            //   Till Java 1.4 -- Programmer need explicit casting/coding to convert
            //      primitive type to wrapper types & vice-versa.
            //   Java 5.0 -- Auto-boxing feature
            //      implicit conversion from primitive to wrapper and reverse.

- // C# Boxing and Unboxing Concept
            //  C# primitive types are implicitly converted to CTS types.
            //      e.g. int <--> Int32
            

    - int to object - Boxing (// int is value type)
    - object to int - unboxing ( downcasting) (// object is reference type)
                                               ref type to value type -- Unboxing

#main2 
    -  // ArrayList is internally list of "Objects".
         

    -  // C# 2.0 generic collections allows value types
            // No boxing/unboxing needed to use collections with primitive types
            // very fast
	 
       

------------------------------------------------------------------------------------------
//06_Methods 
// C# Methods 
  - Create the class MyInt ( Num ( get , set)  ) 

    // all static methods 
  - simple Swap method 
       // by default, primitive (value) types are passed by value -- args are "copied"
        // any change in formal args are not reflected in actual args


   - Swap2 method ( create reference of MyInt in parameter and swap) 
      - Create the object inside the main by MyInt and pass it to method and check
      - // by default, class (ref) types are passed by ref -- args addr are sent
      -  // any change in formal args are reflected in actual args

    - Swap3 - use ref keyword
         - // primitive (value) types are can be passed by ref using "ref" keyword
         - // any change in formal args are reflected in actual args

     - separate main2 (refer notes) 
          - calling divide method by out parameter 
          - divide method with out parameter 

      - separate main (refer screenSht at last for (greet -- modified) 
              // refer notes 
           - // Local function inside main => void PrintInfo ( name , age ,addres ( some val)  , email( som val) ) 
      
           - // calling PrintInfo() using positional arg -- as per arg seq

           - // calling PrintInfo() using named arg -
                // arg value associated with name of the arg -- more readable 
                // arg can be passed in any sequence

           -   // first two args are passed positional -- by seq
                // next two args are passed by name

           -   // calling PrintInfo() using default args
                // the not passed args will get their default values
                // all default args must be at the end.


--------------------------------------------------------------------------------------------------------
07_Inheritance (refer notes) 
# Inheritance Basics 
  - Person class ( Name , Age ( get , set ) , ctor , para ctor , displayperson() ) 
  - Emp class ( Id, Salary ( get , set ) , ctor , para ctor , displayEmp() ) ( Inheritance) 
 
  - create p1 on person and call DisplayPerson() 
  - Create e1 object and call DisplayEmp() 
  - upcasting and try to call DisplayEmp 


  - upcasting and print 
  - downcasting and print 
  - use as operator 
 

  













-----------
static void Main(string[] args)
{
    int num = 100;

    Display(in num);
}

static void Display(in int x)
{
    Console.WriteLine(x);

    // x = 200; // ERROR: Cannot modify an in parameter
}

