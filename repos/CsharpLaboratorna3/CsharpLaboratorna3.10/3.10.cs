using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    public string model { get; set; }
    public Engine engine { get; set; }
    public string weight { get; set; }
    public string color { get; set; }

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        Console.WriteLine();
        sb.AppendLine($"{this.model}:");
        sb.AppendLine($"  {this.engine.model}:");
        sb.AppendLine($"    Power: {this.engine.power}");
        sb.AppendLine($"    Displacement: {this.engine.displacement}");
        sb.AppendLine($"    Efficiency: {this.engine.efficiency}");
        sb.AppendLine($"  Weight: {this.weight}");
        sb.AppendLine($"  Color: {this.color}");

        return sb.ToString().Trim();
    }
}

public class Engine
{
    public string model { get; set; }
    public string power { get; set; }
    public string displacement { get; set; }
    public string efficiency { get; set; }

    public Engine(string model, string power)
    {
        this.model = model;
        this.power = power;
    }
}

namespace Problem_10.Car_Salesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var Engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine().Split().Where(s => s != string.Empty).ToArray();
                var engine = new Engine(engineInfo[0], engineInfo[1]);

                if (engineInfo.Length >= 3)
                {
                    if (engineInfo[2].All(s => char.IsDigit(s)))
                    {
                        engine.displacement = engineInfo[2];
                    }
                    else
                    {
                        engine.efficiency = engineInfo[2];
                    }
                }

                if (engineInfo.Length == 4)
                {
                    engine.efficiency = engineInfo[3];
                }

                Engines.Add(engine);
            }

            n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split().Where(c => c != string.Empty).ToArray();
                var car = new Car(carInfo[0], Engines.FirstOrDefault(e => e.model.Equals(carInfo[1])));

                if (carInfo.Length >= 3)
                {
                    if (carInfo[2].All(s => char.IsDigit(s)))
                    {
                        car.weight = carInfo[2];
                    }
                    else
                    {
                        car.color = carInfo[2];
                    }
                }

                if (carInfo.Length == 4)
                {
                    car.color = carInfo[3];
                }

                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
