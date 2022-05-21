using System.Collections;

namespace MyList;

public class MyList<T> : IEnumerable<T>
{
    internal ListNode<T> _head = null;
    private int _count = 0;

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

    public IEnumerator GetEnumerator()
    {
        var curr = _head;
        while (curr != null)
        {
            yield return curr;
            curr = curr.Next;
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }
}
