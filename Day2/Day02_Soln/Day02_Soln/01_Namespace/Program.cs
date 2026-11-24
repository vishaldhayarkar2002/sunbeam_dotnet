global using TreeSpace;
/*
"global using" statement
    - Must be on the top -- like all other "using" statements.
    - The namespace need not to be imported in each file of the project.
        - It is globally imported in C# project.

*/
namespace ListSpace
{
    class Node
    {

    }
}
namespace ListSpace
{
    class List
    {
        public void Add(int data)
        {
            Console.WriteLine($"List.Add({data})");
        }
    }
}
namespace TreeSpace
{
    class Node
    {

    }
    class Tree
    {
        public void Add(int data)
        {
            Console.WriteLine($"Tree.Add({data})");
        }
    }
}
namespace _01_Namespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListSpace.Node n1 = new ListSpace.Node();
            ListSpace.List l1 = new ListSpace.List();
            l1.Add(10);
            l1.Add(20);
            l1.Add(30); 

            Tree t1 = new Tree();
            t1.Add(10);
            t1.Add(20);
            t1.Add(30); 

        }
    }
}
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