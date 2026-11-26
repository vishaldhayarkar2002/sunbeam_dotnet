using System.Net.Http.Headers;

namespace _03_GenericDelgates
{
    // user-defined generic delegates
    //delegate void Consumer<T>(T obj);   // like Java Consumer
    //      Console.WriteLine()
    //delegate T Supplier<T>();           // like Java Supplier
    //      new Random().next()
    //delegate R Function<T, R>(T obj);   // like Java Function
    //      int.Parse()
    //delegate bool Condition<T>(T obj);  // like Java Predicate
    //      is Even ?

    internal class Program
    {
        delegate void Consumer<T>(T obj);  // like Java Consumer

        delegate T Supplier<T>(); // like Java Supplier

        delegate R Function<T, R>(T obj); // like Java Function

        delegate bool Condition<T>(T obj);  // like Java Predicate

        static void Main1(string[] args)
        {
            Consumer<string> con = Console.WriteLine;
            con("Hello world");

            Random r = new Random();
            Supplier<int> supp = r.Next;
            Console.WriteLine(supp());

            Function<string, int> Convert = int.Parse;
            int num = Convert("123");
            Console.WriteLine("num : " + num);

            Condition<int> isEven = (a) => a % 2 == 0;
            Console.WriteLine(isEven(10));


        }


        // "built-in" generic delegates
        // delegate void Action<T>(T obj);
        //      Console.WriteLine()
        // delegate R Func<T,R>(T obj);
        //      int.Parse()
        // delegate R Func<R>();
        //      new Random().next()
        // delegate bool Predicate<T>(T obj);
        //      is Odd ?

        static void Main(string[] args)
        {
            Action<string> con = Console.WriteLine;
            con("Hello world");

            Func<string, int> Convert = int.Parse;
            int num = Convert("123");
            Console.WriteLine("num : " + num);

            Random r = new Random();
            Func<int> f = r.Next;
            Console.WriteLine(f());

            Predicate<int> isEven = (a) => a % 2 == 0;
            Console.WriteLine(isEven(10));
        }
    }
}
