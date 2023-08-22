using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private readonly IList<int> stones;

    public Lake(params int[] stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return stones[i];
            }
        }

        for (int i = stones.Count - 1; i >= 1; i--)
        {
            if (i % 2 != 0)
            {
                yield return stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}