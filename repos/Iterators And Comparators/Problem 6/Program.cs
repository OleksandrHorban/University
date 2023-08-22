public class Program
{
    public static void Main()
    {
        List<Person> people = ParsePeople();
        var sortedByName = new SortedSet<Person>(people, new NameComparator());
        var sortedByAge = new SortedSet<Person>(people, new AgeComparator());

        PrintCollection(sortedByName);
        PrintCollection(sortedByAge);
    }

    private static void PrintCollection(IEnumerable<Person> collection)
    {
        foreach (Person person in collection)
        {
            Console.WriteLine(person);
        }
    }

    private static List<Person> ParsePeople()
    {
        int number = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < number; i++)
        {
            string[] parts = Console.ReadLine().Split();
            Person person = new Person(parts[0], int.Parse(parts[1]));
            people.Add(person);
        }
        return people;
    }
}
