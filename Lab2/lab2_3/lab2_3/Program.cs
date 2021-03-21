using System;

namespace lab2_3
{
    class Program
    {
        public delegate void Div(int[] mas);
        static void Main(string[] args)
        {
            int[] arr = {-20,-19,-18,-17,-16,-15,-14,-13,-14,-13,-12,-11,
                 -10,-9,-8,-7,-6,-5-4,-3,-2,-1,0,1,2,3,4,5,6,7,8,9,10,11,
                  12,13,14,15,16,17,18,19,20};
            Div d3 = new Div(Divon3);
            Div d7 = new Div(Divon7);
            d3(arr);
            d7.Invoke(arr);
            Console.ReadKey();
        }
        public static void Divon3(int[] mas)
        {
            Console.WriteLine("Числа, що дiляться на число 3: ");
            foreach (int a in mas)
            {
                if (a % 3 == 0)
                {
                    Console.Write(a + " ");
                }
            }
            Console.WriteLine();
        }
        public static void Divon7(int[] mas)
        {
            Console.WriteLine("Числа, що дiляться на число 7: ");
            foreach (int a in mas)
            {
                if (a % 7 == 0)
                {
                    Console.Write(a + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
