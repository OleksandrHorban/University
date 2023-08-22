using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    public class SmartPhone : ICallable, IBrowsable
    {
        public SmartPhone()
        {
        }

        public string Call(string phoneNumber)
        {
            if (phoneNumber.Any(x => char.IsLetter(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string website)
        {
            if (website.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {website}!";
        }
    }
}
