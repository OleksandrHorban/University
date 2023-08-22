namespace Problem7
{

    public class Program
    {
        public static void Main()
        {
            List<IBuyer> persons = new List<IBuyer>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] person = Console.ReadLine().Split();
                string name = person[0];

                if (person.Length == 4)
                {
                    Citizen citizen = new Citizen(name);

                    persons.Add(citizen);
                }
                else if (person.Length == 3)
                {
                    Rabel rable = new Rabel(name);

                    persons.Add(rable);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (persons.Any(x => x.Name == name))
                {
                    persons.First(x => x.Name == name).BuyFood();
                }
            }

            int totalFood = 0;

            foreach (var person in persons)
            {
                totalFood += person.Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}
