namespace _02_Nullable
{
    internal class Program
    {
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

        static void Main1(string[] args)
        {
            // Nullable "value types" safe access -- HasValue
            // Nullable<type> or type?
            int num1 = 123;
            //int num2 = null;  // primitive types cannot be null
            Nullable<int> num3 = 456; // Nullable<> type can have value or null
            if(num3.HasValue)
                Console.WriteLine("num3 = " + num3);
            else
                Console.WriteLine("num3 is null");
            int? num4 = null; // Nullable<> type can have value or null
            if(num4.HasValue)
                Console.WriteLine("num4 = " + num4);
            else
                Console.WriteLine("num4 is null");
            Console.WriteLine("num4 (value or default) = " + num4.GetValueOrDefault());
        }

        // Nullable reference types
        //  - Reference types can be null (by default).
        //  - Compiler checks (Safety measure) -- The reference may be null.
        //  - If such nullable ref type is used directly, compiler will raise warning.
        // Safe method calls -- ?.
        static void Main2(string[] args)
        {
            string s1 = "Sunbeam";
            Console.WriteLine("s1 Caps: " + s1.ToUpper()); // SUNBEAM

            string s2 = null;
            //Console.WriteLine("s2 Caps: " + s2.ToUpper()); // NullReferenceException

            string? s3 = null;
            //Console.WriteLine("s3 Caps: " + s3.ToUpper()); // NullReferenceException
            // Compiler warns -- s3 may be null

            string? s4 = "dac"; // = null;
            Console.WriteLine("s4 Caps: " + s4?.ToUpper());
            // ?. -- first check if ref is null; and if not null, then only call the method on it
            //    -- if ref found to be null, ignores the call
        }
        // Nullable coalesce operator -- ??
        static void Main(string[] args)
        {
            string addr = null; // "Mumbai";
            string def_addr = "Pune";

            // if addr is present, assign it; otherwise assign def_addr
            string person_addr1 = addr;
            if (addr == null)
                person_addr1 = def_addr;

            // if addr is present, assign it; otherwise assign def_addr
            string person_addr2 = addr == null ? def_addr : addr;

            // if addr is present, assign it; otherwise assign def_addr
            string person_addr3 = addr ?? def_addr;
            Console.WriteLine("add3 = " + person_addr3);
        }
    }
}
