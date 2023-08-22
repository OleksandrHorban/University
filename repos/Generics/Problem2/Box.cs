using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{item.GetType()}: {item}";
        }
    }
}
