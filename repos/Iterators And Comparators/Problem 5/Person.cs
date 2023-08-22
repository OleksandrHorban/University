using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        Name = name;
        Age = age;
        Town = town;
    }

    public string Name { get; }

    public int Age { get; }

    public string Town { get; }

    public int CompareTo(Person other)
    {
        int result = Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = Age.CompareTo(other.Age);
        }
        if (result == 0)
        {
            result = Town.CompareTo(other.Town);
        }
        return result;
    }
}
