using System.Collections;

namespace MyStringList;

public class StringNode : IEnumerable<char>
{
    private string _value;
    public string Value { get => _value; set => _value = value; }

    private StringNode _next;
    public StringNode Next { get => _next; set => _next = value; }

    private StringNode _previous;
    public StringNode Previous { get => _previous; set => _previous = value; }

    public StringNode( string value )
    {
        _value = value;
    }

    public static implicit operator StringNode( string value ) => new( value );

    public IEnumerator<char> GetEnumerator()
    {
        return Value.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
