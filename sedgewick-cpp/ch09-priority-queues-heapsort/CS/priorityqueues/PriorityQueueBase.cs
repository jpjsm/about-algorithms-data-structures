namespace priorityqueues;

public abstract class PriorityQueueBase<T> where T : IComparable
{
    public abstract T[] List { get; }
    public abstract bool Empty();
    public abstract void Insert(T item);
    public abstract T GetMax();

}
