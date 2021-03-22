using System;

namespace lab2_1exe
{
    class Program
    {
        delegate double Delegates(int x);
        static void Main(string[] args)
        {
            Console.WriteLine("Вводьте рядки послiдовно один за одним ");
            Console.WriteLine("поки вони матимуть вигляд: 0 x чи 1 x чи 2 x ");
            Console.WriteLine("тобто цифра вiд 0 до 2, а пiсля неї через пробiл запис конкрентного дiйсного числа");
            Console.WriteLine("Програма обчислюватиму одну з трьох функцiй: ");
            Console.WriteLine("    0 -- sqrt(abs(x))");
            Console.WriteLine("    1 -- x^3 (або ж x*x*x)" );
            Console.WriteLine("    2 -- x+3,5");
            Console.WriteLine("(згiдно цифри на початку) i виводитиме результат ");
            Console.WriteLine();
            Console.WriteLine("Якщо вхiдний рядок не задовольнятиме цей формат, програма завершить свою роботу");
            Delegates[] Methods = new Delegates[] { Met0, Met1, Met2 };

            while (true)
            {
                try
                {
                    int[] nums = Array.ConvertAll(Convert.ToString(Console.ReadLine()).Split(' '), int.Parse);
                    double output = Methods[nums[0]](nums[1]);
                    Console.WriteLine(output);
                }
                catch
                {
                    Console.WriteLine("Сталася помилка:(  Ви ввели непривальнi данi. Для остаточно виходу натиснiть будь-яку кнопку");
                    break;
                }
            }
            static double Met0(int x) => Math.Sqrt(Math.Abs(x));
            static double Met1(int x) => x * x * x;
            static double Met2(int x) => x + 3.5;
        }
    }
}
