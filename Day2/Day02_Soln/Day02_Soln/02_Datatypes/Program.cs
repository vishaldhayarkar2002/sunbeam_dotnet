using System.Runtime.CompilerServices;

namespace _02_Datatypes
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            #region Type Conversion using Parse()
            // Convert string to int using Parse().
            // System.FormatException if string is not valid.
            string str = "123"; 
            int num1 = int.Parse(str);
            //Console.WriteLine($"num1 = {num1}");
            #endregion

            #region Type Conversion using Convert class
            // Convert string to int using Convert class.
            // System.FormatException if string is not valid.
            string str2 = "100";
            int num2 = Convert.ToInt32(str2);
            Console.WriteLine($"num2 = {num2}");
            #endregion
        }
        static void Main2(string[] args)
        {
            int num1 = 22, num2 = 7;
            int result = num1 / num2;
            //Console.WriteLine($"result = {result}");
            // double divided by int -- yields double
            //   double / int --> double / double
            //  internally int is promoted to double
            // when double is assigned to float -- by default : Error
            //  data type is not auto demoted.
            //  need explicit casting for that.

            float result2 = (float)(num1 / (double)num2);
            Console.WriteLine($"result2 = {result2}");
        }

        static void Main(string[] args)
        {
            // short type range -- -32768 to +32767
            unchecked
            {
                // type overflow
                // accidental overflow may produce in wrong results
                // overflow will change the sign (roll over)
                short num1 = 32767;
                //num1++;
                //Console.WriteLine($"num1 = {num1}");
            }
            checked
            {
                // type overflow ( checked) 
                // overflow is detected at runtime and will
                //  raise OverflowExcpetion.
                short num2 = 32767;
                num2++;
                Console.WriteLine($"num1 = {num2}");
            }
            //Note : In C# all exceptions are unchecked exceptions (Compared to java) 
            //"Checked" & "unchecked" keywords are not exception types - They are for overflow check
        }
    }
}
