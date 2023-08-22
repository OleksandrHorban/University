namespace Problem6
{

    public class Program
    {
        public static void Main()
        {
            List<IBirthDate> objects = new List<IBirthDate>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] splitedInput = input.Split();
                string type = splitedInput[0];
                string name = splitedInput[1];
                string birthDate;

                switch (type)
                {
                    case "Citizen":
                        birthDate = splitedInput[4];

                        Citizen citizen = new Citizen(birthDate);

                        objects.Add(citizen);
                        break;
                    case "Pet":
                        birthDate = splitedInput[2];

                        Pet pet = new Pet(name, birthDate);

                        objects.Add(pet);
                        break;
                }
            }

            string year = Console.ReadLine();

            foreach (var obj in objects)
            {
                string objYear = obj.BirthDate.Split('/').TakeLast(1).ToArray()[0];

                if (objYear == year)
                {
                    Console.WriteLine(obj.BirthDate);
                }
            }
        }
    }
}