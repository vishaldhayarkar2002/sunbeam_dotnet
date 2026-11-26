using System.Collections;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Globalization;
using System.Xml.Linq;

namespace _06_GenericCollections
{
    internal class Program
    {
        static void Main2(string[] args)
        {
            // List<> - Generic collection
            //  Internally Dynamic Array - Grow/Shrink at Runtime
            //  Indexed-Based - Fast access
            //  Sequential Traversal - IEnumeration (foreach loop) 
            //  Record filtering - Where()
            List<int> nums = new List<int>();
            nums.Add(10);
            nums.Add(20);
            nums.Add(30);
            nums.Add(43);
            //nums.Add("50"); // Type safe 
            //for(int i = 0; i < nums.Count; i++)
            //{
            //    Console.WriteLine(nums[i]);
            //}

            /*
            // foreach loop internally use Enumerator
            //  while using Enumerator, if any element is modified,
            //      it will cause exception: InvalidOperationException
            foreach (int ele in nums)
            {
                Console.WriteLine(ele);
                if (ele == 30)
                    nums.Remove(30);   
            }*/
            // Option1 -- delete while traversal -- traverse over a snapshot.
            //      nums.ToList() creates a copy/snapshot of the list -- for-each 
            // deleting from nums (original collection) -- allowed
            //foreach (int ele in nums.ToList())
            //{
            //    Console.WriteLine(ele);
            //    if (ele == 30)
            //        nums.Remove(30);
            //}
            Console.WriteLine();
            /* // Element deleted from the List 
            foreach (int ele in nums)
            {
                Console.WriteLine(ele);
            }*/

            /*
            // Traversal using Enumerator -- internals of foreach loop 
            IEnumerator<int> en = nums.GetEnumerator(); 
            while(en.MoveNext())
            {
                int ele = en.Current;
                Console.WriteLine(ele);
            }*/
            //nums.ForEach(e => Console.WriteLine(e)); 

            IEnumerable<int> evenlist = nums.Where(e => e % 2 == 0);
            foreach (int ele in evenlist)
            {
                Console.WriteLine(ele);
            }
        }

        //Person class ( Age , Name , Address , ToString() ) 
        class Person : IEquatable<Person>
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public bool Equals(Person other)
            {
                if (other == null)
                    return false;
                return this.Name.Equals(other.Name);
            }

            public override string ToString()
            {
                return $"Age = {Age} , Name = {Name} , Address = {Address}";
            }
        }
        static void Main3(string[] args)
        {
            List<Person> list = new List<Person>()
             {
                    new Person() { Age = 65, Name="James", Address="London" },
                    new Person() { Age = 87, Name="Superman", Address="Crypton" },
                    new Person() { Age = 45, Name="Batman", Address="Gothom" },
             };
            list.Add(new Person() { Age = 77, Name = "Amit", Address = "Pune" });
            //traverse using for-each 
            //foreach (Person p in list)
            //{
            //    Console.WriteLine(p);
            //}


            // Method1 -- Write Equals() method
            //   Override Equals() from Object class -- Same as Java
            //   Limitation: Not type safe (arg is Object type).

            // Method2 -- Write Equals() method
            //   Implement IEquatable interface
            //   Advantage: Equals() method is type-safe.

            Console.WriteLine("Enter the Name : ");
            string name = Console.ReadLine();
            Person p = new Person() { Name = name };
            if (list.Contains(p))
                Console.WriteLine("Person found");
            else
                Console.WriteLine("Person not found");


        }

        static void Main4(string[] args)
        {
            //HashSet<> keeps unique elements only.
            //  It maintains the order of insertion.
            HashSet<int> set = new HashSet<int>();
            set.Add(10);
            set.Add(20);
            set.Add(30);
            set.Add(40);
            set.Add(40);
            Console.WriteLine("Count : " + set.Count);
            foreach (int ele in set)
            {
                Console.WriteLine(ele);
            }
        }

        static void Main5(string[] args)
        {
            // Stack<> - LIFO -- O(1) time complexity
            //      - Push() and Pop() operations
            Stack<int> stk = new Stack<int>();
            stk.Push(10);
            stk.Push(20);
            stk.Push(30);
            stk.Push(40);
            int ele = stk.Peek();
            //Console.WriteLine("ele : " + ele);
            while (stk.Count > 0)
            {
                int e = stk.Pop();
                Console.WriteLine(e);
            }
        }

        static void Main6(string[] args)
        {
            // Queue<> -- FIFO -- O(1) time complexity
            //      - Enqueue() and Dequeue() operations
            Queue<int> q = new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            q.Enqueue(40);
            int ele = q.Peek();
            //Console.WriteLine("ele : " +ele);
            while (q.Count > 0)
            {
                int e = q.Dequeue();
                Console.WriteLine(e);
            }
        }

        static void Main7(string[] args)
        {
            // Dictionary<> - Key-Value pairs for Faster searching
            //      - Add elements using Add() and indexer
            //      - Find by key using indexer -- KeyNotFoundException
            //      - Find by key using TryGetValue()
            //      - Remove() by Key
            //      - Traverse all KeyValuePair<> in dictionary
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("Nitin", "9881208115");
            map.Add("Nilesh", "9527331338");
            map.Add("Prashant", "9881208114");
            //foreach (KeyValuePair<string,string> pair in map)
            //{
            //    Console.WriteLine(pair.Key + "--->" + pair.Value);
            //}
            string name1 = "Nilesh1";
            string result;
            //if (map.TryGetValue(name1, out result))
            //{
            //    Console.WriteLine($"{name1} = {result}");
            //}
            //else
            //    Console.WriteLine("not found");


            //if key is found, the value will be returned.
            // if key is not found, the exception is thrown KeyNotFoundException
            // directly search from map using index if not found exception 
            string result1 = map[name1];
            Console.WriteLine($"{name1} = {result1}");
        }

        static void Main8(string[] args)
        {
            //LinkedList<> preferred for sequential traversal and
            //      - Add/Delete from both sides, frequent add/remove in middle.
            // Internally it is Doubly Linked List
            // This can also be used as "Dequeue" -- Double ended queue
            //      - Add/Delete at both ends is efficient -- O(1)
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            foreach (int e in list)
            {
                Console.WriteLine(e);
            }
            //int ele = list[2];  //random access / indexer is not supported
        }

        static void Main(string[] args)
        {
            // ImmutableList.Create() to build non-modifiable lists
            //      - Any changes creates a new list
            ImmutableList<string> colors = ImmutableList.Create("Red", "Black", "Grey");
            ImmutableList<string> newcolor = colors.Add("Blue");
            foreach (string e in colors)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            foreach (string e in newcolor)
            {
                Console.WriteLine(e);
            }
        }
    }
}
