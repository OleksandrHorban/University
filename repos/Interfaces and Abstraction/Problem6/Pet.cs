using Problem6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    public class Pet : IBirthDate
    {
        private string name;
        private string birthDate;

        public Pet(string name, string birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public string BirthDate
        {
            get => this.birthDate;
        }
    }
}
