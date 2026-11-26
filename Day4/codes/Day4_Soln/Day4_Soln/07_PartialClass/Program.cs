namespace _07_PartialClass
{
    partial class MyClass
    {
        int x = 10;
        public partial void Display();
    }
    partial class MyClass
    {
        public void Method()
        {
            this.Display();
            Console.WriteLine("x : " + x);
        }
        public partial void Display()
        {
            Console.WriteLine("Display Method called");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.Display();
            obj.Method(); 
        }
    }
}
