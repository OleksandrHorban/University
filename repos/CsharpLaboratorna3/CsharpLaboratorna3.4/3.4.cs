using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Person
{
    public string name;
    public int age;
    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }
    public Person(int x)
    {
        this.name = "No name";
        this.age = x;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
public class Family
{
    public List<Person> ppl { get; set; }
    public Family()
    {
        ppl = new List<Person>();
    }
    public void AddMember(Person person)
    {
        ppl.Add(person);
    }
    public Person GetOldestMember(List<Person> ppl)
    {
        Console.WriteLine();
        Console.Write("Oldest member: ");
        return ppl.FirstOrDefault(x => x.age == ppl.Max(y => y.age));
    }
    public void checking()
    {
        if (ppl.Count == 0)
        {
            Console.WriteLine("List is empty!");
            Console.WriteLine();
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Person p = new Person();
        Family f = new Family();
        int n;
        f.checking();
        Console.WriteLine("Example: ");
        Console.WriteLine("Tom 30" + "\n" + "Katya 20" + "\n" + "Petya 1");
        Console.WriteLine();
        Console.Write("How many peoples u wanna add in family?: ");
        n = int.Parse(Console.ReadLine());
        if (n > 5)
        {
            Console.WriteLine("Too much!");
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split();
                var name = info[0];
                var age = int.Parse(info[1]);
                var person = new Person(name, age);
                f.AddMember(person);
            }
            var res = f.ppl.Where(x => x.age > 30).ToList().OrderBy(x => x.name);
            foreach (var person in res)
            {
                Console.WriteLine($"{person.name} - {person.age}");
            }
        }
    }
}

