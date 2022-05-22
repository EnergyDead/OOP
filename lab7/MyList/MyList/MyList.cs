using System.Collections;

namespace MyList;

public class MyList<T> : IEnumerable<T>
{
    internal ListNode<T>? _head;
    private int _count = 0;

    public int Count { get { return _count; } }

    public MyList()
    {
    }

    public MyList(IEnumerable<T> list)
    {
        var enumerator = list.GetEnumerator();

        while (enumerator.MoveNext())
        {
            Add(enumerator.Current);
        }
    }

    public T this[int index]
    {
        get
        {
            return GetNodeByIndex(index).Value;
        }
        set
        {
            var node = GetNodeByIndex(index);
            node!.Value = value;
        }
    }

    public void AddFirst(T value)
    {
        var node = new ListNode<T>(this, value);
        if (_head == null)
        {
            InitList(node);
        }
        else
        {
            AddNodeBefore(_head, node);
            _head = node;
        }
    }

    public void Add(T value)
    {
        var node = new ListNode<T>(this, value);
        if (_head == null)
        {
            InitList(node);
        }
        else
        {
            AddNodeBefore(_head, node);
        }
    }

    public void Insert(int index, T value)
    {
        if (index == 0)
        {
            AddFirst(value);
        }
        else
        {
            var node = new ListNode<T>(this, value);
            var before = GetNodeByIndex(index);
            AddNodeBefore(before, node);
        }
    }

    public void RemoveAt(int index)
    {
        var node = GetNodeByIndex(index);
        RemoveNode(node);
    }

    private void InitList(ListNode<T> node)
    {
        node._next = node;
        node._prev = node;
        _head = node;
        _count++;
    }

    private void AddNodeBefore(ListNode<T> before, ListNode<T> node)
    {
        node._next = before;
        node._prev = before._prev;
        before._prev!._next = node;
        before._prev = node;
        _count++;
    }

    private ListNode<T> GetNodeByIndex(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var curr = _head;
        for (int i = 0; i < index; i++)
        {
            curr = curr!.Next;
        }
        return curr!;
    }

    private void RemoveNode(ListNode<T> node)
    {
        if (node._list != this)
        {
            throw new InvalidOperationException("An attempt to remove an item that is not in the list.");
        }
        if (_head == null)
        {
            throw new InvalidOperationException("An attempt to remove an item that is not in the list.");
        }

        if (_count == 1)
        {
            _head = null;
        }

        else
        {
            if (_head == node)
            {
                _head = node._next;
            }
            node._prev!._next = node._next;
            node._next!._prev = node._prev;
        }

        node._list = null;
        node._next = null;
        node._prev = null;

        _count--;
    }

    #region IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ListEnumerator(this);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new ListEnumerator(this);
    }
    public IEnumerable<T> CustomReverse()
    {
        if (_head != null)
        {
            var current = _head._prev;
            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }
    }

    public struct ListEnumerator : IEnumerator<T>
    {
        private readonly MyList<T> _list;
        private ListNode<T>? _node;
        private T? _current;
        private int _index;

        internal ListEnumerator(MyList<T> list)
        {
            _list = list;
            _node = list._head;
            _current = default;
            _index = 0;
        }

        public T Current => _current!;

        object IEnumerator.Current => _current!;

        public bool MoveNext()
        {
            if (_node == null)
            {
                _index = _list.Count + 1;
                return false;
            }

            _index++;
            _current = _node._value;
            _node = _node._next;
            if (_node == _list._head)
            {
                _node = null;
            }
            return true;
        }

        public void Reset()
        {
            _node = _list._head;
            _current = default;
            _index = 0;
        }

        public void Dispose()
        {
        }
    }
    #endregion
}
