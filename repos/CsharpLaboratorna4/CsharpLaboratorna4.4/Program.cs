using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpreeEdited
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in peopleData)
            {
                string[] tokens = item.Split("=");

                string personName = tokens[0];
                decimal personMoney = decimal.Parse(tokens[1]);

                try
                {
                    Person person = new Person(personName, personMoney);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in productsData)
            {
                string[] tokens = item.Split("=");

                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();
                string personName = tokens[0];
                string productName = tokens[1];

                Person person = people.FirstOrDefault(x => x.Name == personName);

                Product product = products.FirstOrDefault(x => x.Name == productName);

                Console.WriteLine(person.BuyProduct(product));

            }

            foreach (var person in people)
            {
                Console.Write($"{person.Name} - ");

                if (person.BagOfProducts.Any())
                {
                    Console.WriteLine(string.Join(", ", person.BagOfProducts.Select(x => x.Name)));
                }
                else
                {
                    Console.WriteLine("Nothing bought");
                }
            }
        }
    }
}
