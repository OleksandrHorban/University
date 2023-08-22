using Problem6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    public class Citizen : IBirthDate
    {
        private string birthDate;

        public Citizen(string birthDate)
        {
            this.birthDate = birthDate;
        }

        public string BirthDate
        {
            get => this.birthDate;
        }
    }
}
