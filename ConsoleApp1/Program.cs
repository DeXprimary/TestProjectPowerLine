using System;
using TestProjectPowerLine;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CargoCar car = new CargoCar(CarType.cargo, 10, 40, 100, 900);

            car.CurCargo = 700;

            Console.WriteLine(car.GetMaxDistance());

            Console.WriteLine(car.GetMaxDistance(20));

            Console.WriteLine(car.GetMaxDistanceConsideringCargo(20));

            Console.WriteLine(car.TryGetTimeDriven(20, 160));
        }
    }
}
