using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Car
{
    private string model;
    private decimal fuel;
    private decimal fuelCost;
    private decimal taveledDistance;

    public string Model { get; set; }
    public decimal Fuel { get; set; }
    public decimal FuelCost { get; set; }
    public decimal TraveledDistance { get; set; }

    public Car(string model, decimal fuel, decimal fuelCost)
    {
        Model = model;
        Fuel = fuel;
        FuelCost = fuelCost;
        TraveledDistance = 0;
    }

    public static bool CanDrive(Car car, decimal distance)
    {
        var km = car.Fuel / car.FuelCost;
        if (km >= distance)
        {
            var liters = distance * car.FuelCost;
            car.Fuel -= liters;
            car.TraveledDistance += distance;
            return true;
        }

        return false;
    }
}

namespace Problem_7.Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ci = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            //ci.NumberFormat.NumberDecimalSeparator = ".";
            //Thread.CurrentThread.CurrentCulture = ci;
            var cars = new List<Car>();

            var carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                var carInfor = Console.ReadLine().Split();
                var model = carInfor[0];
                var fuel = decimal.Parse(carInfor[1]);
                var fuelCost = decimal.Parse(carInfor[2]);

                cars.Add(new Car(model, fuel, fuelCost));
            }

            var comandDrive = Console.ReadLine();
            while (!comandDrive.Equals("End"))
            {
                var comandArgs = comandDrive.Split();
                var model = comandArgs[1];
                var distance = decimal.Parse(comandArgs[2]);

                var currentCar = cars.FirstOrDefault(c => c.Model == model);

                if (!Car.CanDrive(currentCar, distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                comandDrive = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:f2} {(int)car.TraveledDistance}");
            }
        }
    }
}
