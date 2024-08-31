//Defination: The yield keyword will act as an iterator blocker and generate or return values

namespace YieldKeyword
{
    internal class Program
    {
        public static IEnumerable<int> GetEvenNumber(int upto)
        {
             //List<int> number = new List<int>
            for (int i = 0; i <= upto; i += 2)
            {
                //number.Add(i);
                yield return i;
                Console.WriteLine("print");   
            }

            //return number;
        }
        static void Main(string[] args)
        {
            IEnumerable<int> getEvenNumbers = GetEvenNumber(10);
            foreach (int i in getEvenNumbers) 
            { Console.WriteLine(i); }


        }
    }
}