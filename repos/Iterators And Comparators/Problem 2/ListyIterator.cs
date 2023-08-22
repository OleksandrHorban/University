using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class ListyIterator<T>
{
    private int currentIndex;
    private List<T> items;

    public ListyIterator(List<T> initialItems)
    {
        currentIndex = 0;
        items = initialItems;
    }

    public int Count => items.Count;

    public bool Move()
    {
        if (HasNext())
        {
            currentIndex++;
            return true;
        }

        return false;

    }
    public bool HasNext()
    {
        if (currentIndex < Count - 1)
        {
            return true;
        }

        return false;
    }

    public void Print()
    {

        if (Count == 0)
        {
            throw new Exception("Invalid Operation!");
        }

        Console.WriteLine(items[currentIndex]);
    }
    public IEnumerable<T> PrintAll()
    {
        for(int i=0;i<items.Count;i++)
        {
            yield return items[i];
        }
    }
}
