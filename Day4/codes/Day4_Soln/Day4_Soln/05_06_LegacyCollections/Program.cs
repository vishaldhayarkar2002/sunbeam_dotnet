using System.Collections;

namespace _05_06_LegacyCollections
{
    internal class Program
    {
        // ArrayList
        // flexible - can store any type - object
        // grow/shrink at runtime
        // internally -- dynamically growing array
        // fast index-based access
        static void Main1(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add(20);
            list.Add(true);
            list.Add(11.33);
            list.Insert(2, 200);
            //foreach (object ele in list)
            //{
            //    Console.WriteLine(ele);
            //}
            list.RemoveAt(2);
            // random access -- using indexer syntax
            //   using indexes with objects
            for(int i = 1 ; i < list.Count ; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void Main(string[] args)
        {
            //key - value pair-- Fast searching
            Hashtable map = new Hashtable();
            map.Add(1, "Amit");
            map.Add(2, "Sagar");
            map.Add(3, "Rahul");
            map.Add(4, "Aniket");
            //map.Add(4, "Aniket"); // duplicate key : ArgumentException: Item has already been added
            Console.WriteLine("Enter the roll : ");
            int roll = Convert.ToInt32(Console.ReadLine());
            string value = (string)map[roll];
            Console.WriteLine(value);
        }
    }
}
