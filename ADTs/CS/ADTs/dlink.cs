namespace jpjsm.ADTs;

#pragma warning disable IDE1006 // Naming Styles
public class dLink<T> where T : IComparable<T>
{
    private readonly T _Value;
    private Link<T>? _Next = null;
    private dLink<T>? _Previous = null;

    public Link<T>? Next
    {
        get { return _Next; }
        set { _Next = Object.ReferenceEquals(_Next, value) ? null : value; }
    }

    public dLink<T>? Previous
    {
        get { return _Previous; }
        set { _Previous = Object.ReferenceEquals(_Previous, value) ? null : value; }
    }

    public dLink(T value)
    {
        if (value == null)
            throw new ArgumentNullException();
            
        _Value = value;
    }

}
#pragma warning restore IDE1006 // Naming Styles
