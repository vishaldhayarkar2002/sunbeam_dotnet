##01_Events 
// BalanceHanlder delegate (account, amount)
// class Account
//     - Id , Type , Balance , LowBalance
//     - Deposit() and Withdraw()
//     - LowBalance event

// HdfcBank 
	- SendLowBalanceSMS(); 
        - TestTrasactions();  
// Banks handling LowBalance with different strategies
//      and TestTransaction() method.
//  Bank1
//     - Send SMS
//  Bank2
//     - Send SMS & Email
//  Bank3
//     - Phone Call

*************************************************************
// BalanceHandler delegate signature is standardized.
//      (Account acc, BalanceEventArgs e)
// BalanceEventArgs inherited from EventArgs to keep TxTime and Amount.

##02_ImprovedEvents 
//BalanceEventArgs => TxAmmount(get,set) , TxTime(get,set) 

// BalanceHanlder delegate (account, amount)
// class Account
//     - Id , Type , Balance , LowBalance
//     - Deposit() and Withdraw()
//     - LowBalance event

// HdfcBank 
	- SendLowBalanceSMS(); 
        - TestTrasactions();  
// Banks handling LowBalance with different strategies
//      and TestTransaction() method.
//  Bank1
//     - Send SMS
//  Bank2
//     - Send SMS & Email
//  Bank3
//     - Phone Call


*************************************************************************
04_GenericDelegates 

// user-defined generic delegates
//delegate void Consumer<T>(T obj);   // like Java Consumer
//      Console.WriteLine()
//delegate T Supplier<T>();           // like Java Supplier
//      new Random().next()
//delegate R Function<T, R>(T obj);   // like Java Function
//      int.Parse()
//delegate bool Condition<T>(T obj);  // like Java Predicate
//      is Even ?

// "built-in" generic delegates
// delegate void Action<T>(T obj);
//      Console.WriteLine()
// delegate R Func<T,R>(T obj);
//      int.Parse()
// delegate R Func<R>();
//      new Random().next()
// delegate bool Predicate<T>(T obj);
//      is Odd ?

***********************************************************************
// 05_Arrays
 //      - Initialization (new) & Display
//	  -if array is initialized at declaration, new keyword is optional.(using new , using {} ) 
	  -print length  , print array elements (for-each) , using for loop 



// 	 - UnInitialization (default value) 
               - create double array using new 
	       - print the array 
 // uninitialized array -- will get default value ( comment ) 
            //    default of respective value type e.g. 0, 0.0, false, ...
            //    default of reference type -- null  


//	 -  Sort the array ( create the new array) 
	       - Arrays.sort();  			
	

// main2 
       -  // 1-D array of reference type  (   // uninitialized references are null) 
 		eg : string 

// main3 
// 2-D array in C#
            // Each row must have same number of columns
// 2-D arrays
//      - int[,] mat = new int[3, 3]
	  // init it and print it 

// main4 
// Jagged arrays
//      - int[][] mat = new int[3][];
	 // init it after decln and print it 


//main5 
// params keyword
//        - int AddAll(params int[] nums) //non static method --  add of all elems of the array 
//      - Sum all numbers passed to a function

//main6
// object[] array - Flexible for all types ( int , double , boolean , DatTime) 

----------------------------------------------------------------------------------

- 06_LegacyCollections 
   -  // ArrayList
        // flexible - can store any type - object
        // grow/shrink at runtime
        // internally -- dynamically growing array
        // fast index-based access
   - Create object ArrayList from (non - generic) 
          - Add() , Add - DateTime , Add - boolean ,  
          - Insert() --   at position 
          - RemoveAt() 
          - print using for-each 
	   // random access -- using indexer syntax
           //   using indexes with objects	
          


-- main2 
    - // Hashtable -- -- map - Key-value pair -- Fast searching by Key  - Roll , name 
	- Add() 
        - try to add duplicate key  --  // ArgumentException: Item has already been added
	- 
           
