using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            this.elements = new List<T>();
        }

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            T backUpElement = this.elements[firstIndex];

            this.elements[firstIndex] = this.elements[secondIndex];

            this.elements[secondIndex] = backUpElement;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var e in this.elements)
            {
                stringBuilder.AppendLine($"{e.GetType()}: {e}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
