namespace priorityqueues;

public abstract class PriorityQueueUnorderedArray<T> : PriorityQueueBase<T> where T : IComparable
{
    private T[] pq;
    private int N = 0;

    public override T[] List => pq.Take(N).ToArray();
    public PriorityQueueUnorderedArray(int maxN)
    {
        pq = new T[maxN];
    }
    public override bool Empty()
    {
        return N == 0; ;
    }
    public override void Insert(T item)
    {
        pq[N++] = item;
    }
    public override T GetMax()
    {
        int indexMax = 0;
        for (int i = 1; i < N; i++)
        {
            if (pq[i].CompareTo(pq[indexMax]) > 0)
            {
                indexMax = i;
            }
        }
        (pq[N - 1], pq[indexMax]) = (pq[indexMax], pq[N - 1]);
        return pq[--N];
    }

}
