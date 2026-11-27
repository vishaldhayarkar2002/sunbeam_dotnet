namespace _03_Linq
{
    // ERROR: var - only for local variables
    //class Test
    //{
    //    var variable; // not allowed for class fields
    //}
    internal class Program
    {
        static void Main1(string[] args)
        {
            // var local variables -- statically typed
            // var keyword - data type is inferred by compiler.
            var num = 123;
            var flag = true;
            var str = "Sunbeam";
            var number = 3.14;

            // ERROR: var cannot re-assigned to another type
            //number = "ABCD";
            
            // var with objects of any class
            var list = new List<string>();
            list.Add("ABC");
            list.Add("PQR");
            foreach(var item in list)
                Console.WriteLine(item);

            // var must be initialized at declaration
            //var test1;

            // var cannot be initialized to null
            //var test2 = null;
        }

        static void Main2(string[] args)
        {
            // anonymous type -- 
            // can only hold readonly data (fields) -- typically assigned to "var" ref
            var p1 = new { Roll = 1, Name = "Ketan", Marks = 23.4 };
            // what is Type of anonymous?
            Console.WriteLine("p1 type: " + p1.GetType()); // <>f__AnonymousType0`3[System.Int32,System.String,System.Double]
            // Can access fields (auto-implemented props) on ref
            Console.WriteLine("Roll = " + p1.Roll + ", Name = " + p1.Name + ", Marks = " + p1.Marks);
            // ToString(), Equals(), HashCode() - auto-implemented
            Console.WriteLine("p1 = " + p1.ToString());
            var p2 = new { Roll = 1, Name = "Ketan", Marks = 23.4 };
            if(p1.Equals(p2))
                Console.WriteLine("p1 same as p2");
            else
                Console.WriteLine("p1 different than p2");
            // you cannot implement any method explicitly in anonymous type.

            // collection of anonymous type object
            var arr = new []
            {
                new { Roll = 1, Name="Student1" },
                new { Roll = 2, Name="Student2" },
                new { Roll = 3, Name="Student3" },
                //new { Roll = 4, Name="Student4", Marks = 32.3 }, // all elems of array must be of same type
            };
            // traverse using foreach loop
            foreach(var item in arr)
                Console.WriteLine(item);

            var list = new[]
            {
                new { Name="P1", Age=12},
                new { Name="P2", Age=23}
            }.ToList();
            Console.WriteLine("list type: " + list.GetType());
        }


        static void Main(string[] args)
        {
            // LINQ -- SQL like features in C# language
            //  LINQ can be used on Collections, XML, Database, etc.
            List<Emp> emps = new List<Emp>
            {
                new Emp { EmpId = 7369, Ename = "SMITH", Job = "CLERK", ManagerId = 7902, Hire = DateTime.Parse("1980-12-17"), Salary = 800.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7499, Ename = "ALLEN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-20"), Salary = 1600.00, Commission = 300.00, DeptId = 30 },
                new Emp { EmpId = 7521, Ename = "WARD", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-02-22"), Salary = 1250.00, Commission = 500.00, DeptId = 30 },
                new Emp { EmpId = 7566, Ename = "JONES", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-04-02"), Salary = 2975.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7654, Ename = "MARTIN", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-28"), Salary = 1250.00, Commission = 1400.00, DeptId = 30 },
                new Emp { EmpId = 7698, Ename = "BLAKE", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-05-01"), Salary = 2850.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7782, Ename = "CLARK", Job = "MANAGER", ManagerId = 7839, Hire = DateTime.Parse("1981-06-09"), Salary = 2450.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7788, Ename = "SCOTT", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1982-12-09"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7839, Ename = "KING", Job = "PRESIDENT", ManagerId = null, Hire = DateTime.Parse("1981-11-17"), Salary = 5000.00, Commission = null, DeptId = 10 },
                new Emp { EmpId = 7844, Ename = "TURNER", Job = "SALESMAN", ManagerId = 7698, Hire = DateTime.Parse("1981-09-08"), Salary = 1500.00, Commission = 0.00, DeptId = 30 },
                new Emp { EmpId = 7876, Ename = "ADAMS", Job = "CLERK", ManagerId = 7788, Hire = DateTime.Parse("1983-01-12"), Salary = 1100.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7900, Ename = "JAMES", Job = "CLERK", ManagerId = 7698, Hire = DateTime.Parse("1981-12-03"), Salary = 950.00, Commission = null, DeptId = 30 },
                new Emp { EmpId = 7902, Ename = "FORD", Job = "ANALYST", ManagerId = 7566, Hire = DateTime.Parse("1981-12-03"), Salary = 3000.00, Commission = null, DeptId = 20 },
                new Emp { EmpId = 7934, Ename = "MILLER", Job = "CLERK", ManagerId = 7782, Hire = DateTime.Parse("1982-01-23"), Salary = 1300.00, Commission = null, DeptId = 10 }
            };
            Console.WriteLine("All Emps:");
            var empresult = from e in emps select e;
            foreach(var e in empresult)
                Console.WriteLine(e);

            List<Dept> depts = new List<Dept>
            {
                new Dept { DeptId = 10, Dname = "Accounting", Location = "New York" },
                new Dept { DeptId = 20, Dname = "Research", Location = "Dallas" },
                new Dept { DeptId = 30, Dname = "Sales", Location = "Chicago" },
                new Dept { DeptId = 40, Dname = "Operations", Location = "Boston" }
            };
            Console.WriteLine("\nAll Depts:");
            var deptresult = from d in depts select d;
            foreach(var d in deptresult) 
                Console.WriteLine(d);

            #region Linq Method Syntax -- Basic Linq Operator
            Console.WriteLine("\nEmps with Sal > 2000:");
            // SELECT * FROM emps WHERE sal > 2000;
            var res1 = emps.Where(e => e.Salary > 2000);
            foreach (var e in res1) 
                Console.WriteLine(e);

            Console.WriteLine("\nEmps Sorted by Dept & By Job:");
            // SELECT * FROM emps ORDER BY deptno, job
            var res2 = emps.OrderBy(e => e.DeptId).ThenByDescending(e => e.Job);
            foreach (var e in res2)
                Console.WriteLine(e);

            Console.WriteLine("\nEmp Name & Sal");
            // SELECT ename, sal FROM emps;
            var res3 = emps.Select(e => new { Name = e.Ename, Salary = e.Salary });
            foreach (var e in res3)
                Console.WriteLine(e);

            var res4 = emps.Sum(e => e.Salary); // Avg(), Min(), Max(), Count()
            Console.WriteLine("\nSum of Sal: " + res4);

            #endregion

            #region Linq Method Syntax vs Query Syntax
            // get all emps with sal > 2000 in sorted order of their name.
            //  SELECT * FROM emps WHERE sal > 2000 ORDER BY ename;
            Console.WriteLine("\nEmps with Sal > 2000 in Sorted Order of Name: ");
            var res5 = emps.Where(e => e.Salary > 2000).OrderBy(e => e.Ename);
            foreach (var e in res5)
                Console.WriteLine(e);

            Console.WriteLine("\nEmps with Sal > 2000 in Sorted Order of Name Desc: ");
            var res6 = from e in emps
                       where e.Salary> 2000
                       orderby e.Ename descending
                       select e;
            foreach (var e in res6)
                Console.WriteLine(e);

            Console.WriteLine("\nNames & Sals of all Emps in Dept 10");
            // SELECT ename, sal FROM emps WHERE deptno=10;
            var res7 = from e in emps
                        where e.DeptId == 10
                        select new {Name=e.Ename,Salary=e.Salary};
            foreach (var e in res7)
                Console.WriteLine(e);

            #endregion

            #region Linq Hybrid - Query + Method Syntax
            Console.WriteLine("\nTop 3 Emps w.r.t. Sal: ");
            // SELECT * FROM emps ORDER BY sal DESC LIMIT 3;
            var res8 = from e in emps
                       orderby e.Salary descending
                       select e;
            var res9 = res8.Take(3); // no LIMIT clause in LINQ query syntax
            foreach (var e in res9)
                Console.WriteLine(e);

            #endregion

            #region Linq Advanced - Join
            Console.WriteLine("\nEmps & Depts Joined : Ename and Dname ...");
            // SELECT e.ename, d.dname FROM emps e JOIN depts d ON e.deptno = d.deptno;
            var resJoin = from e in emps
                          join d in depts on e.DeptId equals d.DeptId
                          select new { EmpName = e.Ename, DeptName = d.Dname };
            foreach (var e in resJoin)
                Console.WriteLine(e);
            #endregion
        }

    }
    public class Emp
    {
        public int EmpId { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? ManagerId { get; set; }
        public DateTime Hire { get; set; }
        public double Salary { get; set; }
        public double? Commission { get; set; }
        public int DeptId { get; set; }

        public override string ToString()
        {
            return $"Emp -> Id: {EmpId}, Name: {Ename}, Job: {Job}, Manager: {ManagerId}, Hire: {Hire.ToShortDateString()}, Salary: {Salary}, Comm: {Commission}, Dept: {DeptId}";
        }
    }
    public class Dept
    {
        public int DeptId { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }
        public override string ToString()
        {
            return $"Dept -> Id: {DeptId}, Name: {Dname}, Location: {Location}";
        }
    }
}
