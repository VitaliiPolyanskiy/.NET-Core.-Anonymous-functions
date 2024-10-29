using System;

namespace Anonymous_methods
{
    class MainClass
    {
        delegate bool IsEqual(int x);
        static void Main(string[] args)
        {
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int result = Sum(integers, x => x > 5);
            Console.WriteLine("Сумма чисел больше 5: " + result); 

            result = Sum(integers, x => x % 2 == 0);
            Console.WriteLine("Сумма чётных чисел: " + result); 
        }
        private static int Sum(int[] numbers, IsEqual func)
        {
            int result = 0;
            foreach (int i in numbers)
            {
                if (func(i))
                    result += i;
            }
            return result;
        }
    }
}


