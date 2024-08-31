using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*************pattern Matching*************************/

            Console.WriteLine("Please enter percentage");
            bool validPercentage;
            int percent = Convert.ToInt32(Console.ReadLine());

            //validPercentage = (percent >= 0) && (percent <= 100);
            //Pattern matching enables you to simplify the expression to:
            //validPercentage = (percent is not < 0 and not > 100);
            validPercentage = (percent is >= 0 and <= 100);

            Console.WriteLine($"percentage is {validPercentage}");

            /*********************Switch Statement **************************/

            Console.WriteLine("Please enter number");
            int measurement = Convert.ToInt32(Console.ReadLine()); ;
            string range = measurement switch
            {
                < 0 => "negative",
                0 => "Zero",
                >= 1 and <= 9 => "Large",
                >= 10 and <= 99 => "doubledigit",
                >= 100 => "large"
            };

            Console.WriteLine($"measurement is {range}");

            /******************compound assignment***************************/

            //Don’t write this               Write this
            //variable = variable * number; variable *= number;
            //variable = variable / number; variable /= number;
            //variable = variable % number; variable %= number;
            //variable = variable + number; variable += number;
            //variable = variable - number; variable -= number;

            string name = "John";
            string greeting = "Hello ";
            greeting += name;
            Console.WriteLine(greeting);

            /******************For Statements***************************/

            //            You can omit any of the three parts of a for statement.If you omit the Boolean expression, it
            //defaults to true, so the following for statement runs forever:
            //for (int i = 0; ; i++)
            //{
            //    Console.WriteLine("somebody stop me!")
            //}
            int i = 0;
            for (; i < 10;)
            {
                //The initialization, Boolean expression, and update control variable parts of a for
                //statement must always be separated by semicolons, even when they are omitted.
                Console.WriteLine($"for loop value is {i}");
                i++;
            }

            //for (int i = 0, j = 10; i <= j; i++, j--)
            //{
            //    ...
            //}

            /*****************************do statements***************************/
            int j = 0;
            do
            {
                Console.WriteLine($"do statement value is {j}");
                j++;
            }
            while (j < 10);




        }
    }
}