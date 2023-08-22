using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Person
{
    public string name;
    public int age;
    public Person()
    {
        name = "Oleksandr";
        age = 18;
    }
    public void initialization()
    {
        Console.Write("Enter name: ");
        name = Console.ReadLine();
        Console.Write("Enter age: ");
        age = int.Parse(Console.ReadLine());
    }
    public void print()
    {
        Console.WriteLine("Your name is: " + name);
        Console.WriteLine("Your age is: " + age);
    }
    public void initprint()
    {
        initialization();
        Console.WriteLine();
        print();
        Console.WriteLine();
    }
    public void function()
    {
        Console.Write("Want to enter another Person? (Y/N): ");
        char answer = char.Parse(Console.ReadLine());
        if (answer == 'Y' | answer == 'y')
        {
            Person p2 = new Person();
            p2.initprint();
            p2.function();
        }
        else
        {
            Console.WriteLine("Okay, bye :)");
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Person def = new Person();
        Person p = new Person();
        Person p2 = new Person();
        Person p3 = new Person();
        Console.WriteLine("Example of class: ");
        p.name = "Pesho";
        p.age = 20;
        p.print();
        p2.name = "Gosho";
        p2.age = 18;
        p2.print();
        p3.name = "Stamat";
        p3.age = 43;
        p3.print();
        Console.WriteLine();
        Console.Write("Enter any key to clear console: "); Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Default constructor: ");
        Console.WriteLine("Name: " + def.name);
        Console.WriteLine("Age: " + def.age);
        Console.WriteLine();
        p.initprint();
        p.function();
    }
}

