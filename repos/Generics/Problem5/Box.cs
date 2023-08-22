using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    using System.Collections.Generic;

    public class Box<T>
    {
        public Box()
        {
            this.Elements = new List<T>();
        }

        public List<T> Elements { get; set; }

        public void Add(T element)
        {
            this.Elements.Add(element);
        }
    }
}
