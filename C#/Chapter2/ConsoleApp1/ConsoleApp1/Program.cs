namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /*****************Chapter 2******************************/

            //Multi var assign at single time
            int myInt,myint1, myint2;
            myInt = 10;

            myint2= myint1 = myInt;

            Console.WriteLine($"myInt {myInt} and myint1 {myint1} and myint2 {myint2}");


            //Prefix and PostFix
            int count = 3;
            Console.WriteLine(count++); //output is 3
            //Console.WriteLine(++count); 

            



        }
    }
}