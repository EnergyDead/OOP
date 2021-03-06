using MyStringList;
using Xunit;

namespace MyStringListTests;

public class StringListTests
{
    [Fact]
    public void CreateList()
    {
        StringList stringList = new();

        stringList.AddLast( "first" );
        stringList.AddLast( "second" );
        stringList.AddLast( "Last" );

        Assert.False( stringList.Any() );
        Assert.Equal( 3, stringList.Count );
    }

    [Fact]
    public void CreateList_ViaAddFirst()
    {
        StringList stringList = new();

        stringList.AddFirst( "first" );
        stringList.AddFirst( "second" );

        Assert.False( stringList.Any() );
        Assert.Equal( 2, stringList.Count );
        Assert.Equal( "second", stringList.First );
        Assert.Equal( "first", stringList.Last );
    }

    [Fact]
    public void CreateListWhthArray()
    {
        var temp = new string[] { "first", "second", "last" };
        StringList list;

        list = new StringList( temp );

        Assert.Equal( 3, list.Count );
        Assert.Equal( temp[ 0 ], list.First );
        Assert.Equal( temp[ 2 ], list.Last );
    }

    [Fact]
    public void CreateListWhthArrayAndClear()
    {
        var temp = new string[] { "first", "second", "last" };
        StringList list = new( temp );

        list.Clear();

        Assert.Equal( 0, list.Count );
    }

    [Fact]
    public void List_AddBefore()
    {
        StringList list = new( new string[] { "first", "second", "last" } );

        list.AddBefore( list.First, "foo" );

        Assert.Equal( 4, list.Count );
        Assert.Equal( "foo", list.First );
        Assert.Equal( "first", list.First.Next );
        Assert.Equal( "last", list.First.Previous );
    }

    [Fact]
    public void List_CreateEmptyList()
    {
        StringList stringList;

        stringList = new();

        Assert.True( stringList.Any() );
    }

    [Fact]
    public void List_AddAfter()
    {
        StringList list = new( new string[] { "first", "second", "last" } );

        list.AddAfter( list.First, "foo" );

        Assert.Equal( 4, list.Count );
        Assert.Equal( "first", list.First );
        Assert.Equal( "foo", list.First.Next );
        Assert.Equal( "last", list.First.Previous );
    }

    [Fact]
    public void List_Empty()
    {
        StringList list;

        list = new();

        Assert.True( list.Any() );
        Assert.Equal( 0, list.Count );
        Assert.Null( list.First );
    }

    [Fact]
    public void List_CreateWithLIst()
    {
        StringList list;

            list = new( new string[] { "first", "second", "last" } );

        Assert.Equal( 3, list.Count );
        Assert.Equal( "first", list.First );
        Assert.False( list.Any() );
    }
}
