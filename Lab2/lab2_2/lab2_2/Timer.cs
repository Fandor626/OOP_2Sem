using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static lab2_2.Program;

namespace lab2_2
{
    class Timer
    {
        private int seconds { get; set; }
        public void Begin(int sec)
        {
            Metody[] met = new Metody[] {Met1,Met2,Met3 };
            Random rnd = new Random();
            while (true)
            {
                Thread.Sleep(sec * 1000);
                int a = rnd.Next(0,3);
                met[a]();
            }
        }
        private static void Met1()
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 100);
            Console.WriteLine("method № 1"+a);
        }
        private static void Met2()
        {
            Console.WriteLine("method № 2. Time: " + DateTime.Now.TimeOfDay);
        }
        private static void Met3()
        {
            Console.WriteLine("method № 3. Day: " + DateTime.Now.Day);
        }
    }
}
