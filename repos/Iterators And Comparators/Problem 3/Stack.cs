using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private readonly IList<T> data;

    public Stack()
    {
        data = new List<T>();
    }

    public void Push(params T[] items)
    {
        foreach (T item in items)
        {
            data.Add(item);
        }
    }

    public void Pop()
    {
        if (data.Count == 0)
        {
            Console.WriteLine($"No elements");
        }
        else
        {
            data.RemoveAt(data.Count - 1);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = data.Count - 1; j >= 0; j--)
            {
                yield return data[j];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
