public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; }

    public int Age { get; }

    public int CompareTo(Person other)
    {
        int result = Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = Age.CompareTo(other.Age);
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        Person other = obj as Person;
        return Name.Equals(other.Name) && Age.Equals(other.Age);
    }

    public override int GetHashCode()
    {
        int sum = 0;
        foreach (char symbol in Name)
        {
            sum += symbol * Age;
        }
        return sum;
    }
}
