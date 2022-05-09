namespace MyStringList;

public class StringList
{
    private StringNode _head = null;
    private int _count = 0;

    public StringNode First => _head;
    public StringNode Last => _head.Previous;
    public int Count => _count;

    public StringNode ReverseFirst => _head.Previous;
    public StringNode ReverseLast => _head;

    public StringList() { }

    public StringList( IEnumerable<string> items )
    {
        foreach ( var item in items )
        {
            AddLast( item );
        }
    }

    public void AddAfter( StringNode current, string item )
    {
        var node = new StringNode( item );

        throw new NotImplementedException();
    }

    public void AddBefore( StringNode current, string item )
    {
        var node = new StringNode( item );

        AddNodeBefore( current, node );
        if ( current == _head )
        {
            _head = node;
        }
    }

    public void AddFirst( string item )
    {
        var node = new StringNode( item );
        if ( _head == null )
        {
            InitList( node );
        }
        else
        {
            AddNodeBefore( _head, node );
            _head = node;
        }
    }

    public void AddLast( string item )
    {
        var node = new StringNode( item );
        if ( _head == null )
        {
            InitList( node );
        }
        else
        {
            AddNodeBefore( _head, node );
        }
    }

    public void Clear()
    {
        var temp = _head;
        while ( temp != null )
        {
            var next = temp.Next;
            temp.Next = null;
            temp.Previous = null;
            temp = next;
        }
        _head = null;
        _count = 0;
    }

    public bool Any()
    {
        return _count == 0;
    }

    private void InitList( StringNode node )
    {
        node.Next = node;
        node.Previous = node;
        _head = node;
        _count++;
    }

    private void AddNodeBefore( StringNode before, StringNode node )
    {
        node.Next = before;
        node.Previous = before.Previous;
        before.Previous.Next = node;
        before.Previous = node;
        _count++;
    }
}
