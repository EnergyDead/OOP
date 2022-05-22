using System.Collections;
using System.Runtime.Serialization;

namespace MyList;

public class MyList<T> : IEnumerable<T>
{
    internal ListNode<T> _head = null;
    private int _count = 0;

    public int Count { get { return _count; } }

    public ListNode<T> this[int index]
    {
        get
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var curr = _head;
            for (int i = 0; i < index; i++)
            {
                curr = curr.Next;
            }
            return curr;
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ListEnumerator(this);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new ListEnumerator(this);
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
}
