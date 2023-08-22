using System;
using System.Collections.Generic;


namespace ShoppingSpreeEdited
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                this.Money -= product.Cost;
                this.BagOfProducts.Add(product);
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }

        public List<Product> BagOfProducts { get; private set; }
    }
}
