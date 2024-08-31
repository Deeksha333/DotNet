namespace ConsoleApp1
{
    internal class Program
    {

        /*****************Chapter 3******************************/
        
        //A tuple is simply a small collection of values
        private static (int, int) returnMultipleValues (int val1 , int val2)
        {
            int add = val1 + val2;
            int minus=val1 - val2;
            return (add, minus);
        }

        private static double calculateFee(double dailyRate = 500.0, int noOfDays = 1)
        {
            Console.WriteLine("calculateFee using two optional parameters");
            return dailyRate * noOfDays;
        }

        private static double calculateFee(double dailyRate = 500.0)
        {
            Console.WriteLine("calculateFee using one optional parameter");
            int defaultNoOfDays = 1;
            return dailyRate * defaultNoOfDays;
        }

        private static double calculateFee()
        {
            Console.WriteLine("calculateFee using hardcoded values");
            double defaultDailyRate = 400.0;
            int defaultNoOfDays = 1;
            return defaultDailyRate * defaultNoOfDays;
        }

        static void Main(string[] args)
        {
            int sum=0, sub=0, sumdiscard;
            int a=5, b=3;
            (sum, sub) = returnMultipleValues(a, b);
            Console.WriteLine($"Sum is {sum} and sub is {sub}");

            //If you’re only interested in one of the return values, you can use a discard.
            (_, sumdiscard) = returnMultipleValues(5, 2);
            Console.WriteLine($"subdiscard is {sumdiscard}");

            //Chapter 3- calling method
            double fee = calculateFee(); //right - click the method call and then select Peek Definition
            Console.WriteLine($"Fee is {fee}");

            double fee1 = calculateFee(650.0);
            Console.WriteLine($"Fee is {fee1}");

            double fee2 = calculateFee(noOfDays: 4);
            Console.WriteLine($"Fee is {fee2}");
        }

        //Quick Action and refactoring -- create new method(select some part of code then right click
        //on that and select this name for menu bar) 

    }
}