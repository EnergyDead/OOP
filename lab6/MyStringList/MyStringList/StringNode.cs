namespace MyStringList;

internal class StringNode
{
    private string _value;
    public string Value { get => _value; set => _value = value; }

    private StringNode? _next;
    public StringNode? Next { get => _next; set => _next = value; }

    private StringNode? _previous;
    public StringNode? Previous { get => _previous; set => _previous = value; }
}
