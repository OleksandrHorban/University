namespace Problem5
{
    using Problem5;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<IIdentifiable> objects = new List<IIdentifiable>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] splitedInput = input.Split();

                if (splitedInput.Length == 2)
                {
                    string model = splitedInput[0];
                    string id = splitedInput[1];

                    Robot robot = new Robot(model, id);

                    objects.Add(robot);
                }
                else
                {
                    string name = splitedInput[0];
                    int age = int.Parse(splitedInput[1]);
                    string id = splitedInput[2];

                    Citizen citizen = new Citizen(name, age, id);

                    objects.Add(citizen);
                }

            }

            string identificator = Console.ReadLine();

            foreach (var obj in objects)
            {
                char[] lastNums = obj.Id.Skip(obj.Id.Length - identificator.Length).ToArray();

                if (string.Join("", lastNums) == identificator)
                {
                    Console.WriteLine(obj.Id);
                }
            }
        }
    }
}
