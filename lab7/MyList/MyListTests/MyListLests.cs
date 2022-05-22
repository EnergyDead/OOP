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

        Assert.Equal(2, item.Value);
    }

    [Fact]
    public void AddElementToEnd()
    {
        var list = new MyList<int> { 1, 2, 3 };

        list.Add(4);

        Assert.Equal(4, list.Count);
        Assert.Equal(1, list.First());
        Assert.Equal(4, list.Last());
        Assert.Contains(3, list);
        Assert.DoesNotContain(9, list);
    }
}
