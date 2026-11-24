using System;
using System.Collections.Generic;
using System.Text;
using Gen = System.Collections.Generic;
// Namespace alias -- Shorthand name for the namespace.
namespace _01_Namespace
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            //  No need to import explicitly if "global using" done in other file.
            Tree t2 = new Tree();
            t2.Add(10);
            t2.Add(20);
            t2.Add(30);
            Gen.List<int> list = new Gen.List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
        }
    }
}
