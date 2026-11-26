namespace _04_Arrays
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            int[] arr1 = new int[5] {1, 2, 3, 4, 5};
            Console.WriteLine("Length : " + arr1.Length);
            //foreach (int i in arr1)
            //{
            //    Console.WriteLine("ele :  " +i);
            //}
            int[] arr2 = new int[5];
            //foreach (int e in arr2)
            //{
            //    Console.WriteLine(e);
            //}
            int[] arr3 = new int[5] { 3, 1, 4, 6, 2 };
            Array.Sort(arr3, (x, y) => y - x);
            foreach (int e in arr3)
            {
                Console.WriteLine("ele : " +e);
            }
        }

        static void Main2(string[] args)
        {
            string[] arr3 = new string[3];   // by default contains null 
            foreach (string str in arr3)
            {
                Console.WriteLine("str : " + str);
            }
        }

        static void Main3(string[] args)
        {
            // 2-D array in C#
            int[,] arr3 = new int[3, 3]
            {
                {10,20,30},
                {20,30,40},
                {50,60,70}
            }; 
            for(int i = 0; i < 3; i++)
            {
                for(int  j = 0;  j < 3; j++)
                {
                    Console.Write(arr3[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main4(string[] args)
        {
            int[][] arr = new int[4][]; // Jagged Array in C# 
            arr[0] = new int[1] { 10 };
            arr[1] = new int[2] { 10, 20 };
            arr[2] = new int[3] { 10, 20 ,30};
            arr[3] = new int[4] { 10, 20, 30 , 40 };
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main5(string[] args)
        {
            int AddAll(params int[] arr)
            {
                int total = 0;
                foreach (int e in arr)
                {
                    total = total + e; 
                }
                return total; 
            }
            Console.WriteLine("AddAll(1,2) : " + AddAll(1,2));
            Console.WriteLine("AddAll(1,2) : " + AddAll(1, 2 , 3));
            Console.WriteLine("AddAll(1,2) : " + AddAll(1, 2, 3 , 4));
        }

        static void Main(string[] args)
        {
            object[] arr = { 11, 11.3, true, DateTime.Now, "dac" };
            foreach (object obj in arr)
            {
                if (obj is int)
                {
                    int ele = (int)obj;
                    Console.WriteLine("ele : " + ele * ele);
                }
                else if (obj is string)
                {
                    string str = (string)obj;
                    Console.WriteLine("ele : " + str.ToUpper());
                }
                else
                    Console.WriteLine("ele : " + obj);
            }
        }
    }
}
