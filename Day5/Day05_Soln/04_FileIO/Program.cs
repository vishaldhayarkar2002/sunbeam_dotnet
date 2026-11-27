using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _04_FileIO
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            const string FilePath = "D:/test1.txt";
            // helper class -- File -- write text in file
            Console.Write("Enter Text: ");
            string line = Console.ReadLine();
            File.AppendAllText(FilePath, line); // internally use FileStream for write op

            // helper class -- File -- read text from file
            string text = File.ReadAllText(FilePath); // internally use FileStream for read op
            Console.WriteLine(text);

            // to delete file
            //File.Delete(FilePath);
        }
        static void Main2(string[] args)
        {
            // list all drives
            string[] drives = Directory.GetLogicalDrives();
            foreach (var item in drives)
                Console.WriteLine("Drive: " + item);
            // list dir contents
            string DirPath = @"D:\Nilesh\Aug25\DAC\dotnet\day05\Day05_Soln";
            var files = Directory.EnumerateFiles(DirPath);
            foreach (var file in files)
                Console.WriteLine("FILE: " + file);
            var dirs = Directory.EnumerateDirectories(DirPath);
            foreach(var dir in dirs)
                Console.WriteLine("DIR: " + dir);
        }
        static void Main3(string[] args)
        {
            // Write data into "text file".
            const string FilePath = @"D:\test2.txt";
            // create FileStream object
            FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
            // create StreamWriter on FileStream
            StreamWriter wr = new StreamWriter(fs);
            // write data using StreamWriter
            wr.WriteLine("Hello, DAC!");
            wr.Write(123);
            wr.WriteLine(); // new line
            wr.Write(true);
            wr.WriteLine(); // new line
            wr.Write(3.14);
            wr.WriteLine(); // new line
            // close StreamWriter
            wr.Close();
            // close FileStream 
            fs.Close();
            Console.WriteLine("File Saved.");
        }
        static void Main4(string[] args)
        {
            const string FilePath = @"D:\test2.txt";
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fs);
            while (true)
            {
                string line = rd.ReadLine();
                if(line == null)
                    break;
                Console.WriteLine(line);
            }
            rd.Close();
            fs.Close();
        }
        [Serializable]
        class Person
        {
            public string Name { get; set; }
            [NonSerialized] // can only be applied on fields / not properties
            private int age;
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
            public override string ToString()
            {
                return $"Person : Name = {Name}, Age = {Age}";
            }
        }
        static void Main(string[] args)
        {
            // create obj to serialize
            Person p1 = new Person() { Name = "Bill", Age = 44 };
            // create BinaryFormatter (deprecated)
            BinaryFormatter bf = new BinaryFormatter();
            // create FileStream -- for writing
            const string FilePath = @"D:/test3.bin";
            FileStream fsOut = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            // serialize the object using formatter into the stream
            bf.Serialize(fsOut, p1);
            // close FileStream
            fsOut.Close();

            FileStream fsIn = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            Person p2 = (Person)bf.Deserialize(fsIn);
            Console.WriteLine("p2 = " + p2);
        }
    }
}
