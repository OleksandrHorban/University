using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    public class CustomList<T> where T : IComparable<T>
    {
        private List<T> list;
        public CustomList(List<T> x)
        {
            this.list = x;
        }
        public void Add(T element)
        {
            list.Add(element);
        }
        public T Remove(int index)
        {
            list.RemoveAt(index);
            return default(T);
        }
        public bool Contains(T element)
        {
            if (list.Contains(element))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Swap(int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
        public int CountGreaterThan(T element)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (element.CompareTo(item) < 0) count++;
            }
            return count;
        }
        public T Max()
        {
            return list.Max();
        }
        public T Min()
        {
            return list.Min();
        }
        public void Sort()
        {
            list.Sort();
        }
    }
}
