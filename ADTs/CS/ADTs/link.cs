namespace jpjsm.link;

public class Link<T> where T: IComparable<T>
{
    private readonly T _Value;
    private Link<T>? _Next = null;

    public Link<T>? Next
    {
        get { return _Next; }
        set { _Next = Object.ReferenceEquals(_Next, value) ? null : value; }
    }

    public T Value => _Value;

    public Link(T value)
    {
        if (value == null)
            throw new ArgumentNullException();
            
        _Value = value;
    }
    
}
