using MyList;
using System.Linq;
using Xunit;

namespace MyListTests;

public class MyListLests
{
    [Fact]
    public void CreateEmptyList()
    {
        MyList<string> list;

        list = new MyList<string>();

        Assert.Equal(0, list.Count);
        Assert.Empty(list);
    }

    [Fact]
    public void AddElementToEmptyList()
    {
        var list = new MyList<int>();

        list.Add(5);

        Assert.NotEmpty(list);
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void GetElementByIndex()
    {
        var list = new MyList<int> { 1, 2, 3 };

        var item = list[1];

        Assert.Equal(2, item);
    }

    [Fact]
    public void AddElementToEnd()
    {
        var list = new MyList<int> { 1, 2, 3 };

        list.Add(4);

        Assert.Equal(4, list.Count);
        Assert.Equal(4, list.Last());
    }

    [Fact]
    public void AddElementToHead()
    {
        var list = new MyList<int> { 1, 2, 3 };

        list.AddFirst(8);

        Assert.Equal(4, list.Count);
        Assert.Equal(8, list.First());
        Assert.Equal(8, list.First());
    }

    [Fact]
    public void CheackElementContainsInList()
    {
        var list = new MyList<string> { "1", "2", "3" };

        Assert.Contains("1", list);
        Assert.DoesNotContain("foo", list);
    }

    [Fact]
    public void UpdateValueIntoMiddle()
    {
        var list = new MyList<int> { 1, 3 };

        list[1] = 3;

        Assert.Equal(2, list.Count);
        Assert.Equal(3, list[1]);
        Assert.Equal(3, list.Last());
    }

    [Fact]
    public void InsertIntoMiddle()
    {
        var list = new MyList<int> { 1, 3 };



    }
}
