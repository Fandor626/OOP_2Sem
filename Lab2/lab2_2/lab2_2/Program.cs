using System;

namespace lab2_2
{
    class Program
    {
        delegate void Deledate(int sec);

        public delegate void Metody();
        static void Main(string[] args)
        {
            Console.Write("Enter time in seconds ");
            int sec = int.Parse(Console.ReadLine());
            Timer timer = new Timer();
            Deledate del = timer.Begin;
            del.Invoke(sec);
        }
    }
}
