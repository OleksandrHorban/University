using System;

namespace AnimalFarm
{
    using System;
    public class Chicken
    {
        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 1 || value > 15)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                this.age = value;
            }
        }

        public double ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 2;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 3;
                default:
                    return 1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name and age of chicken");
            Console.WriteLine("Example:");
            Console.WriteLine("Mara");
            Console.WriteLine("10");
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Chicken chicken = new Chicken(name, age);

                Console.WriteLine(
                "Chicken {0} (age {1}) can produce {2} eggs per day.",
                chicken.Name,
                chicken.Age,
                chicken.ProductPerDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
