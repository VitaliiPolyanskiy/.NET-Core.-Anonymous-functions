using System;

namespace Anonymous_methods
{
    class MainClass
    {
        delegate int Square(int x);
        delegate int Mult(int i, int y);
        delegate void Message(); 
        static void Main(string[] args)
        {
            Square squareInt = i => i * i;
            Console.WriteLine("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int result = squareInt(number); 
            Console.WriteLine("Квадрат числа {0} равен {1}", number, result);

            Console.WriteLine("Введите первое число: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Mult mult = (x, y) => x * y;
            Console.WriteLine("Произведение чисел равно: " + mult(n1, n2));

            Message GetMessage = () => Console.WriteLine("Лямбда-выражение"); 
            GetMessage();
        }
    }
}


