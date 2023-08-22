using Problem7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    public class Citizen : IBuyer
    {
        private string name;
        private int food;

        public Citizen(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => this.name;
        }

        public int Food
        {
            get => this.food;
        }

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
