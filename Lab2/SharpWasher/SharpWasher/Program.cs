using System;

namespace SharpWasher
{
    class Program
    {
        delegate void W(Car car);
        static void Main(string[] args)
        {
            Console.WriteLine("Список брудних машин. Якщо машина буде чистою ви побачите вiдмiтку 'True'");
            Garage garage = new Garage();
            Car car1 = new Car("Geely");
            Car car2 = new Car("Chery");
            Car car3 = new Car("Toyota");
            Car car4 = new Car("Bugatti");
            garage.Add(car1);
            garage.Add(car2);
            garage.Add(car3);
            garage.Add(car4);
            foreach (var car in garage)
            {
                Console.WriteLine(car.name + " " + car.clean);

            }
            Console.WriteLine("Якщо машина пiсля мийки буде чистою ви побачите вiдмiтку 'True'");
            foreach (var car in garage)
            {
                Washer washer = new Washer();
                W del = washer.Wash;
                del(car);
                Console.WriteLine(car.name + " " + car.clean);

            }
            Console.ReadKey();
        }
    }
}
