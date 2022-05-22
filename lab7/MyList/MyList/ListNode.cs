namespace MyList;

public class ListNode<T>
{
    internal MyList<T>? _list;
    internal ListNode<T>? _next;
    internal ListNode<T>? _prev;
    internal T _value;

    public T Value { get { return _value; } set { _value = value; } }

    // todo: сделать проверку на head
    public ListNode<T>? Next { get { return _next == null || _next == _list!._head ? null : _next; } }
    public ListNode<T>? Prev { get { return _prev == null || this == _list!._head ? null : _prev; } }

    public ListNode(T value)
    {
        _value = value;
    }

    internal ListNode(MyList<T> list, T value)
    {
        _list = list;
        _value = value;
    }
}