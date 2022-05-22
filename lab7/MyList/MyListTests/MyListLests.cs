using MyList;
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
}