-----------------------------------------------------------------------------------------------------
07_GenericCollections
	 // List<> - Generic collection
        //  Internally Dynamic Array - Grow/Shrink at Runtime
        //  Indexed-Based - Fast access
        //  Sequential Traversal - IEnumeration (foreach loop) 
        //  Record filtering - Where()

  - Create the Generic List
      - Add() -- int , string - Error (nums) 
      - print the list using using simple for-loop() (nums.count) 


      -  // foreach loop internally use Enumerator
         //  while using Enumerator, if any element is modified,
         //      it will cause exception: InvalidOperationException
	 //for-each  (use remove) 

      -  // Option1 -- delete while traversal -- traverse over a snapshot.
         //      nums.ToList() creates a copy/snapshot of the list -- for-each 
         // deleting from nums (original collection) -- allowed
  	 // use for-each 
		// print the count of elements inside the list outside the loop 


      - // Traversal using Enumerator -- internals of foreach loop 
              - movenext() , current 

      - IEnumerable<int> evennums -- nums.where()



 - Main2 
    - Person class ( Age , Name , Address , ToString() ) 
    - Equals() -- IEquatable ( compare name) 
    - in main create Person Objects 
	 List<Person> list = new List<Person>()
         {
                new Person() { Age = 65, Name="James", Address="London" },
                new Person() { Age = 87, Name="Superman", Address="Crypton" },
                new Person() { Age = 45, Name="Batman", Address="Gothom" },
         };
	// add one using add() method (obj init) 
    - traverse using for-each 
    - enter the name ( and put inside the object ) 
    - create one Person and use as  name  as object init 
    -check if name is there ( use contains) from list 
       // Contains() or similar searching methods internally calls Equals() on each elem
            //  until at least one element is found (or list is completed).
            // Method1 -- Write Equals() method
            //   Override Equals() from Object class -- Same as Java
            //   Limitation: Not type safe (arg is Object type).
            // Method2 -- Write Equals() method
            //   Implement IEquatable interface
            //   Advantage: Equals() method is type-safe.


  - Main3 
     - 
        // HashSet<> keeps unique elements only.
        //  It maintains the order of insertion.
     - HashSet  -- int  -- (nums)  
     - Add() , print Count() , print using for-each 


  - Main4
    - // Stack<> - LIFO -- O(1) time complexity
        //      - Push() and Pop() operations
    - Stack -- int 
    - push() , peek() , pop() ( use stk.cout > 0 condtn)  

  - Main5 
     // Queue<> -- FIFO -- O(1) time complexity
        //      - Enqueue() and Dequeue() operations
   - Queue-- int 
   - Enqueue () , peek() , Dequeue() 


  - Main6 
      // Dictionary<> - Key-Value pairs for Faster searching
        //      - Add elements using Add() and indexer
        //      - Find by key using indexer -- KeyNotFoundException
        //      - Find by key using TryGetValue()
        //      - Remove() by Key
        //      - Traverse all KeyValuePair<> in dictionary

   - // Dictionary -- Map -- Name (string) and Mobile (string) Numbers
      - map.Add("Nitin", "9881208115");
        map.Add("Nilesh", "9527331338");
        map.Add("Prashant", "9881208114");
    - 

    - try adding duplicate key -- exception -- // ArgumentException: An item with the same key has already been added

    - search value from given key 
       - hardcode the key(name) , declare the result 
       - use TryGetValue(name , out result) 

    - // if key is found, the value will be returned.
      // if key is not found, the exception is thrown KeyNotFoundException
      // directly search from map using index if not found exception 
   	 - string mobile 	


  - Main7 
      // LinkedList<> preferred for sequential traversal and
        //      - Add/Delete from both sides, frequent add/remove in middle.
        // Internally it is Doubly Linked List
        // This can also be used as "Dequeue" -- Double ended queue
        //      - Add/Delete at both ends is efficient -- O(1)

   - Create linkedlist -- string -- AddLast() , duplicates are allowed , print using for-each 
   - names[2] -- random access / indexer is not supported

  - Main8 
    - // ImmutableList.Create() to build non-modifiable lists
        //      - Any changes creates a new list
    
----------------------------------------------------------
08_Partial Class 


